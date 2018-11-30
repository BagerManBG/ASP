using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PicComputers.Models
{
    public class Order
    {
        [Required]
        public int ID { get; set; }
    }
}
