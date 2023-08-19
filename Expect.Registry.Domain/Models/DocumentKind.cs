using Expect.Registry.Domain.Interfaces;
using Expect.Registry.Domain.JoinEntities;

namespace Expect.Registry.Domain.Models
{
	public class DocumentKind : IHaveId
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public List<DocumentKindBasicDocument> JoinBasicDocuments { get; set; }
	}
}