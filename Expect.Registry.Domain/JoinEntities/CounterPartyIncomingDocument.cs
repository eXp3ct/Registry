using Expect.Registry.Domain.Interfaces;
using Expect.Registry.Domain.Models;

namespace Expect.Registry.Domain.JoinEntities
{
	public class CounterPartyIncomingDocument : IHaveId
	{
		public int Id { get; set; }
		public int CounterPartyId { get; set; }
		public int IncomingDocumentId { get; set; }

		public virtual CounterParty CounterParty { get; set; }
		public virtual IncomingDocument IncomingDocument { get; set; }
	}
}