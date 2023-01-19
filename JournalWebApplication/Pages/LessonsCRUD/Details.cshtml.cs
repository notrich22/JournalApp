using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JournalApiApp.Model;
using JournalApiApp.Model.Entities.Journal;

namespace JournalWebApplication.Pages.LessonsCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly JournalApiApp.Model.JournalDbContext _context;

        public DetailsModel(JournalApiApp.Model.JournalDbContext context)
        {
            _context = context;
        }

      public Lesson Lesson { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Lessons == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons.Include(n=>n.group).Include(n=>n.subject).FirstOrDefaultAsync(m => m.Id == id);
            if (lesson == null)
            {
                return NotFound();
            }
            else 
            {
                Lesson = lesson;
            }
            return Page();
        }
    }
}
