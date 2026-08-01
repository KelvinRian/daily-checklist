using DailyChecklist.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyChecklist.Infrastructure.Context.Mapping
{
    public class DayTaskMapping : IEntityTypeConfiguration<DayTask>
    {
        public void Configure(EntityTypeBuilder<DayTask> builder)
        {
            builder.ToTable("DayTasks");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Day)
                .WithMany(x => x.DayTasks)
                .HasForeignKey(x => x.DayId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Task)
                .WithMany(x => x.DayTasks)
                .HasForeignKey(x => x.TaskId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Finished)
                .HasDefaultValue(false)
                .IsRequired();
        }
    }
}
