using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BidMatch.Infrastructure.Authorization
{
    //[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    //public class HasPermissionAttribute : AuthorizeAttribute, IAuthorizationFilter
    //{
    //    private readonly string _requiredPermission;

    //    public HasPermissionAttribute(string requiredPermission)
    //    {
    //        _requiredPermission = requiredPermission.ToLower();
    //    }

    //    public void OnAuthorization(AuthorizationFilterContext context)
    //    {
    //        var user = context.HttpContext.User;
    //        if (user == null || !user.Identity.IsAuthenticated)
    //        {
    //            context.Result = new UnauthorizedResult();
    //            return;
    //        }

    //        // Get the current user ID from JWT Claims
    //        var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    //        if (string.IsNullOrEmpty(userId))
    //        {
    //            context.Result = new ForbidResult();
    //            return;
    //        }

    //        // Get User Permissions from Database
    //        var dbContext = context.HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>();
    //        var userPermissions = dbContext.UserRoles
    //            .Where(ur => ur.UserId == Guid.Parse(userId))
    //            .SelectMany(ur => ur.Role.RolePermissions)
    //            .Select(rp => rp.Permission.Code)
    //            .ToList();

    //        // Check if the user has the required permission
    //        if (!userPermissions.Contains(_requiredPermission))
    //        {
    //            context.Result = new ForbidResult();
    //            return;
    //        }
    //    }
    //}

}
