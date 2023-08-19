using Expect.Registry.Domain.Interfaces;
using Expect.Registry.Domain.Models;

namespace Expect.Registry.Domain.JoinEntities
{
	public class CameFromIncomingDocument : IHaveId
	{
		public int Id { get; set; }
		public int CameFromId { get; set; }
		public int IncomingDocumentId { get; set; }

		public CameFrom CameFrom { get; set; }
		public IncomingDocument IncomingDocument { get; set; }
	}
}