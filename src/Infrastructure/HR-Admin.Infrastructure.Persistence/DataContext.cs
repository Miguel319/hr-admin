using HR_Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR_Admin.Infrastructure.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) {}

        public DbSet<Department> Departments { get; set; }
    }
}