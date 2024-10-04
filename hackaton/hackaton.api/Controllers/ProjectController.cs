using hackaton.api.Data;
using hackaton.shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hackaton.api.Controllers
{
        [ApiController]
        [Route("/api/projects")]
        public class ProjectController : ControllerBase
        {
            private readonly DataContext _context;
            public ProjectController(DataContext context)
            {
                _context = context;
            }

            //get rewards list
            [HttpGet]
            public async Task<ActionResult> Get()
            {
                return Ok(await _context.Projects.ToListAsync());
            }

            //Get a reward by param {id}
            [HttpGet("{id:int}")]
            public async Task<ActionResult> Get(int id)
            {
                var reward = await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
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
            public async Task<ActionResult> Post(Project project)
            {
                _context.Projects.Add(project);
                await _context.SaveChangesAsync();
                return Ok(project);
            }

            //Update a reward
            [HttpPut]
            public async Task<ActionResult> Put(Project project)
            {
                _context.Projects.Update(project);
                await _context.SaveChangesAsync();
                return Ok(project);
            }

            // Delete a reward
            [HttpDelete("{id:int}")]
            public async Task<ActionResult> Delete(int id)
            {
                var filasafectadas = await _context.Projects
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
