using Expect.Registry.Domain.Interfaces;
using Expect.Registry.Domain.JoinEntities;

namespace Expect.Registry.Domain.Models
{
	public class CounterParty : IHaveId
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public List<CounterPartyIncomingDocument> JoinIncomingDocuments { get; set; }
	}
}