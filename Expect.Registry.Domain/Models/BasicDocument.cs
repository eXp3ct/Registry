using Expect.Registry.Domain.Interfaces;
using Expect.Registry.Domain.JoinEntities;

namespace Expect.Registry.Domain.Models
{
	public class BasicDocument : IHaveId
	{
		public int Id { get; set; }
		public Guid Discriminator { get; set; }
		public string Name { get; set; }
		public List<DocumentKindBasicDocument> JoinDocumentKind { get; set; }
		public string? Subject { get; set; }
		public DateTime CreatedDate { get; } = DateTime.UtcNow;
		public string DocumentNumber { get; set; }
	}
}