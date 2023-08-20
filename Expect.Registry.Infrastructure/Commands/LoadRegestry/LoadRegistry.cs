using AutoMapper;
using AutoMapper.QueryableExtensions;
using Expect.Registry.Data.Interfaces;
using Expect.Registry.Domain.Models;
using Expect.Registry.Domain.ViewModels;
using Expect.Registry.Domain.ViewModels.Interfaces;
using Expect.Registry.Infrastructure.Commands.Interfaces;
using Expect.Registry.Infrastructure.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Expect.Registry.Infrastructure.Commands.LoadRegestry
{
	public class LoadRegistryQuery : ILoadRegistry<IViewModel>
	{
		public RegistryType RegistryType { get; }

		public LoadRegistryQuery(RegistryType registryType)
		{
			RegistryType = registryType;
		}
	}

	public class LoadRegistryQueryHandler : ILoadRegistryHandler<LoadRegistryQuery> 
	{
		private readonly IApplicationDbContext _context;
		private readonly IMapper _mapper;
		private readonly IConfiguration _configuration;

		public LoadRegistryQueryHandler(IApplicationDbContext context, IMapper mapper, IConfiguration configuration)
		{
			_context = context;
			_mapper = mapper;
			_configuration = configuration;
		}

		public async Task<IEnumerable<IViewModel>> Handle(LoadRegistryQuery request, CancellationToken cancellationToken)
		{
			return request.RegistryType switch
			{
				RegistryType.Basic => await _context.BasicDocuments
										.Where(doc => doc.Discriminator == Guid.Parse(_configuration["Discriminators:Basic"]!))
										.OfType<BasicDocument>()
										.ProjectTo<BasicDocumentViewModel>(_mapper.ConfigurationProvider)
										.ToListAsync(cancellationToken),
				RegistryType.Incoming => await _context.BasicDocuments
										.Where(doc => doc.Discriminator == Guid.Parse(_configuration["Discriminators:Incoming"]!))
										.OfType<IncomingDocument>()
										.ProjectTo<IncomingDocumentViewModel>(_mapper.ConfigurationProvider)
										.ToListAsync(cancellationToken),
				_ => new List<IViewModel>()
			};
		}
	}
}