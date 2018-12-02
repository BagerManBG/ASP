using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PicComputers.Models
{
    public class ProductOrderMap
    {
        public ProductOrderMap() { }

        public ProductOrderMap(int productId, Product product, int orderId, Order order)
        {
            ProductId = productId;
            Product = product;
            OrderId = orderId;
            Order = order;
        }

        [Required]
        public int ProductQuantity { get; set; } = 1;

        [DataType(DataType.Currency)]
        [NotMapped]
        public float ProductTotalPrice { get; set; } = 0;

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
