﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PicComputers.Models
{
    public class ProductPropertyValue
    {
        [Key]
        [Required]
        public int ProductPropertyValueId { get; set; }
        
        [Required]
        public string Key { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public int ProductPropertyId { get; set; }

        [NotMapped]
        public bool isSelected { get; set; } = false;

        public ProductProperty ProductProperty { get; set; }

        public ICollection<ProductPropertyMap> ProductPropertyMaps { get; set; } = new HashSet<ProductPropertyMap>();
    }
}
