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
    public class UpsertModel : PageModel
    {
        private ApplicationDbContext _db;

        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Books Books { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            Books = new Books();
            if (id == null)
            {
                //create
                return Page();
            }

            //update
            Books = await _db.Books.FirstOrDefaultAsync(u => u.Id == id);
            if (Books == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                if (Books.Id == 0)
                {
                    _db.Books.Add(Books);
                }
                else
                {
                    _db.Books.Update(Books);
                }

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }

    }
}

