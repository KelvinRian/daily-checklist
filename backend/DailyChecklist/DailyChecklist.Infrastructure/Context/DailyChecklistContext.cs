using DailyChecklist.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using EntityTask = DailyChecklist.Domain.Entities.Task;

namespace DailyChecklist.Infrastructure.Context
{
    public class DailyChecklistContext : DbContext
    {
        public DailyChecklistContext(DbContextOptions<DailyChecklistContext> options)
        : base(options)
        {
        }

        public DbSet<Routine> Routines => Set<Routine>();
        public DbSet<EntityTask> Tasks => Set<EntityTask>();
        public DbSet<TaskGroup> TaskGroups => Set<TaskGroup>();
        public DbSet<ActivePeriod> ActivePeriods => Set<ActivePeriod>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DailyChecklistContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
