using Expect.Registry.Domain.Interfaces;
using Expect.Registry.Domain.Models;

namespace Expect.Registry.Domain.JoinEntities
{
	public class DocumentKindBasicDocument : IHaveId
	{
		public int Id { get; set; }
		public int DocumentKindId { get; set; }
		public int BasicDocumentId { get; set; }

		public virtual DocumentKind DocumentKind { get; set; }
		public virtual BasicDocument BasicDocument { get; set; }
	}
}