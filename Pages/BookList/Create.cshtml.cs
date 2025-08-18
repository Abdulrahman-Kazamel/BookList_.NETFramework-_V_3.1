using BookList3._1.Data;
using BookList3._1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BookList3._1.RazorPages.BookList
{
    public class CreateModel : PageModel
    {
    private readonly ApplicationDbContext _context;


        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost() {

            if (ModelState.IsValid)
            {
                await _context.books.AddAsync(Book);
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
