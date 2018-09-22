using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoreCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreCrud.Pages
{
    public class ManufacturerProfileModel : PageModel
    {
        
        private AppDbContext _context;
        
        public ManufacturerProfileModel(AppDbContext context) {
            _context = context;
        }

        public Manufacturer Manufacturer { get; set; }

        
        public ICollection<Watch> Watches { get; set; }

        public IActionResult OnGet(int? id)
        {   
            if(id == null){
                return NotFound();
            }
  try{
            Manufacturer = _context.ManufacturerContext.Where(mft => mft.Id == id).First();
          
          
            Watches = _context.WatchContext.Include(x => x.Manufacturer).Where(y => y.Manufacturer.Id == id).ToList();
            return Page();
            
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return NotFound();
            }
        }
    }

}