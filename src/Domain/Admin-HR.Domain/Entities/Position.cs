namespace Admin_HR.Domain.Entities
{
    public class Position : BaseEntity
    {
        public string Name { get; set; }
        public double MinSalary { get; set; }
        public double MaxSalary { get; set; }
    }
}