using System.Linq;
using System.Threading.Tasks;
using Admin_HR.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Admin_HR.Infrastructure.Persistence.Data.Seeder
{
    public static class DbSeeder
    {
        private static async Task SeedDepartments(DataContext context)
        {
            if (!context.Departments.Any())
            {
                var departmentData = DepartmentData.GetDepartments();

                await context.Departments.AddRangeAsync(departmentData);
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedPositions(DataContext context)
        {
            if (!context.Positions.Any())
            {
                var positionsData = PositionData.GetPositions();

                await context.Positions.AddRangeAsync(positionsData);
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedUsers(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                foreach (var user in UserData.GetUserData())
                    await userManager.CreateAsync(user, "P4ssw0rd!");
            }
        }

        public static async Task SeedData(DataContext context, UserManager<User> userManager)
        {
            await SeedUsers(userManager);

            await SeedPositions(context);
            
            await SeedDepartments(context);
        }
    }
}