using Expect.Registry.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expect.Registry.Data.Configurations
{
	public class IncomingDocumentConfiguration : IEntityTypeConfiguration<IncomingDocument>
	{
		public void Configure(EntityTypeBuilder<IncomingDocument> builder)
		{
			//builder.HasMany(x => x.Addressee)
			//	.WithMany(x => x.IncomingDocuments)
			//	.UsingEntity<AddresseIncomingDocument>();
			//builder.HasMany(x => x.CounterParty)
			//	.WithMany(x => x.IncomingDocuments)
			//	.UsingEntity<CounterPartyIncomingDocument>();
			//builder.HasMany(x => x.DeliveryMethod)
			//	.WithMany(x => x.IncomingDocuments)
			//	.UsingEntity<DeliveryMethodIncomingDocument>();
			//builder.HasMany(x => x.CameFrom)
			//	.WithMany(x => x.IncomingDocuments)
			//	.UsingEntity<CounterPartyIncomingDocument>();
		}
	}
}