using Project.COREMVC.Models.Products.RequestModels;
using Project.COREMVC.Models.Products.ResponseModels;

namespace Project.COREMVC.Models.Products.PageVMs
{
    public class CreateProductPageVM
    {
        public CreateProductRequestModel CreateProductRequestModel { get; set; }
        public List<CategoryResponseModel> Categories { get; set; }
    } 
}

