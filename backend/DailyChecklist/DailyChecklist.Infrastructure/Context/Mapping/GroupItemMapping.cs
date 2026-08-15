using DailyChecklist.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyChecklist.Infrastructure.Context.Mapping
{
    public class GroupItemMapping : IEntityTypeConfiguration<GroupItem>
    {
        public void Configure(EntityTypeBuilder<GroupItem> builder)
        {
            builder.HasMany(x => x.GroupTasks)
                .WithOne(x => x.GroupItem)
                .HasForeignKey(x => x.GroupItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
