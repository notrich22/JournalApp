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

namespace JournalWebApplication.Pages.NotesCRUD
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
        public Note Note { get; set; } = default!;
        [BindProperty]
        public int LessonId { get; set; } = default!;
        [BindProperty]
        public int StudentId { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //TODO: падает страница при вводе некорректного значения
          if (_context.Notes == null || Note == null) //  !ModelState.IsValid ||  
            {
                return Page();
            }
            try
            {
                Note.Student = await _context.Students.FirstOrDefaultAsync(n => n.Id == StudentId);
                Note.Lesson = await _context.Lessons.FirstOrDefaultAsync(n => n.Id == LessonId);
                _context.Notes.Add(Note);
                await _context.SaveChangesAsync();
            }catch(Exception ex) { return Page(); }
            return RedirectToPage("./Index");
        }
    }
}
