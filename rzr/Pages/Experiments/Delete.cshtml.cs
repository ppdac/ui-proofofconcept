using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using rzr.Data;
using rzr.Models;

namespace rzr.Pages.Experiments
{
    public class DeleteModel : PageModel
    {
        private readonly rzr.Data.rzrContext _context;

        public DeleteModel(rzr.Data.rzrContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Experiment Experiment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Experiment = await _context.Experiment.FirstOrDefaultAsync(m => m.Id == id);

            if (Experiment == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Experiment = await _context.Experiment.FindAsync(id);

            if (Experiment != null)
            {
                _context.Experiment.Remove(Experiment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
