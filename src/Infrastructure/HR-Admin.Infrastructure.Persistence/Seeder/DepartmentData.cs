using System.Collections.Generic;
using HR_Admin.Domain.Entities;

namespace HR_Admin.Infrastructure.Persistence.Seeder
{
    class DepartmentData
    {
        public static List<Department> GetDepartments()
            => new List<Department>()
            {
                new()
                {
                    Name = "Human Resource",
                    Code = "HR-231"
                },
                new()
                {
                    Name = "Marketing",
                    Code = "Mk-356"
                },
                new()
                {
                    Name = "Accounting and Finance",
                    Code = "Acc-Fin-125"
                },
                new()
                {
                    Name = "Operations",
                    Code = "Ops-896"
                },
                new()
                {
                    Name = "Sales",
                    Code = "Sales-481"
                },
                new()
                {
                    Name = "Customer Service",
                    Code = "CS-782"
                }
            };
    }
}