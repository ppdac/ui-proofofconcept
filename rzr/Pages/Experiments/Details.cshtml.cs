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
    public class DetailsModel : PageModel
    {
        private readonly rzr.Data.rzrContext _context;

        public DetailsModel(rzr.Data.rzrContext context)
        {
            _context = context;
        }

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
    }
}
