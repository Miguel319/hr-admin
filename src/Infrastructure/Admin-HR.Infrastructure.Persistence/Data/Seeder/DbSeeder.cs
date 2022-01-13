using System;
using System.Linq;
using System.Threading.Tasks;
using Admin_HR.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Admin_HR.Infrastructure.Persistence.Data.Seeder
{
    public class DbSeeder
    {
        public static async Task SeedData(DataContext context, UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                Console.WriteLine("text");

                foreach (var user in UserData.GetUserData())
                {
                    Console.WriteLine("User created");
                    
                    await userManager.CreateAsync(user, "P4ssw0rd!");
                }
            }

            if (context.Departments.Any()) return;

            var departmentData = DepartmentData.GetDepartments();

            await context.Departments.AddRangeAsync(departmentData);
            await context.SaveChangesAsync();
        }
    }
}