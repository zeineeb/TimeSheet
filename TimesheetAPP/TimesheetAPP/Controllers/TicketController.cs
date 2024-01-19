using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimesheetAPP.Core.Interfaces;
using TimesheetAPP.Core.Services;

namespace TimesheetAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {

        private readonly ITicketService ticketService;

        public TicketController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        [HttpGet("test/{project}")]
        public async Task<IActionResult> GetOpenBugs(string project)
        {
            try
            {
                var openBugs = await ticketService.GetOpenBugsAsync(project).ConfigureAwait(false);
                return Ok(openBugs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
