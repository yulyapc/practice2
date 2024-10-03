using hackaton.api.Data;
using hackaton.shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hackaton.api.Controllers
{
    [ApiController]
    [Route("/api/teams")]
    public class TeamController : ControllerBase
    {
        private readonly DataContext _context;
        public TeamController(DataContext context)
        {
            _context = context;
        }

        //get team list
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Teams.ToListAsync());
        }

        //Get a team by param {id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);
            if (team == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(team);
            }
        }

        //Create a new team
        [HttpPost]
        public async Task<ActionResult> Post(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            return Ok(team);
        }

        //Update a team
        [HttpPut]
        public async Task<ActionResult> Put(Team team)
        {
            _context.Teams.Update(team);
            await _context.SaveChangesAsync();
            return Ok(team);
        }

        // Delete a team
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filasafectadas = await _context.Teams
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
