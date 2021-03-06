using System;

namespace Admin_HR.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public double Salary { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public Department Department { get; set; }
        public Position Position { get; set; }
        public DateTime HireDate { get; set; }
    }
}