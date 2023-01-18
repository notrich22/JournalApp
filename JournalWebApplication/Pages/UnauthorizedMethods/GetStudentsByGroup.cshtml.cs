using JournalApiApp.Model.Entities.Journal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace JournalWebApplication.Pages.UnauthorizedMethods
{
    public class GetStudentsByGroupModel : PageModel
    {
        private readonly JournalApiApp.Model.JournalDbContext _context;

        public GetStudentsByGroupModel(JournalApiApp.Model.JournalDbContext context, IList<Student> students = null)
        {
            _context = context;
            Student = students;
        }

        public IList<Student> Student { get; set; } = default!;
        [BindProperty]
        public int GroupId { get; set; } = default!;

        public async Task OnGetAsync()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Student = await _context.Students.Include(n=>n.StudyGroup).Where(n=>n.StudyGroup.Id==GroupId).ToListAsync();
            return Page();
        }
    }
}
