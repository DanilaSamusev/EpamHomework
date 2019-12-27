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

        [HttpGet("incomes")]
        public IActionResult GetIncomes()
        {
            var notes = _financeService.GetAllIncomes();

            if (notes == null)
            {
                return BadRequest("You have't any notes!");
            }

            return Ok(notes);
        }

        [HttpGet("expenses")]
        public IActionResult GetExpenses()
        {
            var notes = _financeService.GetAllExpenses();

            if (notes == null)
            {
                return BadRequest("You have't any notes!");
            }

            return Ok(notes);
        }

        [HttpPost("income")]
        public IActionResult AddIncome([FromQuery]decimal financeAmount)
        {
            _financeService.AddIncomeNote(financeAmount);

            return Ok("Note successfully added");
        }

        [HttpPost("expense")]
        public IActionResult AddExpense([FromQuery]decimal financeAmount)
        {
            _financeService.AddExpenseNote(financeAmount);

            return Ok("Note successfully added");
        }
    }
}