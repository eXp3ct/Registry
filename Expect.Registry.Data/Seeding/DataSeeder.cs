using Expect.Registry.Domain.JoinEntities;
using Expect.Registry.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Expect.Registry.Data.Seeding
{
	public static class DataSeeder
	{
		public static void Seed(this ModelBuilder builder)
		{
			var kindBasic = new DocumentKind
			{
				Id = 1,
				Name = "Basic"
			};
			var kindIncoming = new DocumentKind
			{
				Id = 2,
				Name = "Incoming"
			};

			var basic1 = new BasicDocument
			{
				Id = 1,
				//Discriminator = Discriminator1,
				DocumentNumber = "BasicDocNumber1",
				Name = "BasicDocName1",
				Subject = "BasicDocSubject1"
			};

			var basic2 = new BasicDocument
			{
				Id = 2,
				//Discriminator = Discriminator1,
				DocumentNumber = "BasicDocNumber2",
				Name = "BasicDocName1",
				Subject = "BasicDocSubject1"
			};

			var joinKindBasic = new DocumentKindBasicDocument
			{
				Id = 1,
				BasicDocumentId = basic1.Id,
				DocumentKindId = kindBasic.Id
			};
			var joinKindBasic2 = new DocumentKindBasicDocument
			{
				Id = 2,
				BasicDocumentId = basic2.Id,
				DocumentKindId = kindBasic.Id
			};

			var incoming1 = new IncomingDocument
			{
				Id = 3,
				//Discriminator = Discriminator2,
				DocumentNumber = "IncomingDocNumber1",
				Name = "IncomingDocName1",
				Subject = "IncomingDocSubject1"
			};

			var incoming2 = new IncomingDocument
			{
				Id = 4,
				//Discriminator = Discriminator2,
				DocumentNumber = "IncomingDocNumber2",
				Name = "IncomingDocName2",
				Subject = "IncomingDocSubject2"
			};

			var joinKind3 = new DocumentKindBasicDocument
			{
				Id = 3,
				BasicDocumentId = incoming1.Id,
				DocumentKindId = kindIncoming.Id
			};
			var joinKind4 = new DocumentKindBasicDocument
			{
				Id = 4,
				BasicDocumentId = incoming2.Id,
				DocumentKindId = kindIncoming.Id
			};

			var addresse1 = new Addressee
			{
				Id = 1,
				FullName = "Veselov Roman"
			};
			var addresse2 = new Addressee
			{
				Id = 2,
				FullName = "John Doe"
			};
			var deliveryMethod1 = new DeliveryMethod
			{
				Id = 1,
				Name = "Email"
			};
			var deliveryMethod2 = new DeliveryMethod
			{
				Id = 2,
				Name = "Mail"
			};
			var deliveryMethod3 = new DeliveryMethod
			{
				Id = 3,
				Name = "EMDS"
			};
			var counterParty1 = new CounterParty
			{
				Id = 1,
				Name = "Organization 1"
			};
			var counterParty2 = new CounterParty
			{
				Id = 2,
				Name = "Organization 2"
			};
			var counterParty3 = new CounterParty
			{
				Id = 3,
				Name = "Organization 3"
			};
			var cameFrom1 = new CounterParty
			{
				Id = 1,
				Name = "Organization 1"
			};
			var cameFrom2 = new CounterParty
			{
				Id = 2,
				Name = "Organization 2"
			};
			var cameFrom3 = new CounterParty
			{
				Id = 3,
				Name = "Organization 3"
			};

			var joinAddresse1 = new AddresseIncomingDocument
			{
				Id = 1,
				AddresseId = addresse1.Id,
				IncomingDocumentId = incoming1.Id
			};
			var joinAddresse2 = new AddresseIncomingDocument
			{
				Id = 2,
				AddresseId = addresse2.Id,
				IncomingDocumentId = incoming1.Id
			};
			var joinAddresse3 = new AddresseIncomingDocument
			{
				Id = 3,
				AddresseId = addresse1.Id,
				IncomingDocumentId = incoming2.Id
			};
			var joinCameFrom1 = new CameFromIncomingDocument
			{
				Id = 1,
				CameFromId = cameFrom1.Id,
				IncomingDocumentId = incoming1.Id
			};
			var joinCameFrom2 = new CameFromIncomingDocument
			{
				Id = 2,
				CameFromId = cameFrom1.Id,
				IncomingDocumentId = incoming2.Id
			};
			var joinCameFrom3 = new CameFromIncomingDocument
			{
				Id = 3,
				CameFromId = cameFrom2.Id,
				IncomingDocumentId = incoming2.Id
			};
			var joinCounterParty1 = new CounterPartyIncomingDocument
			{
				Id = 1,
				CounterPartyId = counterParty1.Id,
				IncomingDocumentId = incoming1.Id
			};
			var joinCounterParty2 = new CounterPartyIncomingDocument
			{
				Id = 2,
				CounterPartyId = counterParty2.Id,
				IncomingDocumentId = incoming2.Id
			};
			var joinCounterParty3 = new CounterPartyIncomingDocument
			{
				Id = 3,
				CounterPartyId = counterParty1.Id,
				IncomingDocumentId = incoming2.Id
			};
			var joinDelivertyMethod1 = new DeliveryMethodIncomingDocument
			{
				Id = 1,
				DeliveryMethodId = deliveryMethod1.Id,
				IncomingDocumentId = incoming1.Id
			};
			var joinDelivertyMethod2 = new DeliveryMethodIncomingDocument
			{
				Id = 2,
				DeliveryMethodId = deliveryMethod2.Id,
				IncomingDocumentId = incoming1.Id
			};
			var joinDelivertyMethod3 = new DeliveryMethodIncomingDocument
			{
				Id = 3,
				DeliveryMethodId = deliveryMethod3.Id,
				IncomingDocumentId = incoming1.Id
			};
			var joinDelivertyMethod4 = new DeliveryMethodIncomingDocument
			{
				Id = 4,
				DeliveryMethodId = deliveryMethod2.Id,
				IncomingDocumentId = incoming2.Id
			};

			builder.Entity<DocumentKind>().HasData(kindBasic, kindIncoming);
			builder.Entity<Addressee>().HasData(addresse1, addresse2);
			builder.Entity<CameFrom>().HasData(cameFrom1, cameFrom2, cameFrom3);
			builder.Entity<CounterParty>().HasData(counterParty1, counterParty2, counterParty3);
			builder.Entity<DeliveryMethod>().HasData(deliveryMethod1, deliveryMethod2, deliveryMethod3);
			builder.Entity<BasicDocument>().HasData(basic1, basic2);
			builder.Entity<DocumentKindBasicDocument>().HasData(joinKindBasic, joinKindBasic2, joinKind3, joinKind4);
			builder.Entity<IncomingDocument>().HasData(incoming1, incoming2);
			builder.Entity<AddresseIncomingDocument>().HasData(joinAddresse1, joinAddresse2, joinAddresse3);
			builder.Entity<CameFromIncomingDocument>().HasData(joinCameFrom1, joinCameFrom2, joinCameFrom3);
			builder.Entity<CounterPartyIncomingDocument>().HasData(joinCounterParty1, joinCounterParty2, joinCounterParty3);
			builder.Entity<DeliveryMethodIncomingDocument>().HasData(joinDelivertyMethod1, joinDelivertyMethod2, joinDelivertyMethod3, joinDelivertyMethod4);
		}
	}
}