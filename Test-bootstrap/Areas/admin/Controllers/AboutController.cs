using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Testbootstrap.Data;
using Testbootstrap.Models;

namespace Testbootstrap.Areas.admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly TestDbContext _context;

        public AboutController(TestDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _context.Abouts.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var about = _context.Abouts.FirstOrDefault(x => x.Id == id);
            if (about == null) return NotFound();

            return View(about);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(About about)
        {
            try
            {
                _context.Update(about);
                _context.SaveChanges();

            }
            catch (Exception)
            {

                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var about = _context.Abouts.FirstOrDefault(x => x.Id == id);
            if (about == null) return NotFound();

            return View(about);
        }



        public async Task<IActionResult> Delete(int id)
        {
            var about = await _context.Abouts.FindAsync(id);
            _context.Abouts.Remove(about);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


       
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(About about)
        {
            _context.Abouts.Add(about);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

