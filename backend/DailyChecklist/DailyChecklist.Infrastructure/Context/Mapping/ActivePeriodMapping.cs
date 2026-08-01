using DailyChecklist.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyChecklist.Infrastructure.Context.Mapping
{
    public class ActivePeriodMapping : IEntityTypeConfiguration<ActivePeriod>
    {
        public void Configure(EntityTypeBuilder<ActivePeriod> builder)
        {
            builder.ToTable("ActivePeriods");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.StartDate)
                .IsRequired();

            builder.Property(x => x.EndDate);

            builder.Property(x => x.Active)
                .HasDefaultValue(true)
                .IsRequired();
        }
    }
}
