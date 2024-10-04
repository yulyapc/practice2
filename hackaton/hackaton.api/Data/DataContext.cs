using hackaton.shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace hackaton.api.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Hackaton> Hackatons { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
    }
}
