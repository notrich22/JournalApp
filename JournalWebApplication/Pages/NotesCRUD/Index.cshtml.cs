using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JournalApiApp.Model;
using JournalApiApp.Model.Entities.Journal;
using Microsoft.AspNetCore.Authorization;

namespace JournalWebApplication.Pages.NotesCRUD
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly JournalApiApp.Model.JournalDbContext _context;

        public IndexModel(JournalApiApp.Model.JournalDbContext context)
        {
            _context = context;
        }

        public IList<Note> Note { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Notes != null)
            {
                Note = await _context.Notes.ToListAsync();
            }
        }
    }
}
