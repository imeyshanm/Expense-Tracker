using Expense_Tracker.Model;
using Expense_Tracker.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace Expense_Tracker.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : Controller
    {
        private readonly IBudgetRepository _budgetRepository;

        public BudgetController(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        [HttpGet]
        // GET: BudgetController
        public ActionResult Get()
        {
            var products = _budgetRepository.GetBudgets();
            return StatusCode(StatusCodes.Status200OK, products);
        }

        [HttpGet("{id}", Name = "Get")]
        // GET: BudgetController/Details/5
        public ActionResult Get(int id)
        {
            var products = _budgetRepository.GetBudget(id);
            if (products==null)
            {
                return NotFound(id);
            }
            return StatusCode(StatusCodes.Status200OK, products);
        }

        [HttpPost]
        // GET: BudgetController/Create
        public ActionResult Post([FromBody] Budget budget)
        {
            using (var scope = new TransactionScope())
            {
                _budgetRepository.InsertBudget(budget);
                scope.Complete();
                return StatusCode(StatusCodes.Status201Created, CreatedAtAction(nameof(Get), new { id = budget.Id }, budget));
            }
        }

        // GET: BudgetController/Edit/5
        [HttpPut]
        public IActionResult Put([FromBody] Budget budget)
        {
            if (budget != null)
            {
                using (var scope = new TransactionScope())
                {
                    _budgetRepository.UpdateBudget(budget);
                    scope.Complete();
                    return StatusCode(StatusCodes.Status200OK, CreatedAtAction(nameof(Get), new { id = budget.Id }, budget));
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _budgetRepository.DeleteBudget(id);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
