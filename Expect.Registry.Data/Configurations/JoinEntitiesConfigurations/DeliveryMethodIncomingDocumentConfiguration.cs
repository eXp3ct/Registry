using Expect.Registry.Domain.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expect.Registry.Data.Configurations.JoinEntitiesConfigurations
{
	public class DeliveryMethodIncomingDocumentConfiguration : IEntityTypeConfiguration<DeliveryMethodIncomingDocument>
	{
		public void Configure(EntityTypeBuilder<DeliveryMethodIncomingDocument> builder)
		{
			builder.HasOne(x => x.IncomingDocument)
				.WithMany(x => x.DeliveryMethod)
				.HasForeignKey(x => x.IncomingDocumentId);

			builder.HasOne(x => x.DeliveryMethod)
				.WithMany(x => x.JoinIncomingDocuments)
				.HasForeignKey(x => x.DeliveryMethodId);
		}
	}
}