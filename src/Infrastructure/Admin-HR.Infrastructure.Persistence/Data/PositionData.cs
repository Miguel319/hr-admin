using System;
using System.Collections.Generic;
using Admin_HR.Domain.Entities;

namespace Admin_HR.Infrastructure.Persistence.Data
{
     internal static class PositionData
     {
         public static IEnumerable<Position> GetPositions() => new List<Position>()
         {
             new ()
             {
                Name = "Frontend Engineer",
                MinSalary = 60000,
                MaxSalary = 180000,
                CreatedAt = DateTime.Now.AddDays(-5),
                UpdatedAt = DateTime.Now.AddDays(-5),
             },
             new() 
             {
                Name = "Backend Engineer",
                MinSalary = 60000,
                MaxSalary = 180000,
                CreatedAt = DateTime.Now.AddDays(-42),
                UpdatedAt = DateTime.Now.AddDays(-42),
             },
             new()
             {
                 Name = "Business Analyst",
                 MinSalary = 50000,
                 MaxSalary = 105000,
                 CreatedAt = DateTime.Now.AddDays(-23),
                 UpdatedAt = DateTime.Now.AddDays(-23)
             },
             new()
             {
                 Name = "Customer Service Representative",
                 MinSalary = 35000,
                 MaxSalary = 65000,
                 CreatedAt = DateTime.Now,
                 UpdatedAt = DateTime.Now
             }
         };
     }
}