using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JournalApiApp.Model;
using JournalApiApp.Model.Entities.Journal;

namespace JournalWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        public int Id { get; set; }
        public async Task OnGetAsync()
        {

        }
    }
}
