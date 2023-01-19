using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JournalApiApp.Model;
using JournalApiApp.Model.Entities.Journal;

namespace JournalWebApplication.Pages.LessonsCRUD
{
    public class EditModel : PageModel
    {
        private readonly JournalApiApp.Model.JournalDbContext _context;

        public EditModel(JournalApiApp.Model.JournalDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lesson Lesson { get; set; } = default!;
        [BindProperty]
        public int StudyGroupId { get; set; } = default!;
        [BindProperty]
        public int SubjectId { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Lessons == null)
            {
                return NotFound();
            }

            var lesson =  await _context.Lessons.Include(n=>n.subject).Include(n=>n.group).FirstOrDefaultAsync(m => m.Id == id);
            if (lesson == null)
            {
                return NotFound();
            }
            StudyGroupId = lesson.group.Id;
            SubjectId = lesson.subject.Id;
            Lesson = lesson;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            /*if (!ModelState.IsValid)
            {
                return Page();
            }*/
            Lesson.dateTime = Lesson.dateTime.ToUniversalTime();
            _context.Attach(Lesson).State = EntityState.Modified;

            try
            {
                Lesson.group = await _context.StudyGroups.FirstOrDefaultAsync(n => n.Id == StudyGroupId);
                Lesson.subject = await _context.Subjects.FirstOrDefaultAsync(n => n.Id == SubjectId);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonExists(Lesson.Id))
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

        private bool LessonExists(int id)
        {
          return (_context.Lessons?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
