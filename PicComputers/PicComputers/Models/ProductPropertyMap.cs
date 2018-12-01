using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PicComputers.Models
{
    public class ProductPropertyMap
    {
        public ProductPropertyMap() { }

        public ProductPropertyMap(int productId, Product product, int productPropertyValueId, ProductPropertyValue productPropertyValue)
        {
            ProductId = productId;
            Product = product;
            ProductPropertyValueId = productPropertyValueId;
            ProductPropertyValue = productPropertyValue;
        }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ProductPropertyValueId { get; set; }
        public ProductPropertyValue ProductPropertyValue { get; set; }
    }
}
