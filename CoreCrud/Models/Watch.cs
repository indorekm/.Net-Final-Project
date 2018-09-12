
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreCrud.Models
{
    public class Watch
    {
        public int Id { get; set; }

        public string Brand { get; set; }
        public DateTime LaunchDate { get; set; }
        public bool IsAnalog { get; set; }
        public decimal Price { get; set; }
        public string Material { get; set; }

        public int? Quantity { get; set;}

        public int ManufacturerId { get; set; }


        public Manufacturer Manufacturer { get; set;}

    }
}
