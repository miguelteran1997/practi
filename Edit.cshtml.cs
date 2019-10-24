using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OffPractice.Data;

namespace OffPractice.Pages.Boot
{
    public class EditModel : PageModel
    {
        private readonly OffPractice.Data.ApplicationDbContext _context;

        public EditModel(OffPractice.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bootleg Bootleg { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bootleg = await _context.Bootleg.FirstOrDefaultAsync(m => m.BID == id);

            if (Bootleg == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bootleg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BootlegExists(Bootleg.BID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BootlegExists(int id)
        {
            return _context.Bootleg.Any(e => e.BID == id);
        }
    }
}
