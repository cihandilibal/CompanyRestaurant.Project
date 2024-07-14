namespace Project.COREMVC.Areas.Admin.Models.Employees.PageVMs
{
    public class UpdateEmployeeVM
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Duty { get; set; }
        public string MobilePhone { get; set; }
        public string Address { get; set; }
        public int OffNumber { get; set; }
        public DateTime OffTime { get; set; }
    }
}

