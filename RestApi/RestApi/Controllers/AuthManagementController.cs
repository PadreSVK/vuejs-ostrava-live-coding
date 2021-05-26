using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RestApi.Config;
using RestApi.Model.DTO.Request;
using RestApi.Model.DTO.Response;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthManagementController : ControllerBase
    {
        private static readonly ILog mLog = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly JwtConfig mJwtConfig;
        private readonly UserManager<IdentityUser> mUserManager;

        public AuthManagementController(UserManager<IdentityUser> aUserManager,
            IOptionsMonitor<JwtConfig> aOptionsMonitor)
        {
            mUserManager = aUserManager;
            mJwtConfig = aOptionsMonitor.CurrentValue;
        }

        [HttpPost]
        [Route("Register", Name = nameof(Register))]
        public async Task<IActionResult> Register([FromBody] UserRegistration aUser)
        {
            if (ModelState.IsValid)
            {
                var lExistingUser = await mUserManager.FindByNameAsync(aUser.Email);

                if (lExistingUser != null)
                    return BadRequest(new RegistrationResponse
                    {
                        Result = false,
                        Errors = new List<string> {"Email already exist"}
                    });

                var newUserId = Guid.NewGuid();
                var lNewUser = new IdentityUser
                {
                    Id = newUserId.ToString(),
                    Email = aUser.Email,
                    UserName = aUser.Email
                };
                var lIsCreated = await mUserManager.CreateAsync(lNewUser, aUser.Password);

                if (lIsCreated.Succeeded)
                {
                    var lJwtToken = await GenerateJwtToken(lNewUser);

                    return Ok(new RegistrationResponse
                    {
                        Result = true,
                        Token = lJwtToken
                    });
                }

                return new JsonResult(new RegistrationResponse
                    {
                        Result = false,
                        Errors = lIsCreated.Errors.Select(x => x.Description).ToList()
                    }
                ) {StatusCode = 500};
            }

            return BadRequest(new RegistrationResponse
            {
                Result = false,
                Errors = new List<string> {"Invalid payload"}
            });
        }

        [HttpPost]
        [Route("Login", Name = nameof(Login))]
        public async Task<IActionResult> Login([FromBody] UserLogin aUser)
        {
            if (ModelState.IsValid)
            {
                // check if the user with the same email exist
                var lExistingUser = await mUserManager.FindByNameAsync(aUser.Email);

                if (lExistingUser == null)
                    // We dont want to give to much information on why the request has failed for security reasons
                    return BadRequest(new AuthResult
                    {
                        Result = false,
                        Errors = new List<string> {"Invalid authentication request"}
                    });

                // Now we need to check if the user has inputed the right password
                var lIsCorrect = await mUserManager.CheckPasswordAsync(lExistingUser, aUser.Password);

                if (lIsCorrect)
                {
                    var lJwtToken = await GenerateJwtToken(lExistingUser);

                    return Ok(new AuthResult
                    {
                        Result = true,
                        Token = lJwtToken
                    });
                }

                // We dont want to give to much information on why the request has failed for security reasons
                return BadRequest(new AuthResult
                {
                    Result = false,
                    Errors = new List<string> {"Invalid authentication request"}
                });
            }

            return BadRequest(new AuthResult
            {
                Result = false,
                Errors = new List<string> {"Invalid payload"}
            });
        }

        private async Task<string> GenerateJwtToken(IdentityUser aUser)
        {
            var lJwtTokenHandler = new JwtSecurityTokenHandler();

            // We get our secret from the appsettings
            var lKey = Encoding.ASCII.GetBytes(mJwtConfig.Secret);

            // we define our token descriptor
            // We need to utilise claims which are properties in our token which gives information about the token
            // which belong to the specific user who it belongs to
            // so it could contain their id, name, email the good part is that these information
            // are generated by our server and identity framework which is valid and trusted

            var lClaims = new List<Claim>
            {
                new("Id", aUser.Id),
                new(JwtRegisteredClaimNames.Sub, aUser.Email),
                new(JwtRegisteredClaimNames.Email, aUser.Email),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var lUserClaims = await mUserManager.GetClaimsAsync(aUser);
            lClaims.AddRange(lUserClaims);

            var lTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(lClaims),
                // the life span of the token needs to be shorter and utilise refresh token to keep the user signedin
                // but since this is a demo app we can extend it to fit our current need
                Expires = DateTime.UtcNow.AddHours(6),
                // here we are adding the encryption alogorithim information which will be used to decrypt our token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(lKey),
                    SecurityAlgorithms.HmacSha512Signature)
            };

            var lToken = lJwtTokenHandler.CreateToken(lTokenDescriptor);
            var lJwtToken = lJwtTokenHandler.WriteToken(lToken);

            return lJwtToken;
        }
    }
}