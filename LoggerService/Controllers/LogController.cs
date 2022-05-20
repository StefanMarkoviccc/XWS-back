using LoggerService.Model;
using LoggerService.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogController : ControllerBase
    {
        private readonly LogService _logService;

        public LogController(LogService logService) =>
            _logService = logService;

        [HttpGet]
        public async Task<List<Log>> Get() =>
            await _logService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Log>> Get(string id)
        {
            var book = await _logService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Log log)
        {
            await _logService.CreateAsync(log);

            return CreatedAtAction(nameof(Get), new { id = log.Id }, log);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Log updatedBook)
        {
            var book = await _logService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            updatedBook.Id = book.Id;

            await _logService.UpdateAsync(id, updatedBook);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _logService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _logService.RemoveAsync(id);

            return NoContent();
        }
    }
}
