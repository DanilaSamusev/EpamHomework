using Contracts.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace FinanceAssistant.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FinanceNoteController : ControllerBase
    {
        private readonly IFinanceNoteService _financeNoteService;
        private const string NotesErrorMessage = "You haven't any notes!";
        private const string NoteAddingSuccessMessage = "Note successfully added";

        public FinanceNoteController(IFinanceNoteService financeNoteService)
        {
            _financeNoteService = financeNoteService;
        }

        [HttpGet]
        public IActionResult GetAllNotes()
        {
            var notes = _financeNoteService.GetAllNotes();

            if (notes == null)
            {
                return BadRequest(NotesErrorMessage);
            }

            return Ok(notes);
        }

        [HttpGet("incomes")]
        public IActionResult GetIncomes()
        {
            var notes = _financeNoteService.GetAllIncomes();

            if (notes == null)
            {
                return BadRequest(NotesErrorMessage);
            }

            return Ok(notes);
        }

        [HttpGet("expenses")]
        public IActionResult GetExpenses()
        {
            var notes = _financeNoteService.GetAllExpenses();

            if (notes == null)
            {
                return BadRequest(NotesErrorMessage);
            }

            return Ok(notes);
        }

        [HttpPost("income")]
        public IActionResult AddIncome([FromQuery]decimal financeAmount)
        {
            _financeNoteService.AddIncomeNote(financeAmount);

            return Ok(NoteAddingSuccessMessage);
        }

        [HttpPost("expense")]
        public IActionResult AddExpense([FromQuery]decimal financeAmount)
        {
            _financeNoteService.AddExpenseNote(financeAmount);

            return Ok(NoteAddingSuccessMessage);
        }
    }
}