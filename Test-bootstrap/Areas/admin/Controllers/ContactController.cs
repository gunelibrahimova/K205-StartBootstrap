using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Testbootstrap.Data;

namespace Test_bootstrap.Areas.admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly TestDbContext _context;

        public ContactController(TestDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Contacts.ToListAsync());
        }
    }
}
