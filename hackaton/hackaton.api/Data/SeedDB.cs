using hackaton.shared.Entities;
using System.Diagnostics.Eventing.Reader;

namespace hackaton.api.Data
{
    public class SeedDB
    {
        private readonly DataContext _context;
        public SeedDB(DataContext context)
        {
            _context = context;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckMentorAsync();
            await CheckHackatonAsync();
            await CheckRewardAsync();
        }

        private async Task CheckMentorAsync()
        {
            if (!_context.Mentors.Any())
            {
                _context.Mentors.Add(new Mentor { Name = "Carlos", Experience = "Senior" });
                _context.Mentors.Add(new Mentor { Name = "Juan", Experience = "Junior" });
            }
            await _context.SaveChangesAsync();
        }

        private async Task CheckHackatonAsync()
        {
            if (!_context.Hackatons.Any())
            {
                _context.Hackatons.Add(new Hackaton { Name = "Pedro", StartDate = DateTime.Now, EndDate =  DateTime.Now.AddDays(10), Topic = "Seguridad", Organizer= "Pepito Perez" });
                _context.Hackatons.Add(new Hackaton { Name = "Lucas", StartDate = DateTime.Now, EndDate =  DateTime.Now.AddDays(20), Topic = "IA", Organizer = "Luisito Dominguez" });
            }
            await _context.SaveChangesAsync();
        }

        private async Task CheckRewardAsync()
        {
            if (!_context.Rewards.Any())
            {
                var hackaton = _context.Hackatons.FirstOrDefault();
                _context.Rewards.Add(new Reward {Description= "Mackbook pro", Hackaton = hackaton });
                _context.Rewards.Add(new Reward {Description= "Iphone 16", Hackaton = hackaton });
            }
            await _context.SaveChangesAsync();
        }
    }
}
