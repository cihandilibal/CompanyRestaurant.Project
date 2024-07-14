using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Project.COREMVC.CustomTagHelper
{
    [HtmlTargetElement("a", Attributes = "order-id,product-id")]
    
    public class MyTagHelper : TagHelper
    {
            public int OrderId { get; set; }
            public int ProductId { get; set; }
            

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
                output.Attributes.SetAttribute("asp-route-orderId", OrderId);
                output.Attributes.SetAttribute("asp-route-productId", ProductId);
            
        }
       
    }
}
