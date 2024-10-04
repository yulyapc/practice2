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
            await CheckTeamAsync();
            await CheckParticipantAsync();
            await CheckProjectAsync();
            await CheckEvaluationAsync();
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

        private async Task CheckTeamAsync()
        {
            if (!_context.Rewards.Any())
            {
                var hackaton = _context.Hackatons.FirstOrDefault();
                _context.Teams.Add(new Team { Name= "Los mejores 1", NumberMembers = 3, Hackaton = hackaton });
                _context.Teams.Add(new Team { Name= "Los mejores 2", NumberMembers = 4, Hackaton = hackaton });
            }
            await _context.SaveChangesAsync();
        }

        private async Task CheckParticipantAsync()
        {
            if (!_context.Rewards.Any())
            {
                var team = _context.Teams.FirstOrDefault();
                _context.Participants.Add(new Participant { Name= "Name 1", Rol = "developer", Experience = "desarrollo + test", Team = team});
                _context.Participants.Add(new Participant { Name= "Name 2", Rol = "tester", Experience = "test + UI" , Team = team });
            }
            await _context.SaveChangesAsync();
        }

        private async Task CheckProjectAsync()
        {
            if (!_context.Rewards.Any())
            {
                var team = _context.Teams.FirstOrDefault();
                _context.Projects.Add(new Project { Name= "Name 1", Description = "desarrollo app movil", Status = "en desarrollo", Team = team });
                _context.Projects.Add(new Project { Name= "Name 2", Description = "desarrollo app web", Status = "en analisis", Team = team });
            }
            await _context.SaveChangesAsync();
        }

        private async Task CheckEvaluationAsync()
        {
            if (!_context.Rewards.Any())
            {
                var project = _context.Projects.FirstOrDefault();
                var mentor = _context.Mentors.FirstOrDefault();
                _context.Evaluations.Add(new Evaluation { Score= 5, Remarks = "Excelente trabajo", Project = project, Mentor = mentor });
                _context.Evaluations.Add(new Evaluation { Score= 3, Remarks = "Buen trabajo, tiene oportunidad de mejora", Project = project, Mentor = mentor });
            }
            await _context.SaveChangesAsync();
        }
    }
}
