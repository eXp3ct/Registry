using Expect.Registry.Domain.Interfaces;
using Expect.Registry.Domain.ViewModels.Interfaces;

namespace Expect.Registry.Domain.ViewModels
{
	public class BasicDocumentViewModel : IHaveId, IViewModel
	{
		public int Id { get; set; }
		public Guid Discriminator { get; set; }
		public string DocumentKind { get; set; }
		public string Name { get; set; }
		public string? Subject { get; set; }
		public DateTime CreatedDate { get; set; }
		public string DocumentNumber { get; set; }
	}
}