using JournalApiApp.Model.Entities.Journal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace JournalWebApplication.Pages.UnauthorizedMethods
{
    public class GetStudentsModel : PageModel
    {
        private readonly JournalApiApp.Model.JournalDbContext _context;

        public GetStudentsModel(JournalApiApp.Model.JournalDbContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Students != null)
            {
                Student = await _context.Students.Include(n => n.StudyGroup).ToListAsync();
            }
        }
    }
}
