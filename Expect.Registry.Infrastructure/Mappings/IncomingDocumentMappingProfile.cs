using AutoMapper;
using Expect.Registry.Domain.Models;
using Expect.Registry.Domain.ViewModels;

namespace Expect.Registry.Infrastructure.Mappings
{
	public class IncomingDocumentMappingProfile : Profile
	{
		public IncomingDocumentMappingProfile()
		{
			CreateMap<IncomingDocument, IncomingDocumentViewModel>()
				.IncludeBase<BasicDocument, BasicDocumentViewModel>()
				.ForMember(vm => vm.Addresse,
					opt => opt.MapFrom(doc => string.Join('\n', doc.Addressee.Select(ad => ad.Addressee.FullName))))
				.ForMember(vm => vm.DeliveryMethod,
					opt => opt.MapFrom(doc => string.Join('\n', doc.DeliveryMethod.Select(ad => ad.DeliveryMethod.Name))))
				.ForMember(vm => vm.CameFrom,
					opt => opt.MapFrom(doc => string.Join('\n', doc.CameFrom.Select(ad => ad.CameFrom.Name))))
				.ForMember(vm => vm.CounterParty,
					opt => opt.MapFrom(doc => string.Join('\n', doc.CounterParty.Select(ad => ad.CounterParty.Name))));
		}
	}
}