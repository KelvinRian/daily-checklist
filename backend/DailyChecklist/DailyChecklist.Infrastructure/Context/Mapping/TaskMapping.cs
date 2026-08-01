using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EntityTask = DailyChecklist.Domain.Entities.Task;

namespace DailyChecklist.Infrastructure.Context.Mapping
{
    public class TaskMapping : IEntityTypeConfiguration<EntityTask>
    {
        public void Configure(EntityTypeBuilder<EntityTask> builder)
        {
            builder.ToTable("Tasks");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Order)
                .IsRequired();

            builder.HasOne(x => x.TaskGroup)
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.TaskGroupId);
        }
    }
}
