using hackaton.api.Data;
using hackaton.shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hackaton.api.Controllers
{
    [ApiController]
    [Route("/api/rewards")]
    public class RewardController: ControllerBase
    {
        private readonly DataContext _context;
        public RewardController(DataContext context)
        {
            _context = context;
        }

        //get rewards list
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Rewards.ToListAsync());
        }

        //Get a reward by param {id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var reward = await _context.Rewards.FirstOrDefaultAsync(x => x.Id == id);
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
        public async Task<ActionResult> Post(Reward reward)
        {
            _context.Rewards.Add(reward);
            await _context.SaveChangesAsync();
            return Ok(reward);
        }

        //Update a reward
        [HttpPut]
        public async Task<ActionResult> Put(Reward reward)
        {
            _context.Rewards.Update(reward);
            await _context.SaveChangesAsync();
            return Ok(reward);
        }

        // Delete a reward
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filasafectadas = await _context.Rewards
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
