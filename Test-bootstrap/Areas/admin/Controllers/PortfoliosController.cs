
using Testbootstrap.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Testbootstrap.Data;
using Testbootstrap.Areas.admin.ViewModel;
using Testbootstrap.Models;

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

        public async Task<IActionResult> Detail(int id)
        {
            var portfolio = _context.Portfolios.FirstOrDefault(x => x.Id == id);
            if (portfolio == null) return NotFound();
            return View(portfolio);
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Portfolio portfolio)
        {
            _context.Portfolios.Add(portfolio);
            _context.SaveChanges();

            return View(portfolio);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var portfolio = _context.Portfolios.FirstOrDefault(x=> x.Id == id);
            if(portfolio == null) return NotFound();
            return View(portfolio);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Portfolio portfolio)
        {
            _context.Entry(portfolio);
            await _context.SaveChangesAsync();
            return View();
        }
    }
}
