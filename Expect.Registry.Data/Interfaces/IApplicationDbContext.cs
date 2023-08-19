using Expect.Registry.Domain.JoinEntities;
using Expect.Registry.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Expect.Registry.Data.Interfaces
{
	public interface IApplicationDbContext
	{
		#region Entities

		public DbSet<Addressee> Addressees { get; set; }
		public DbSet<BasicDocument> BasicDocuments { get; set; }
		public DbSet<CounterParty> CounterParties { get; set; }
		public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
		public DbSet<DocumentKind> DocumentKinds { get; set; }
		//public DbSet<IncomingDocument> IncomingDocuments { get; set; }

		#endregion Entities

		#region JoinEntities

		public DbSet<DocumentKindBasicDocument> DocumentKindBasicDocuments { get; set; }
		public DbSet<AddresseIncomingDocument> AddresseIncomingDocuments { get; set; }
		public DbSet<CameFromIncomingDocument> CameFromIncomingDocuments { get; set; }
		public DbSet<CounterPartyIncomingDocument> CounterPartyIncomingDocuments { get; set; }
		public DbSet<DeliveryMethodIncomingDocument> DeliveryMethodIncomingDocuments { get; set; }

		#endregion JoinEntities

		public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}