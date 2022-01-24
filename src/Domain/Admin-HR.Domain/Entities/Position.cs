using System;

namespace Admin_HR.Domain.Entities
{
    public class Position
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double MinSalary { get; set; }
        public double MaxSalary { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}