using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public string SearchString { get; set; }
        public SelectList Book { get; set; }
        public string ScriptureBook { get; set; }

        public async Task OnGetAsync(string scriptureBook, string searchString)
        {
            // Use LINQ to get list of books.
            IQueryable<string> bookQuery = from m in _context.Scripture
                                            orderby m.Book
                                            select m.Book;
            
            // using System.Linq to select the scriptures;
            var scriptures = from m in _context.Scripture
                             select m;

            if(!String.IsNullOrEmpty(searchString))
            {
                scriptures = scriptures.Where(s => s.Book.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(scriptureBook))
            {
                scriptures = scriptures.Where(x => x.Book == scriptureBook);
            }
            Book = new SelectList(await bookQuery.Distinct().ToListAsync());
            Scripture = await scriptures.ToListAsync();
            SearchString = searchString;
        }
    }
}
