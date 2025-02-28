using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidMatch.Infrastructure.Authorization
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HasPermissionAttribute : AuthorizeAttribute
    {
        public string Permission { get; }

        public HasPermissionAttribute(string permission)
        {
            Permission = permission;
        }
    }
}
