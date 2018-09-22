using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoreCrud.Models;

namespace CoreCrud.Pages
{
    public class IndexModel : PageModel
    {
    private AppDbContext _context;

    public int TotalDigitalBrands { get; set;}
    public int TotalAnalogBrands { get; set; }
    public int TotalLeatherWatches { get; set; }

    public int TotalSteelWatches { get; set;}

    public int TotalBrands { get; set; } 
    public IndexModel(AppDbContext context)
        {
            _context = context;
        }

    public void OnGet()
        {
            TotalAnalogBrands = _context.WatchContext.Where(x => x.IsAnalog == true).Count();
            TotalDigitalBrands = _context.WatchContext.Where(y => y.IsAnalog == false).Count();
            TotalLeatherWatches = _context.WatchContext.Where(l => l.Material == "Leather").Count();
            TotalSteelWatches = _context.WatchContext.Where(h => h.Material == "Steel").Count();
            TotalBrands = _context.WatchContext.Count();
        }
    }
}
