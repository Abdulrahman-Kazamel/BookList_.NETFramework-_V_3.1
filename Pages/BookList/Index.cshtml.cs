using BookList3._1.Data;
using BookList3._1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookList3._1.RazorPages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> Books { get; set; }

        public async Task OnGet()
        {

            Books = await _context.books.ToListAsync();

        }

        public async Task<IActionResult> OnPostDelete(int id)
        {

            var choosenBook = await _context.books.FindAsync(id);


            if (choosenBook != null)
            {
                _context.books.Remove(choosenBook);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return NotFound();
            }


        }

    }
}
