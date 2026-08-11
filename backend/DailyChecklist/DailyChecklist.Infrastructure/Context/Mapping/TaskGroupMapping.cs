using DailyChecklist.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyChecklist.Infrastructure.Context.Mapping
{
    public class TaskGroupMapping : IEntityTypeConfiguration<GroupItem>
    {
        public void Configure(EntityTypeBuilder<GroupItem> builder)
        {
            builder.ToTable("TaskGroups");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Order)
                .IsRequired();
        }
    }
}
