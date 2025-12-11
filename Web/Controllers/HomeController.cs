using System.Diagnostics;
using Web.Models;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Business;

namespace Web
{
    public class HomeController : Controller
    {
        private readonly IGBRepository _gBRepository;

        public HomeController(IGBRepository gBRepository)
        {
            _gBRepository = gBRepository;
        }

        public List<GuestBook> Entries()
        {
            return _gBRepository.GetEntries().OrderByDescending(e => e.CreatedDate).ToList();
        }

        public IActionResult Index()
        {
            return View(Entries());
        }

        [HttpPost]
        public IActionResult AddEntry(GuestBook guestBook)
        {
            if (ModelState.IsValid)
            {
                guestBook = _gBRepository.AddEntry(guestBook);
            }

            return View("Index", Entries());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
