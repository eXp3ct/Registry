using Expect.Registry.Domain.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expect.Registry.Data.Configurations.JoinEntitiesConfigurations
{
	public class CounterPartyIncomingDocumentConfiguration : IEntityTypeConfiguration<CounterPartyIncomingDocument>
	{
		public void Configure(EntityTypeBuilder<CounterPartyIncomingDocument> builder)
		{
			builder.HasOne(x => x.IncomingDocument)
				.WithMany(x => x.CounterParty)
				.HasForeignKey(x => x.IncomingDocumentId);

			builder.HasOne(x => x.CounterParty)
				.WithMany(x => x.JoinIncomingDocuments)
				.HasForeignKey(x => x.CounterPartyId);
		}
	}
}