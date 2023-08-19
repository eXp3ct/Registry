using Expect.Registry.Domain.Interfaces;
using Expect.Registry.Domain.Models;

namespace Expect.Registry.Domain.JoinEntities
{
	public class DeliveryMethodIncomingDocument : IHaveId
	{
		public int Id { get; set; }
		public int DeliveryMethodId { get; set; }
		public int IncomingDocumentId { get; set; }

		public virtual DeliveryMethod DeliveryMethod { get; set; }
		public virtual IncomingDocument IncomingDocument { get; set; }
	}
}