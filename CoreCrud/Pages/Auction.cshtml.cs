using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CoreCrud.Pages
{
    public class AuctionModel : PageModel
    {
        
        private AppDbContext _context;
        
        public AuctionModel(AppDbContext context) {
            _context = context;
        }

        public ICollection<Watch> Watches { get; set; }
        public void OnGet()
        {
            Watches = _context.WatchContext.Include(y => y.Manufacturer).OrderBy(x => x.Id).ToList();
        }
    }
}