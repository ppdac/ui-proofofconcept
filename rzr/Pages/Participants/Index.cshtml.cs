using System;
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
    public class IndexModel : PageModel
    {
        private readonly rzr.Data.rzrContext _context;

        public IndexModel(rzr.Data.rzrContext context)
        {
            _context = context;
        }

        public IList<Participant> Participant { get;set; }

        public async Task OnGetAsync()
        {
            Participant = await _context.Participant.ToListAsync();
        }
    }
}
