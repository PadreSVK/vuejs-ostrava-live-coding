using log4net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestApi.Model.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class UserManagementController : ControllerBase
    {
        private static readonly ILog mLog = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly UserManager<IdentityUser> mUserManager;
        public UserManagementController(UserManager<IdentityUser> aUserManager)
        {
            mUserManager = aUserManager;
        }

        [HttpGet]
        [Authorize(Policy = "IsAdmin")]
        [Route("GetUserList")]
        public async Task<IActionResult> GetUserList()
        {
            mLog.Info($"GetUserList Request recieved...");

            var lUserList = mUserManager.Users.ToList();

            var lUserResponseList = new List<UserResponse>();

            foreach (var lUser in lUserList)
            {
                var lClamDescList = new List<ClaimDesc>();

                var lUserClaimList = await mUserManager.GetClaimsAsync(lUser);
                foreach (var lUserClaim in lUserClaimList)
                {
                    var lClaim = new ClaimDesc(lUserClaim.Type, lUserClaim.Value);
                    lClamDescList.Add(lClaim);
                }

                lUserResponseList.Add(new UserResponse(lUser.Id, lUser.Email, lClamDescList));
            }

            mLog.Info($"GetUserList Done sending response.");
            //return lUserResponseList;
            return Ok(new UserListResponse()
            {
                Result = true,
                UserList = lUserResponseList.ToList()
            });
        }

        [HttpGet]
        [Authorize(Policy = "IsAdmin")]
        [Route("GetUserById")]
        public async Task<IActionResult> GetUserById(string aId)
        {
            mLog.Info($"GetUserList Request recieved...");

            var lUser = await mUserManager.FindByIdAsync(aId);

            var lUserResponseList = new List<UserResponse>();

            var lClamDescList = new List<ClaimDesc>();

            var lUserClaimList = await mUserManager.GetClaimsAsync(lUser);
            foreach (var lUserClaim in lUserClaimList)
            {
                var lClaim = new ClaimDesc(lUserClaim.Type, lUserClaim.Value);
                lClamDescList.Add(lClaim);
            }

            mLog.Info($"GetUserList Done sending response.");
            //return lUserResponseList;
            return Ok(new UserResponse()
            {
                Result = true,
                Email = lUser.Email,
                UserId = lUser.Id,
                UserClaimList = lClamDescList
            });
        }

        [HttpPost]
        [Authorize(Policy = "IsAdmin")]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword()
        {
            return BadRequest(new DefaultResponse()
            {
                Result = false,
                Errors = new List<string>() { "Invalid payload" }
            });
        }
    }
}
