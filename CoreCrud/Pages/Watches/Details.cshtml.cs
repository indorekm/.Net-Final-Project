using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoreCrud.Models;

namespace CoreCrud.Pages.Watches
{
    public class DetailsModel : PageModel
    {
        private readonly CoreCrud.Models.AppDbContext _context;

        public DetailsModel(CoreCrud.Models.AppDbContext context)
        {
            _context = context;
        }

        public Watch Watch { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Watch = await _context.WatchContext
                .Include(w => w.Manufacturer).FirstOrDefaultAsync(m => m.Id == id);

            if (Watch == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
