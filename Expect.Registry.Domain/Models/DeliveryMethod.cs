using Expect.Registry.Domain.Interfaces;
using Expect.Registry.Domain.JoinEntities;

namespace Expect.Registry.Domain.Models
{
	public class DeliveryMethod : IHaveId
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public List<DeliveryMethodIncomingDocument> JoinIncomingDocuments { get; set; }
	}
}