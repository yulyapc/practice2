using hackaton.api.Data;
using hackaton.shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hackaton.api.Controllers
{
    [ApiController]
    [Route("/api/mentors")]
    public class MentorController: ControllerBase
    {
        private readonly DataContext _context;
        public MentorController(DataContext context)
        {
            _context = context;
        }

        //get mentors list
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Mentors.ToListAsync());
        }

        //Get a mentor by param {id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var mentor = await _context.Mentors.FirstOrDefaultAsync(x => x.Id == id);
            if (mentor == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(mentor);
            }
        }

        //Create a new mentor
        [HttpPost]
        public async Task<ActionResult> Post(Mentor mentor)
        {
            _context.Mentors.Add(mentor);
            await _context.SaveChangesAsync();
            return Ok(mentor);
        }

        //Update a mentor
        [HttpPut]
        public async Task<ActionResult> Put(Mentor mentor)
        {
            _context.Mentors.Update(mentor);
            await _context.SaveChangesAsync();
            return Ok(mentor);
        }

        // Delete a mentor
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filasafectadas = await _context.Mentors
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
