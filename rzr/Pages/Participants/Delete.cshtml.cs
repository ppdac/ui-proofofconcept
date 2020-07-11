﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using rzr.Data;
using rzr.Models;

namespace rzr.Pages.Participants
{
    public class DeleteModel : PageModel
    {
        private readonly rzr.Data.rzrContext _context;

        public DeleteModel(rzr.Data.rzrContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Participant Participant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Participant = await _context.Participant.FirstOrDefaultAsync(m => m.Id == id);

            if (Participant == null)
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

            Participant = await _context.Participant.FindAsync(id);

            if (Participant != null)
            {
                _context.Participant.Remove(Participant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
