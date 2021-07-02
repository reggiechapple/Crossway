using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Crossways.Data.Domain;
using Microsoft.AspNetCore.Identity;

namespace Crossways.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

        [Required]
        // [Range(DataConstants.MinUserAge, DataConstants.MaxUserAge)]
        public int Age { get; set; }

        public bool IsOnline { get; set; } = false;

        public bool IsDeleted { get; set; } = false;

        public ICollection<Reply> Replies { get; set; } = new List<Reply>();
        
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}