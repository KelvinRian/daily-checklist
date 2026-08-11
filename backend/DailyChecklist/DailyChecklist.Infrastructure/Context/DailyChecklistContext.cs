using DailyChecklist.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DailyChecklist.Infrastructure.Context
{
    public class DailyChecklistContext : DbContext
    {
        public DailyChecklistContext(DbContextOptions<DailyChecklistContext> options)
        : base(options)
        {
        }

        public DbSet<Routine> Routines => Set<Routine>();
        public DbSet<GroupItem> GroupItems => Set<GroupItem>();
        public DbSet<TaskItem> TaskItems => Set<TaskItem>();
        public DbSet<GroupTask> GroupTasks => Set<GroupTask>();
        public DbSet<ActivePeriod> ActivePeriods => Set<ActivePeriod>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DailyChecklistContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
