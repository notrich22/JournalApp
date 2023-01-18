using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JournalApiApp.Model;
using JournalApiApp.Model.Entities.Journal;

namespace JournalWebApplication.Pages.StudyGroupsCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly JournalApiApp.Model.JournalDbContext _context;

        public DetailsModel(JournalApiApp.Model.JournalDbContext context)
        {
            _context = context;
        }

      public StudyGroup StudyGroup { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.StudyGroups == null)
            {
                return NotFound();
            }

            var studygroup = await _context.StudyGroups.FirstOrDefaultAsync(m => m.Id == id);
            if (studygroup == null)
            {
                return NotFound();
            }
            else 
            {
                StudyGroup = studygroup;
            }
            return Page();
        }
    }
}
