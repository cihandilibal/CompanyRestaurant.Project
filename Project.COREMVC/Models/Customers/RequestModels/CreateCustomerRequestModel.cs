namespace Project.COREMVC.Models.Customers.RequestModels
{
    public class CreateCustomerRequestModel
    {
       public int ID { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public string MobilePhone { get; set; }
    }
}
