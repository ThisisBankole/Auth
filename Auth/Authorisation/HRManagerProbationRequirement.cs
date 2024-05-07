using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Auth.Authorisation;

public class HRManagerProbationRequirement: IAuthorizationRequirement
{
    public HRManagerProbationRequirement( int probationMonths)
    {
        ProbationMonths = probationMonths;
    }
    public int ProbationMonths { get; }

    public class HRManagerProbationRequirementHandler : AuthorizationHandler<HRManagerProbationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HRManagerProbationRequirement requirement)
        {
           if (!context.User.HasClaim( c => c.Type == "StartDate"))
                return Task.CompletedTask;
            
            var startDate = DateTime.Parse(context.User.FindFirst(c => c.Type == "StartDate").Value);
            var period = DateTime.Now - startDate;

            if(period.Days > requirement.ProbationMonths * 30)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;

        }
    }

}
