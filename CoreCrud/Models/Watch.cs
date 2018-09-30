
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

        [Display(Name = "Brand Name")]
        [Required(ErrorMessage = "Please provide a name")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "2 - 100 characters only")]
        public string Brand { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Launch Date")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [CustomValidation(typeof(Watch), "LaunchDateInThePast")]
        public DateTime LaunchDate { get; set; }

        [Display(Name = "Is Analog")]
        public bool IsAnalog { get; set; }
        [Required]
        [Range(100, 999999, ErrorMessage = "Price must be between 100 and 20000")]

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Strap Material")]
        [Required(ErrorMessage = "Please provide a Material")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "2 - 100 characters only")]
        [CustomValidation(typeof(Watch), "CountWhenAnalog")]
        public string Material { get; set; }

        [Display(Name = "Quantity of watches")]
        [Required(ErrorMessage = "Please provide Quantity")]
        [Range(1, 500, ErrorMessage = "Price must be between 1 and 500")]
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


        public static ValidationResult CountWhenAnalog(string Material, ValidationContext context) {
            var instance = context.ObjectInstance as Watch;
            if (!Material.ToLower().Equals("steel") && !Material.ToLower().Equals("leather")) {
               return new ValidationResult($"This analog material can be either steel or leather only");
            }
            return ValidationResult.Success;
        }

        public static ValidationResult LaunchDateInThePast(DateTime? launchDate, ValidationContext context) {

            if (launchDate < DateTime.Today) {
                return ValidationResult.Success;
            }
            return new ValidationResult("Launch date must be in the past");
        }
    }
}
