using log4net;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestApi.Model.DTO.Request;
using RestApi.Model.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        private static readonly ILog mLog = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly UserManager<IdentityUser> mUserManager;

        public ClaimController(UserManager<IdentityUser> aUserManager)
        {
            mUserManager = aUserManager;
        }

        [HttpPost]
        [Route("AddClaim")]
        //Multiple Claims with same key can be created
        public async Task<IActionResult> AddClaim([FromBody] ClaimRequest aClaimRequest)
        {
            var lUser = await mUserManager.FindByIdAsync(aClaimRequest.UserId);
            if (lUser == null)
            {
                mLog.Error($"User with set Id does not exist");
                return BadRequest(new DefaultResponse()
                {
                    Result = false,
                    Errors = new List<string>() { "Invalid payload" }
                });
            }

            try
            {
                await mUserManager.AddClaimAsync(lUser, new Claim(aClaimRequest.ClaimKey, aClaimRequest.ClaimValue));

                mLog.Info($"Claim:{aClaimRequest.ClaimKey} with value:{aClaimRequest.ClaimValue} was granted to User: {lUser.Email}");

                return Ok(new DefaultResponse()
                {
                    Result = true,
                });
            }
            catch (Exception e)
            {
                mLog.Error($"Claim: {aClaimRequest.ClaimKey} was not added to User: {lUser.Email} Exeption: {e}");
                return BadRequest(new DefaultResponse()
                {
                    Result = false,
                    Errors = new List<string>() { "Invalid payload", e.ToString() }
                });
            }
        }

        [HttpPost]
        [Route("AddOrUpdateClaim")]
        public async Task<IActionResult> AddOrUpdateClaim([FromBody] ClaimRequest aClaimRequest)
        {
            var lUser = await mUserManager.FindByIdAsync(aClaimRequest.UserId);
            if (lUser == null)
            {
                mLog.Error($"User with set Id does not exist");
                return BadRequest(new DefaultResponse()
                {
                    Result = false,
                    Errors = new List<string>() { "Invalid payload" }
                });
            }

            // Check if claim already exist and if so... you know what needs to be done.
            var lExistingClaims = await mUserManager.GetClaimsAsync(lUser);
            if (lExistingClaims.Any(a => a.Type == aClaimRequest.ClaimKey))
                await mUserManager.RemoveClaimsAsync(lUser, lExistingClaims.Where(a => a.Type == aClaimRequest.ClaimKey));

            // And know we have a clean slate to create unique claim, just the way we wanted 
            try
            {
                await mUserManager.AddClaimAsync(lUser, new Claim(aClaimRequest.ClaimKey, aClaimRequest.ClaimValue));
                mLog.Info($"Claim:{aClaimRequest.ClaimKey} with value:{aClaimRequest.ClaimValue} was Uptated to User: {lUser.Email}");

                return Ok(new DefaultResponse()
                {
                    Result = true,
                });
            }
            catch (Exception e)
            {
                mLog.Error($"Claim: {aClaimRequest.ClaimKey} was not added to User: {lUser.Email} Exeption: {e}");
                return BadRequest(new DefaultResponse()
                {
                    Result = false,
                    Errors = new List<string>() { "Invalid payload", e.ToString() }
                });
            }
        }

        [HttpPost]
        [Route("RemoveClaim")]
        public async Task<IActionResult> RemoveClaim([FromBody] ClaimRequest aClaimRequest)
        {
            var lUser = await mUserManager.FindByIdAsync(aClaimRequest.UserId);
            if (lUser == null)
            {
                mLog.Error($"User with set Id does not exist");
                return BadRequest(new DefaultResponse()
                {
                    Result = false,
                    Errors = new List<string>() { "Invalid payload" }
                });
            }

            try
            {
                await mUserManager.RemoveClaimAsync(lUser, new Claim(aClaimRequest.ClaimKey, aClaimRequest.ClaimValue));
                mLog.Info($"Claim:{aClaimRequest.ClaimKey} was Removed from User: {lUser.Email}");

                return Ok(new DefaultResponse()
                {
                    Result = true,
                });
            }
            catch (Exception e)
            {
                mLog.Error($"Claim: {aClaimRequest.ClaimKey} was not removed from User: {lUser.Email} Exeption: {e}");
                return BadRequest(new DefaultResponse()
                {
                    Result = false,
                    Errors = new List<string>() { "Invalid payload", e.ToString() }
                });
            }
        }
    }
}
