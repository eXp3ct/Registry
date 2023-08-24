using AutoMapper;
using Expect.Registry.Data.Interfaces;
using Expect.Registry.Domain.JoinEntities;
using Expect.Registry.Domain.Models;
using Expect.Registry.Domain.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Expect.Registry.Infrastructure.Commands.CreateDocument
{
	public class CreateDocumentQuery : IRequest
	{
		public BasicDocumentViewModel DocumentVm { get; set; }

		public CreateDocumentQuery(BasicDocumentViewModel documentVm)
		{
			DocumentVm = documentVm;
		}
	}

	public class CreateDocumentQueryHandler : IRequestHandler<CreateDocumentQuery>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMapper _mapper;

		public CreateDocumentQueryHandler(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task Handle(CreateDocumentQuery request, CancellationToken cancellationToken)
		{
			var kinds = await _context.DocumentKinds
				.ToListAsync(cancellationToken);

			if (request.DocumentVm.GetType() == typeof(BasicDocumentViewModel))
			{
				var document = _mapper.Map<BasicDocument>(request.DocumentVm);
				var kind = kinds.Find(x => x.Name == "Basic");
				var join = new DocumentKindBasicDocument
				{
					BasicDocument = document,
					DocumentKind = kind!
				};

				await _context.DocumentKindBasicDocuments.AddAsync(join, cancellationToken);
				await _context.BasicDocuments.AddAsync(document, cancellationToken);
			}
			else if (request.DocumentVm.GetType() == typeof(IncomingDocumentViewModel))
			{
				var incoming = ((IncomingDocumentViewModel)request.DocumentVm);
				var document = _mapper.Map<IncomingDocument>(incoming);
				var kind = kinds.Find(x => x.Name == "Incoming");
				var joinKind = new DocumentKindBasicDocument
				{
					BasicDocument = document,
					DocumentKind = kind!,
				};
				var addresse = new List<Addressee>();
				var cameFroms = new List<CameFrom>();
				var counterParties = new List<CounterParty>();
				var deliveryMethods = new List<DeliveryMethod>();
				var joinAddresse = new List<AddresseIncomingDocument>();
				var joinCameFrom = new List<CameFromIncomingDocument>();
				var joinCounterParty = new List<CounterPartyIncomingDocument>();
				var joinDeliveryMethod = new List<DeliveryMethodIncomingDocument>();
				incoming.Addresse.Trim().Split(',').ToList().ForEach(x => addresse.Add(new Addressee { FullName = x }));
				incoming.CameFrom.Trim().Split(',').ToList().ForEach(x => cameFroms.Add(new CameFrom { Name = x }));
				incoming.CounterParty.Trim().Split(',').ToList().ForEach(x => counterParties.Add(new CounterParty { Name = x }));
				incoming.DeliveryMethod.Trim().Split(',').ToList().ForEach(x => deliveryMethods.Add(new DeliveryMethod { Name = x }));

				addresse.ForEach(x => joinAddresse.Add(new AddresseIncomingDocument
				{
					Addressee = x,
					IncomingDocument = document,
				}));
				cameFroms.ForEach(x => joinCameFrom.Add(new CameFromIncomingDocument
				{
					CameFrom = x,
					IncomingDocument = document,
				}));
				counterParties.ForEach(x => joinCounterParty.Add(new CounterPartyIncomingDocument
				{
					CounterParty = x,
					IncomingDocument = document,
				}));
				deliveryMethods.ForEach(x => joinDeliveryMethod.Add(new DeliveryMethodIncomingDocument
				{
					DeliveryMethod = x,
					IncomingDocument = document,
				}));

				await _context.Addressees.AddRangeAsync(addresse, cancellationToken);
				await _context.CounterParties.AddRangeAsync(counterParties, cancellationToken);
				await _context.DeliveryMethods.AddRangeAsync(deliveryMethods, cancellationToken);
				await _context.CameFroms.AddRangeAsync(cameFroms, cancellationToken);

				await _context.AddresseIncomingDocuments.AddRangeAsync(joinAddresse, cancellationToken);
				await _context.CameFromIncomingDocuments.AddRangeAsync(joinCameFrom, cancellationToken);
				await _context.CounterPartyIncomingDocuments.AddRangeAsync(joinCounterParty, cancellationToken);
				await _context.DeliveryMethodIncomingDocuments.AddRangeAsync(joinDeliveryMethod, cancellationToken);

				await _context.DocumentKindBasicDocuments.AddAsync(joinKind, cancellationToken);
				await _context.BasicDocuments.AddAsync(document, cancellationToken);
			}

			await _context.SaveChangesAsync(cancellationToken);
		}
	}
}