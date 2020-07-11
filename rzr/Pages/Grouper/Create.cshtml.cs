using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using rzr.Data;
using rzr.Models;

namespace rzr.Pages.Grouper
{
    public class CreateModel : PageModel
    {
        private readonly rzr.Data.rzrContext _context;
        public IList<Participant> Participants { get; set; }
        public IList<ExperimentParticipant> ExperimentParticipants { get; set; }
        public IList<Participant> freeParticipants;
        public CreateModel(rzr.Data.rzrContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Participants = _context.Participant.ToList();
            ExperimentParticipants = _context.ExperimentParticipant.ToList();

            //Needs .ToList() to avoid throwing "InvalidOperationException: Collection was modified; enumeration operation may not execute."
            //There's probably a better solution, see: https://stackoverflow.com/a/26864676/434034
            freeParticipants = Participants.ToList();

            foreach (var ep in ExperimentParticipants)
            {
                foreach (var p in Participants)
                {
                    if (ep.ParticipantId == p.Id)
                    {
                        freeParticipants.Remove(p);
                    }
                }
            }


            ViewData["ExperimentId"] = new SelectList(_context.Experiment, "Id", "Title");
            ViewData["ParticipantId"] = new SelectList(freeParticipants, "Id", "NameNumber");

            return Page();
        }

        [BindProperty]
        public ExperimentParticipant ExperimentParticipant { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ExperimentParticipant.Add(ExperimentParticipant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
