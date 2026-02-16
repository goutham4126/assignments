using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace ProductsApi.Models
{
    public class ProductItem
    {
        public int Id { get; set; }
        public string productName { get; set; }

        public string productType { get; set; }

        public string productDescription { get; set; }

        public decimal price { get; set; }


    }
}
