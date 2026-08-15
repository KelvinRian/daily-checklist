using DailyChecklist.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DailyChecklist.Infrastructure.Context.Mapping
{
    public class RoutineItemMapping : IEntityTypeConfiguration<RoutineItem>
    {
        public void Configure(EntityTypeBuilder<RoutineItem> builder)
        {
            builder.ToTable("RoutineItems");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Order)
                .IsRequired();

            builder.HasOne(x => x.Routine)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.RoutineId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasDiscriminator<string>("ItemType")
                .HasValue<TaskItem>("Task")
                .HasValue<GroupItem>("Group");
        }
    }
}
