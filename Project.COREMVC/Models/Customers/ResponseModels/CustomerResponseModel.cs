using Project.ENTITIES.Enums;

namespace Project.COREMVC.Models.Customers.ResponseModels
{
    public class CustomerResponseModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }
        public DataStatus Status { get; set; }
    }
}
