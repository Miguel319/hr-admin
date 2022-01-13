using System.Linq;
using System.Threading.Tasks;

namespace Admin_HR.Infrastructure.Persistence.Data.Seeder
{
    public class DbSeeder
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Departments.Any()) return;

            var departmentData = DepartmentData.GetDepartments();

            await context.Departments.AddRangeAsync(departmentData);
            await context.SaveChangesAsync();
        }
    }
}