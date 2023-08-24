using Expect.Registry.Domain.ViewModels.Interfaces;
using MediatR;

namespace Expect.Registry.Infrastructure.Commands.Interfaces
{
	public interface ILoadRegistry<TViewModel> : IRequest<IEnumerable<TViewModel>> where TViewModel : IViewModel
	{
	}
}