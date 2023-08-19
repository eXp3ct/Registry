using Expect.Registry.Data.Interfaces;
using Expect.Registry.Data.Seeding;
using Expect.Registry.Domain.JoinEntities;
using Expect.Registry.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Expect.Registry.Data
{
	public class ApplicationDbContext : DbContext, IApplicationDbContext
	{
		#region Entities

		public DbSet<Addressee> Addressees { get; set; }
		public DbSet<BasicDocument> BasicDocuments { get; set; }
		public DbSet<CounterParty> CounterParties { get; set; }
		public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
		public DbSet<DocumentKind> DocumentKinds { get; set; }

		#endregion Entities

		#region JoinEntities

		public DbSet<DocumentKindBasicDocument> DocumentKindBasicDocuments { get; set; }
		public DbSet<AddresseIncomingDocument> AddresseIncomingDocuments { get; set; }
		public DbSet<CameFromIncomingDocument> CameFromIncomingDocuments { get; set; }
		public DbSet<CounterPartyIncomingDocument> CounterPartyIncomingDocuments { get; set; }
		public DbSet<DeliveryMethodIncomingDocument> DeliveryMethodIncomingDocuments { get; set; }

		#endregion JoinEntities

		#region Constructors

		public ApplicationDbContext()
		{
		}

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		#endregion Constructors

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var connectionString = "Host=localhost;Port=5432;Database=postgres;Username=root;Password=root;";

			optionsBuilder.UseNpgsql(connectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			modelBuilder.Seed();
			base.OnModelCreating(modelBuilder);
		}
	}
}