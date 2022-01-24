using System;
using System.Collections.Generic;
using Admin_HR.Domain.Entities;

namespace Admin_HR.Infrastructure.Persistence.Data
{
    internal static class DepartmentData
    {
        public static IEnumerable<Department> GetDepartments()
            => new List<Department>()
            {
                new()
                {
                    Name = "Human Resource",
                    Code = "HR-231",
                    CreatedAt = DateTime.Now.AddDays(-5),
                    UpdatedAt = DateTime.Now.AddDays(-5),
                },
                new()
                {
                    Name = "Marketing",
                    Code = "Mk-356",
                    CreatedAt = DateTime.Now.AddDays(-23),
                    UpdatedAt = DateTime.Now.AddDays(-23)
                },
                new()
                {
                    Name = "Accounting and Finance",
                    Code = "Acc-Fin-125",
                    CreatedAt = DateTime.Now.AddDays(-2),
                    UpdatedAt = DateTime.Now.AddDays(-2)
                },
                new()
                {
                    Name = "Operations",
                    Code = "Ops-896",
                    CreatedAt = DateTime.Now.AddDays(-35),
                    UpdatedAt = DateTime.Now.AddDays(-35)
                },
                new()
                {
                    Name = "Sales",
                    Code = "Sales-481",
                    CreatedAt = DateTime.Now.AddHours(-14),
                    UpdatedAt = DateTime.Now.AddHours(-14)
                },
                new()
                {
                    Name = "Customer Service",
                    Code = "CS-782",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            };
    }
}