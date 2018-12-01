using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PicComputers.Models
{
    public class ProductCategory
    {
        [Key]
        [Required]
        public int ProductCategoryId { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Key { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
