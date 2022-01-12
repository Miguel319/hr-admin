using Admin_HR.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Admin_HR.Infrastructure.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) {}

        public DbSet<Department> Departments { get; set; }
    }
}