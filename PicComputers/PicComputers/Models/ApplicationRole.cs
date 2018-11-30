using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicComputers.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base () { }

        public ApplicationRole(string RoleName) : base(RoleName) { }

        public ApplicationRole(string RoleName, string description)
            : base(RoleName)
        {
            Description = description;
        }

        public string Description { get; set; }
    }
}

