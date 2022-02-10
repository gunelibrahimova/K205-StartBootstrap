
using Testbootstrap.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Testbootstrap.Data;
using Testbootstrap.Areas.admin.ViewModel;

namespace Testbootstrap.Areas.admin.Controllers
{
    [Area("admin")]
    public class PortfoliosController : Controller
    {
        private readonly TestDbContext _context;

        public PortfoliosController(TestDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            AdminVM vm = new()
            {
                Portfolios = _context.Portfolios.ToList()
            };
            return View(vm);
        }
    }
}
