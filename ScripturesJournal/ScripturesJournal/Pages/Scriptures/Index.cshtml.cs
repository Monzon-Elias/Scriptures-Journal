using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScripturesJournal.Models;

namespace ScripturesJournal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly ScripturesJournal.Models.ScripturesJournalContext _context;

        public IndexModel(ScripturesJournal.Models.ScripturesJournalContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; }

        public async Task OnGetAsync()
        {
            Scripture = await _context.Scripture.ToListAsync();
        }
    }
}
