namespace tester_final.Models.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
