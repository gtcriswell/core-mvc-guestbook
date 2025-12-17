using Domain.Business;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestbookController : ControllerBase
    {
        private readonly IGBRepository _gBRepository;
        public GuestbookController(IGBRepository gBRepository)
        {
            _gBRepository = gBRepository;
        }

        [HttpGet]
        [Route("entries")]
        public async Task<IActionResult> GetEntries()
        {
            var results = await _gBRepository.GetEntries();
            if (results.Any())
            {
                return Ok(results);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("entry")]
        public async Task<IActionResult> AddEntry(GuestBook guestBook)
        {
            var results = await _gBRepository.AddEntry(guestBook);
            if (results != null)
            {
                return Ok(results);
            }
            return NotFound();
        }

        [HttpPut]
        [Route("entry")]
        public async Task<IActionResult> UpdateEntry(GuestBook guestBook)
        {
            var result = await _gBRepository.UpdateEntry(guestBook);

            return Ok(result);

        }

        [HttpDelete]
        [Route("entry")]
        public async Task<IActionResult> RemoveEntry(int id)
        {
            await _gBRepository.RemoveEntry(id);

            return Ok();

        }


    }
}
