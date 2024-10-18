namespace tester_final.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public int HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }

        // Total amount calculated from HoursWorked and HourlyRate
        public decimal TotalAmount => HoursWorked * HourlyRate;
    }
}
