using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PicComputers.Models
{
    public class ProductPropertyValue
    {
        [Required]
        public int ProductPropertyValueId { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public int ProductPropertyId { get; set; }

        public ProductProperty ProductProperty { get; set; }
    }
}
