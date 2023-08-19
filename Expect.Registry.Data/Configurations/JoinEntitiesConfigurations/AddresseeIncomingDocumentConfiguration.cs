using Expect.Registry.Domain.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expect.Registry.Data.Configurations.JoinEntitiesConfigurations
{
	public class AddresseeIncomingDocumentConfiguration : IEntityTypeConfiguration<AddresseIncomingDocument>
	{
		public void Configure(EntityTypeBuilder<AddresseIncomingDocument> builder)
		{
			builder.HasOne(x => x.Addressee)
				.WithMany(x => x.JoinIncomingDocuments)
				.HasForeignKey(x => x.AddresseId);

			builder.HasOne(x => x.IncomingDocument)
				.WithMany(x => x.Addressee)
				.HasForeignKey(x => x.IncomingDocumentId);
		}
	}
}