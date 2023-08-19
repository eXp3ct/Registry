using Expect.Registry.Domain.Interfaces;
using Expect.Registry.Domain.JoinEntities;

namespace Expect.Registry.Domain.Models
{
	public class Addressee : IHaveId
	{
		public int Id { get; set; }
		public string FullName { get; set; }

		public List<AddresseIncomingDocument> JoinIncomingDocuments { get; set; }
	}
}