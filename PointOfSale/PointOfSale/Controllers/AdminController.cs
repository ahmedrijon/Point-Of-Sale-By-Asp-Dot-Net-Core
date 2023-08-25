using Microsoft.AspNetCore.Mvc;
using PointOfSale.Data;
using System.Linq;

namespace PointOfSale.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var us = _context.Salesman.ToList();
            ViewBag.Salesman = us.Count();
            return View();
        }
    }
}
