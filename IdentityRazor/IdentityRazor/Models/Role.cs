using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityRazor.Models
{
    public class Role : IdentityRole
    {
        public Role() : base() { }

        public Role(string RoleName) : base(RoleName) { }

        public Role(string RoleName, string description, DateTime creationDate) 
            : base(RoleName)
        {
            Description = description;
            CreationDate = creationDate;            
        }

        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
