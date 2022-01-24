using System;

namespace Admin_HR.Domain.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}