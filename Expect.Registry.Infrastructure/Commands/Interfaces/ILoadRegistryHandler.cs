using Expect.Registry.Domain.ViewModels.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Registry.Infrastructure.Commands.Interfaces
{
	public interface ILoadRegistryHandler<TLoadRegisrty, TViewModel> : IRequestHandler<TLoadRegisrty, IEnumerable<TViewModel>>
		where TViewModel : IViewModel
		where TLoadRegisrty : ILoadRegistry<TViewModel>
	{
	}
}
