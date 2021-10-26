using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductModel
    {
        // String ID to store ID property from products.json attribute
        public string Id { get; set; }

        // String Maker to store Maker property from products.json attribute 
        public string Maker { get; set; }

        // Customizing JSON property name "img", and using String Image to store the img property from products.json attribute 
        [JsonPropertyName("img")]
        public string Image { get; set; }

        // String URL
        public string Url { get; set; }

        // String Title
        public string Title { get; set; }

        // String Description
        public string Description { get; set; }

        // Int array Ratings
        public int[] Ratings { get; set; }

        // Override ToString() method
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);

 
    }
}