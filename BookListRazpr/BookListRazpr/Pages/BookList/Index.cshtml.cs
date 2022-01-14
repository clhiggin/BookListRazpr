using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazpr.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazpr.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Books> MoreBooks { get; set; }
        public async Task OnGet()
        {
            MoreBooks = await _db.Books.ToListAsync();
        }
    }
}
