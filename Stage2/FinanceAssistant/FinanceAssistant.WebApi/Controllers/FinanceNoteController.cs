using Contracts.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace FinanceAssistant.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FinanceNoteController : ControllerBase
    {
        private readonly IFinanceService _financeService;

        public FinanceNoteController(IFinanceService financeService)
        {
            _financeService = financeService;
        }

        [HttpGet]
        public IActionResult GetAllNotes()
        {
            var notes = _financeService.GetAllNotes();

            if (notes == null)
            {
                return BadRequest("You have't any notes!");
            }

            return Ok(notes);
        }

        
    }
}