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

namespace JournalWebApplication.Pages.StudentsCRUD
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
        public Student Student { get; set; } = default!;
        [BindProperty]
        public int StudyGroupId { get; set; } = default!;
        [BindProperty]
        public int UserId { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if ( _context.Students == null || Student == null) //!ModelState.IsValid ||
            {
                return Page();
            }
            Student.StudyGroup = await _context.StudyGroups.FirstOrDefaultAsync(n => n.Id == StudyGroupId);
            Student.User = await _context.Users.FirstOrDefaultAsync(n => n.Id == UserId);

            _context.Students.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
