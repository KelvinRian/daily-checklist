using DailyChecklist.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyChecklist.Infrastructure.Context.Mapping
{
    public class GroupTaskMapping : IEntityTypeConfiguration<GroupTask>
    {
        public void Configure(EntityTypeBuilder<GroupTask> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Order)
                .IsRequired();
        }
    }
}
