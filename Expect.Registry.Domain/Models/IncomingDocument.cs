using Expect.Registry.Domain.JoinEntities;

namespace Expect.Registry.Domain.Models
{
	public class IncomingDocument : BasicDocument
	{
		public List<AddresseIncomingDocument> Addressee { get; set; }
		public List<CounterPartyIncomingDocument> CounterParty { get; set; }
		public List<DeliveryMethodIncomingDocument> DeliveryMethod { get; set; }
		public List<CameFromIncomingDocument> CameFrom { get; set; }
	}
}