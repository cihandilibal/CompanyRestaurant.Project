using Project.ENTITIES.Enums;

namespace Project.COREMVC.Models.Categories.ResponseModels
{
    public class GetCategoriesResponseModel
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DataStatus Status { get; set; }

    }
}
