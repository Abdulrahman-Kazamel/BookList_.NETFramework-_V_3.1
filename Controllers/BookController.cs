using BookList3._1.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BookList3._1.Controllers
{

    [Route("Api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private ApplicationDbContext _context;
        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data =await _context.books.ToListAsync()  });
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedBook = await _context.books.FindAsync(id);

            if (deletedBook == null)
            {

                return Json(new { success = false, message = "Error While Deleting" });
            }
            _context.books.Remove(deletedBook);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "deleted Successfully" });

        }

    }
}
