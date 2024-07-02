using Project.ENTITIES.Models;

namespace Project.COREMVC.Models.Products.PageVM
{
    public class CreateProductPageVM
    {
        public List<Category> Categories { get; set; }
        public Product Product { get; set; }
    }
}
