using Expect.Registry.Domain.ViewModels.Interfaces;
using Expect.Registry.Infrastructure.Enums;
using MediatR;

namespace Expect.Registry.Infrastructure.Commands.Interfaces
{
	public interface ILoadRegistry<TViewModel> : IRequest<IEnumerable<TViewModel>> where TViewModel : IViewModel
	{
	}
}