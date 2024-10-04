using hackaton.api.Data;
using hackaton.shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hackaton.api.Controllers
{
    [ApiController]
    [Route("/api/hackatons")]
    public class HackatonController: ControllerBase
    {
        private readonly DataContext _context;
        public HackatonController(DataContext context)
        {
            _context = context;
        }

        //get hackatons list
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Hackatons.ToListAsync());
        }

        //Get a hackaton by param {id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var hackaton = await _context.Hackatons.FirstOrDefaultAsync(x => x.Id == id);
            if (hackaton == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(hackaton);
            }
        }

        //Create a new hackaton
        [HttpPost]
        public async Task<ActionResult> Post(Hackaton hackaton)
        {
            _context.Hackatons.Add(hackaton);
            await _context.SaveChangesAsync();
            return Ok(hackaton);
        }

        //Update a hackaton
        [HttpPut]
        public async Task<ActionResult> Put(Hackaton hackaton)
        {
            _context.Hackatons.Update(hackaton);
            await _context.SaveChangesAsync();
            return Ok(hackaton);
        }

        // Delete a hackaton
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filasafectadas = await _context.Hackatons
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
