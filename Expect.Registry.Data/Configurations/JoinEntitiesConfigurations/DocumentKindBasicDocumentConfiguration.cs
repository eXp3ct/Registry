using Expect.Registry.Domain.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expect.Registry.Data.Configurations.JoinEntitiesConfigurations
{
	public class DocumentKindBasicDocumentConfiguration : IEntityTypeConfiguration<DocumentKindBasicDocument>
	{
		public void Configure(EntityTypeBuilder<DocumentKindBasicDocument> builder)
		{
			builder.HasOne(x => x.BasicDocument)
				.WithMany(x => x.JoinDocumentKind)
				.HasForeignKey(x => x.BasicDocumentId);

			builder.HasOne(x => x.DocumentKind)
				.WithMany(x => x.JoinBasicDocuments)
				.HasForeignKey(x => x.DocumentKindId);
		}
	}
}