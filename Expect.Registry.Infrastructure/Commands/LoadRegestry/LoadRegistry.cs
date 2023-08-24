using AutoMapper;
using AutoMapper.QueryableExtensions;
using Expect.Registry.Data.Interfaces;
using Expect.Registry.Domain.Interfaces;
using Expect.Registry.Domain.ViewModels.Interfaces;
using Expect.Registry.Infrastructure.Commands.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Expect.Registry.Infrastructure.Commands.LoadRegestry
{
	public class LoadRegistryQuery<TViewModel> : ILoadRegistry<TViewModel>
		where TViewModel : IViewModel
	{
	}

	public class LoadRegistryQueryHandler<TDocumentType, TViewModel> : ILoadRegistryHandler<ILoadRegistry<TViewModel>, TViewModel>
		where TViewModel : IViewModel
		where TDocumentType : IHaveId
	{
		private readonly IApplicationDbContext _context;
		private readonly IMapper _mapper;

		public LoadRegistryQueryHandler(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<IEnumerable<TViewModel>> Handle(ILoadRegistry<TViewModel> request, CancellationToken cancellationToken)
		{
			return await _context.BasicDocuments
				.OfType<TDocumentType>()
				.ProjectTo<TViewModel>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);
		}
	}
}