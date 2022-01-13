using System;
using Microsoft.AspNetCore.Identity;

namespace Admin_HR.Domain.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}