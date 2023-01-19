using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JournalApiApp.Model;
using JournalApiApp.Model.Entities.Journal;
using Microsoft.EntityFrameworkCore;

namespace JournalWebApplication.Pages.LessonsCRUD
{
    public class CreateModel : PageModel
    {
        private readonly JournalApiApp.Model.JournalDbContext _context;

        public CreateModel(JournalApiApp.Model.JournalDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Lesson Lesson { get; set; } = default!;
        [BindProperty]
        public int StudyGroupId { get; set; } = default!;
        [BindProperty]
        public int SubjectId { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (_context.Lessons == null || Lesson == null)// !ModelState.IsValid || 
            {
                return Page();
            }
            
            Lesson.group = await _context.StudyGroups.FirstOrDefaultAsync(n => n.Id == StudyGroupId);
            Lesson.subject = await _context.Subjects.FirstOrDefaultAsync(n => n.Id == SubjectId);
            Lesson.dateTime = Lesson.dateTime.ToUniversalTime();
            _context.Lessons.Add(Lesson);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
