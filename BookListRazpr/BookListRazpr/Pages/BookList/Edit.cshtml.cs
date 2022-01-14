using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazpr.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazpr.Pages.BookList

{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Books Books { get; set; }

        public async Task OnGet(int id)
        {
            Books = await _db.Books.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BooksFromDb = await _db.Books.FindAsync(Books.Id);
                BooksFromDb.Name = Books.Name;
                BooksFromDb.ISBN = Books.ISBN;
                BooksFromDb.Author = Books.Author;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}