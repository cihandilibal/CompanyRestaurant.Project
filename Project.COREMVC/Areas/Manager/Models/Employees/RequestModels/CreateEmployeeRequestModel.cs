namespace Project.COREMVC.Areas.Manager.Models.Employees.RequestModels
{
    public class CreateEmployeeRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Duty { get; set; }
        public string MobilePhone { get; set; }
        public string Address { get; set; }
        public int OffNumber { get; set; }
    }
}
