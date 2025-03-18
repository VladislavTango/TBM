using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuarterService.Domain.Entities;

namespace QuarterService.DataPersistance.AppContext.TableConfiguration
{
    public class FuturesDifferenceConfiguration : IEntityTypeConfiguration<FuturesDifference>
    {
        public void Configure(EntityTypeBuilder<FuturesDifference> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
