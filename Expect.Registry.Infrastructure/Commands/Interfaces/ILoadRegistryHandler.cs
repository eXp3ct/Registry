using Expect.Registry.Domain.ViewModels.Interfaces;
using MediatR;

namespace Expect.Registry.Infrastructure.Commands.Interfaces
{
	public interface ILoadRegistryHandler<TLoadRegisrty, TViewModel> : IRequestHandler<TLoadRegisrty, IEnumerable<TViewModel>>
		where TViewModel : IViewModel
		where TLoadRegisrty : ILoadRegistry<TViewModel>
	{
	}
}