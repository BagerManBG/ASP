using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PicComputers.Models
{
    public class Order
    {
        [Key]
        [Required]
        public int OrderId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required]
        public DateTime DatePlaced { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set;}

        [Required]
        [MaxLength(10), MinLength(10)]
        public string Phone { get; set; }

        [DataType(DataType.Currency)]
        [Required]
        public float TotalPrice { get; set; } = 0;

        [Required]
        public string CustomerId { get; set; }
        public ApplicationUser Customer { get; set; }        

        public ICollection<ProductOrderMap> ProductOrderMaps { get; set; } = new HashSet<ProductOrderMap>();
    }
}
