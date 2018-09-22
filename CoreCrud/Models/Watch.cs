
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        
        [NotMapped]
        public string PriceRange{
            get{
                if(Price < 500){
                    return "Low Range";
                }
                else if (Price >= 500 && Price <= 999){
                    return "Mid Range";
                }
                else{
                    return "High Range";
                }
            }
        }

    }
}
