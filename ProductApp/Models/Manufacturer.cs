using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductApp.Models
{
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }
        [Required]
        [StringLength(100)]
        public string ManufacturerName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}