using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JournalApiApp.Model;
using JournalApiApp.Model.Entities.Journal;

namespace JournalWebApplication.Pages.StudyGroupsCRUD
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
        public StudyGroup StudyGroup { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.StudyGroups == null || StudyGroup == null)
            {
                return Page();
            }

            _context.StudyGroups.Add(StudyGroup);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
