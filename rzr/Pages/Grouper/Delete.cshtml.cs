using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using rzr.Data;
using rzr.Models;

namespace rzr.Pages.Grouper
{
    public class DeleteModel : PageModel
    {
        private readonly rzr.Data.rzrContext _context;

        public DeleteModel(rzr.Data.rzrContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ExperimentParticipant ExperimentParticipant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? experimentId, int? participantId)
        {
            if (experimentId == null)
            {
                return NotFound();
            }

            ExperimentParticipant = await _context.ExperimentParticipant
                .Include(e => e.Experiment)
                .Include(e => e.Participant)
                .Where(m => m.ExperimentId == experimentId)
                .Where(m => m.ParticipantId == participantId)
                .SingleOrDefaultAsync();

            if (ExperimentParticipant == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? experimentId, int participantId)
        {
            if (experimentId == null)
            {
                return NotFound();
            }

            ExperimentParticipant = await _context.ExperimentParticipant
                .Include(e => e.Experiment)
                .Include(e => e.Participant)
                .Where(m => m.ExperimentId == experimentId)
                .Where(m => m.ParticipantId == participantId)
                .SingleOrDefaultAsync();

            if (ExperimentParticipant != null)
            {
                _context.ExperimentParticipant.Remove(ExperimentParticipant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
