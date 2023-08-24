using AutoMapper;
using Expect.Registry.Domain.Models;
using Expect.Registry.Domain.ViewModels;

namespace Expect.Registry.Infrastructure.Mappings
{
	public class BasicDocumentMappingProfile : Profile
	{
		public BasicDocumentMappingProfile()
		{
			CreateMap<BasicDocument, BasicDocumentViewModel>()
				.ForMember(vm => vm.DocumentKind,
					opt => opt.MapFrom(doc =>
						string.Join('\n', doc.JoinDocumentKind
							.Select(join => join.DocumentKind.Name))));
		}
	}
}