using BookList3._1.Data;
using BookList3._1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BookList3._1.RazorPages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;

        }

        [BindProperty]
        public Book Book { get; set; }  
        public async Task OnGet(int id)
        {
           Book =  _context.books.Find(id);
            
            

        }
        public async Task<IActionResult> OnPost() {

            if (ModelState.IsValid)
            {
               var  CurrentBook = _context.books.Find(Book.Id);

                CurrentBook.Name = Book.Name;
                CurrentBook.Author = Book.Author;
                CurrentBook.ISBN = Book.ISBN;

                await _context.SaveChangesAsync();



                return RedirectToPage("Index");

            }
            else
            {
                return Page();
            }

        
        }




    }
}
