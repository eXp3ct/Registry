using Expect.Registry.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expect.Registry.Data.Configurations
{
	public class BasicDocumentConfiguration : IEntityTypeConfiguration<BasicDocument>
	{
		private readonly Guid Discriminator1 = Guid.Parse("06398D2C-5B15-4D14-A44A-E1CDBC2B4D02");
		private readonly Guid Discriminator2 = Guid.Parse("D12DFDE5-3397-471A-A07C-628DCAFB65A9");

		public void Configure(EntityTypeBuilder<BasicDocument> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedOnAdd();
			builder.Property(x => x.Subject).IsRequired(false);
			builder.Property(x => x.Name).IsRequired();
			builder.Property(x => x.DocumentNumber).IsRequired();
			builder.ToTable("Documents");
			builder.HasDiscriminator(x => x.Discriminator)
				.HasValue<BasicDocument>(Discriminator1)
				.HasValue<IncomingDocument>(Discriminator2);
		}
	}
}