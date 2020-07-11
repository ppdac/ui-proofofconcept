using Microsoft.EntityFrameworkCore;
using rzr.Models;

namespace rzr.Data
{
    public class rzrContext : DbContext
    {
        public rzrContext (DbContextOptions<rzrContext> options)
            : base(options)
        {
        }

        public DbSet<rzr.Models.Participant> Participant { get; set; }
        public DbSet<rzr.Models.Schedule> Schedule { get; set; }
        public DbSet<rzr.Models.Experiment> Experiment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExperimentParticipant>()
                 .HasKey(k => new { k.ExperimentId, k.ParticipantId });

            modelBuilder.Entity<ExperimentParticipant>()
                .HasOne(ep => ep.Experiment)
                .WithMany(e => e.ExperimentParticipants)
                .HasForeignKey(ep => ep.ExperimentId);

            modelBuilder.Entity<ExperimentParticipant>()
                .HasOne(ep => ep.Participant)
                .WithMany(p => p.ExperimentParticipants)
                .HasForeignKey(ep => ep.ParticipantId);
        }

        public DbSet<rzr.Models.ExperimentParticipant> ExperimentParticipant { get; set; }

    }
}
