using hackaton.api.Data;
using hackaton.shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hackaton.api.Controllers
{
    [ApiController]
    [Route("/api/participants")]
    public class ParticipantController : ControllerBase
    {
        private readonly DataContext _context;
        public ParticipantController(DataContext context)
        {
            _context = context;
        }

        //get participant list
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Participants.ToListAsync());
        }

        //Get a participant by param {id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var participant = await _context.Participants.FirstOrDefaultAsync(x => x.Id == id);
            if (participant == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(participant);
            }
        }

        //Create a new participant
        [HttpPost]
        public async Task<ActionResult> Post(Participant participant)
        {
            _context.Participants.Add(participant);
            await _context.SaveChangesAsync();
            return Ok(participant);
        }

        //Update a participant
        [HttpPut]
        public async Task<ActionResult> Put(Participant participant)
        {
            _context.Participants.Update(participant);
            await _context.SaveChangesAsync();
            return Ok(participant);
        }

        // Delete a participant
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
