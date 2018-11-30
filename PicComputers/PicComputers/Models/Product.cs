using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PicComputers.Models
{
    public class Product
    {
        [Required]
        public int ProductId { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        //public string Image { get; set; }

        [DataType(DataType.Currency)]
        [Required]
        public float Price { get; set; }

        [Required]
        public ProductCategory Category { get; set; }

        public IList<ProductProperty> PropertyValues { get; set; }
    }
}
