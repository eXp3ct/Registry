using Expect.Registry.Domain.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expect.Registry.Data.Configurations.JoinEntitiesConfigurations
{
	public class CameFromIncomingDocumentConfiguration : IEntityTypeConfiguration<CameFromIncomingDocument>
	{
		public void Configure(EntityTypeBuilder<CameFromIncomingDocument> builder)
		{
			builder.HasOne(x => x.IncomingDocument)
				.WithMany(x => x.CameFrom)
				.HasForeignKey(x => x.IncomingDocumentId);

			builder.HasOne(x => x.CameFrom)
				.WithMany(x => x.JoinIncomingDocument)
				.HasForeignKey(x => x.CameFromId);
		}
	}
}