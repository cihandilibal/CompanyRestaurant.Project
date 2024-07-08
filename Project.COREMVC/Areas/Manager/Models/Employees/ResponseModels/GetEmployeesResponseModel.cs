namespace Project.COREMVC.Areas.Manager.Models.Employees.ResponseModels
{
    public class GetEmployeesResponseModel
    {   
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Duty { get; set; }
        public string MobilePhone { get; set; }
        public string Address { get; set; }
        public int OffNumber { get; set; }
    }
}
