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

namespace JournalWebApplication.Pages.StudentsCRUD
{
    public class EditModel : PageModel
    {
        private readonly JournalApiApp.Model.JournalDbContext _context;

        public EditModel(JournalApiApp.Model.JournalDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; } = default!;
        [BindProperty]
        public int StudyGroupId { get; set; } = default!;
        [BindProperty]
        public int UserId { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student =  await _context.Students.Include(n=>n.StudyGroup).Include(n=>n.User).FirstOrDefaultAsync(m => m.Id == id);
            StudyGroupId = student.StudyGroup.Id;
            UserId = student.User.Id;
            if (student == null)
            {
                return NotFound();
            }
            Student = student;
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
            
            
            try
            {
                Student.StudyGroup = await _context.StudyGroups.FirstOrDefaultAsync(n => n.Id == StudyGroupId);
                Student.User = await _context.Users.FirstOrDefaultAsync(n => n.Id == UserId);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(Student.Id))
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

        private bool StudentExists(int id)
        {
          return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
