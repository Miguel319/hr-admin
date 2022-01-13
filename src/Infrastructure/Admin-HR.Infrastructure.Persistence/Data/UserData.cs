using System;
using System.Collections.Generic;
using Admin_HR.Domain.Entities;

namespace Admin_HR.Infrastructure.Persistence.Data
{
    public class UserData
    {
        public static List<User> GetUserData()
            => new List<User>()
            {
                new User()
                {
                    Name = "James",
                    Email = "james@email.com",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },  new User()
                {
                    Name = "Daniel",
                    Email = "daniel@email.com",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now

                },  new User()
                {
                    Name = "Ana",
                    Email = "ana@email.com",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
            };
    }
}