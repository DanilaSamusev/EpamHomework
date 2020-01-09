using Contracts.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceAssistant.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FinanceNoteController : ControllerBase
    {
        private readonly IFinanceNoteService _financeNoteService;

        public FinanceNoteController(IFinanceNoteService financeNoteService)
        {
            _financeNoteService = financeNoteService;
        }

        [HttpGet]
        public IActionResult GetAllNotes()
        {
            var notes = _financeNoteService.GetAllNotes();

            var user = User;

            if (notes == null)
            {
                return BadRequest();
            }

            return Ok(notes);
        }
     
        [HttpGet("incomes")]
        public IActionResult GetIncomes()
        {
            var notes = _financeNoteService.GetAllIncomes();

            if (notes == null)
            {
                return BadRequest();
            }

            return Ok(notes);
        }

        [HttpGet("expenses")]
        public IActionResult GetExpenses()
        {
            var notes = _financeNoteService.GetAllExpenses();

            if (notes == null)
            {
                return BadRequest();
            }

            return Ok(notes);
        }

        [HttpPost("income")]
        public IActionResult AddIncome([FromQuery]decimal financeAmount)
        {
            _financeNoteService.AddIncomeNote(financeAmount);

            return Ok();
        }

        [HttpPost("expense")]
        public IActionResult AddExpense([FromQuery]decimal financeAmount)
        {
            _financeNoteService.AddExpenseNote(financeAmount);

            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateNote(int noteId)
        {
            return Ok();
        }
    }
}