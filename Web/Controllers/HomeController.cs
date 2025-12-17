using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Diagnostics;
using Web.Models;

namespace Web
{
    public class HomeController : Controller
    {
        private readonly IGuestService _guestService;

        public HomeController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        public async Task<List<GuestbookDto>> Entries()
        {
            return await _guestService.GetEntries();
        }

        public async Task<IActionResult> Index()
        {
            var entries = await Entries();
            return View(entries);
        }

        [HttpPost]
        public async Task<IActionResult> AddEntry(GuestbookDto guestbookDto)
        {
            if (ModelState.IsValid)
            {
                guestbookDto = await _guestService.AddEntry(guestbookDto);
            }

            var entries = await Entries();
            return View("Index", entries);
        }

        // AJAX endpoint for Add
        [HttpPost]
        public async Task<IActionResult> AddEntryAjax(GuestbookDto guestbookDto)
        {
            if (ModelState.IsValid)
            {
                await _guestService.AddEntry(guestbookDto);
            }

            var entries = await Entries();
            return PartialView("_EntriesTable", entries);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveEntry(int id)
        {

            await _guestService.RemoveEntry(id);

            var entries = await Entries();
            return View("Index", entries);
        }

        // AJAX endpoint for Remove
        [HttpPost]
        public async Task<IActionResult> RemoveEntryAjax(int id)
        {
            await _guestService.RemoveEntry(id);
            var entries = await Entries();
            return PartialView("_EntriesTable", entries);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEntry(GuestbookDto guestbookDto)
        {

            await _guestService.UpdateEntry(guestbookDto);

            var entries = await Entries();
            return View("Index", entries);
        }

        // AJAX endpoint for Update
        [HttpPost]
        public async Task<IActionResult> UpdateEntryAjax(GuestbookDto guestbookDto)
        {
            await _guestService.UpdateEntry(guestbookDto);
            var entries = await Entries();
            return PartialView("_EntriesTable", entries);
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
