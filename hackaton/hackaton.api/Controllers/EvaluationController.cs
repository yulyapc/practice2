using hackaton.api.Data;
using hackaton.shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hackaton.api.Controllers
{
    [ApiController]
    [Route("/api/evaluations")]
    public class EvaluationController : ControllerBase
    {
        private readonly DataContext _context;
        public EvaluationController(DataContext context)
        {
            _context = context;
        }

        //get rewards list
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Evaluations.ToListAsync());
        }

        //Get a reward by param {id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var reward = await _context.Evaluations.FirstOrDefaultAsync(x => x.Id == id);
            if (reward == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(reward);
            }
        }

        //Create a new reward
        [HttpPost]
        public async Task<ActionResult> Post(Evaluation evaluation)
        {
            _context.Evaluations.Add(evaluation);
            await _context.SaveChangesAsync();
            return Ok(evaluation);
        }

        //Update a reward
        [HttpPut]
        public async Task<ActionResult> Put(Evaluation evaluation)
        {
            _context.Evaluations.Update(evaluation);
            await _context.SaveChangesAsync();
            return Ok(evaluation);
        }

        // Delete a reward
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filasafectadas = await _context.Evaluations
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (filasafectadas == 0)
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }
        }
    }
}
