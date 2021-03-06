﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PicComputers.Models
{
    public class ProductProperty
    {
        [Key]
        [Required]
        public int ProductPropertyId { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Key { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        public ICollection<ProductPropertyValue> Values { get; set; } = new HashSet<ProductPropertyValue>();
    }
}
