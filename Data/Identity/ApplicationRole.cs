using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Crossways.Data.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}