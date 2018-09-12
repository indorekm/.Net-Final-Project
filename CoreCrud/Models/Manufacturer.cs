
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreCrud.Models
{
    public class Manufacturer
    {
       public int Id { get; set; }
        
       public string Name { get; set;}

       public string Location { get; set;}
       
       public ICollection<Watch> Watch { get; set;}

    }
}
            