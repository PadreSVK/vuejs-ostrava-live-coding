using log4net;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.PolicyHandlers
{
    public class MinimumAccessLevelRequirement : IAuthorizationRequirement
    { 
        public int AccessLevel { get; }

        public MinimumAccessLevelRequirement(int aAccessLevel) 
        {
            AccessLevel = aAccessLevel;
        }
    }
    public class AccessLevelHandler : AuthorizationHandler<MinimumAccessLevelRequirement>
    {
        private static readonly ILog mLog = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext aContext, MinimumAccessLevelRequirement aRequirement)
        {
            if (!aContext.User.Identity.IsAuthenticated)
                return Task.CompletedTask;

            int lAccessLevel;
            var lAccessLevelString = aContext.User.Claims.FirstOrDefault(a => a.Type == "AccessLevel").Value;

            try
            {
                lAccessLevel = Int32.Parse(lAccessLevelString);
            }
            catch (FormatException e) 
            {
                mLog.Error($"AccessLevel Format Error Exeption: {e}");
                return Task.CompletedTask;
            }

            if (lAccessLevel >= aRequirement.AccessLevel)
                aContext.Succeed(aRequirement);

            return Task.CompletedTask;

        }
    }
}
