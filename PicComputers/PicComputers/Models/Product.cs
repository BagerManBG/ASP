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
        [Key]
        [Required]
        public int ProductId { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        //public string Image { get; set; }

        [DataType(DataType.Currency)]
        [Required]
        public float Price { get; set; }

        public int? ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }

        public ICollection<ProductPropertyMap> ProductPropertyMaps { get; set; } = new HashSet<ProductPropertyMap>();
    }
}
