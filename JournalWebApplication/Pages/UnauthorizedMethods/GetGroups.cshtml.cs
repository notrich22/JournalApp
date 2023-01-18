using JournalApiApp.Model.Entities.Journal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace JournalWebApplication.Pages.UnauthorizedMethods
{
    public class GetGroupsModel : PageModel
    {
        private readonly JournalApiApp.Model.JournalDbContext _context;
        public IList<StudyGroup> StudyGroup { get; set; } = default!;
        public GetGroupsModel(JournalApiApp.Model.JournalDbContext context)
        {
            _context = context;
        }
        public async Task OnGetAsync()
        {
            if (_context.StudyGroups != null)
            {
                StudyGroup = await _context.StudyGroups.ToListAsync();
            }
        }
    }
}
