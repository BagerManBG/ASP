using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PicComputers.Models
{
    public class Cart
    {        
        [Key]
        [Required]
        public int CartId { get; set; }

        [DataType(DataType.Currency)]
        [Required]
        public float TotalPrice { get; set; } = 0;

        [Required]
        public string UserId { get; set; }
        public ApplicationUser Customer { get; set; }
        
        public ICollection<ProductCartMap> ProductCartMaps { get; set; } = new HashSet<ProductCartMap>();        
    }
}
