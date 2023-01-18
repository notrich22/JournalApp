using JournalApiApp.Model.Entities.Journal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace JournalWebApplication.Pages.UnauthorizedMethods
{
    public class GetLessonsModel : PageModel
    {
        private readonly JournalApiApp.Model.JournalDbContext _context;

        public GetLessonsModel(JournalApiApp.Model.JournalDbContext context)
        {
            _context = context;
        }

        public IList<Lesson> Lesson { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Lessons != null)
            {
                Lesson = await _context.Lessons.Include(n => n.group).Include(n => n.subject).ToListAsync();
            }
        }
    }
}
