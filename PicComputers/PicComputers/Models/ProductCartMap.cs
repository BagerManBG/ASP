using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PicComputers.Models
{
    public class ProductCartMap
    {
        public ProductCartMap() { }

        public ProductCartMap(int productId, Product product, int cartId, Cart cart)
        {
            ProductId = productId;
            Product = product;
            CartId = cartId;
            Cart = cart;
        }

        [Required]
        public int ProductQuantity { get; set; } = 1;

        [DataType(DataType.Currency)]
        [NotMapped]
        public float ProductTotalPrice { get; set; } = 0;

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
