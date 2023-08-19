using Expect.Registry.Domain.Interfaces;
using Expect.Registry.Domain.Models;

namespace Expect.Registry.Domain.JoinEntities
{
	public class AddresseIncomingDocument : IHaveId
	{
		public int Id { get; set; }
		public int AddresseId { get; set; }
		public int IncomingDocumentId { get; set; }

		public virtual Addressee Addressee { get; set; }
		public virtual IncomingDocument IncomingDocument { get; set; }
	}
}