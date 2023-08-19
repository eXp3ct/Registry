using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Expect.Registry.Data.Migrations
{
	/// <inheritdoc />
	public partial class Initial : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Addressees",
				columns: table => new
				{
					Id = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					FullName = table.Column<string>(type: "text", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Addressees", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "CameFrom",
				columns: table => new
				{
					Id = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					Name = table.Column<string>(type: "text", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_CameFrom", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "CounterParties",
				columns: table => new
				{
					Id = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					Name = table.Column<string>(type: "text", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_CounterParties", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "DeliveryMethods",
				columns: table => new
				{
					Id = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					Name = table.Column<string>(type: "text", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_DeliveryMethods", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "DocumentKinds",
				columns: table => new
				{
					Id = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					Name = table.Column<string>(type: "text", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_DocumentKinds", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Documents",
				columns: table => new
				{
					Id = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					Discriminator = table.Column<Guid>(type: "uuid", nullable: false),
					Name = table.Column<string>(type: "text", nullable: false),
					Subject = table.Column<string>(type: "text", nullable: true),
					DocumentNumber = table.Column<string>(type: "text", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Documents", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "AddresseIncomingDocuments",
				columns: table => new
				{
					Id = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					AddresseId = table.Column<int>(type: "integer", nullable: false),
					IncomingDocumentId = table.Column<int>(type: "integer", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AddresseIncomingDocuments", x => x.Id);
					table.ForeignKey(
						name: "FK_AddresseIncomingDocuments_Addressees_AddresseId",
						column: x => x.AddresseId,
						principalTable: "Addressees",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_AddresseIncomingDocuments_Documents_IncomingDocumentId",
						column: x => x.IncomingDocumentId,
						principalTable: "Documents",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "CameFromIncomingDocuments",
				columns: table => new
				{
					Id = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					CameFromId = table.Column<int>(type: "integer", nullable: false),
					IncomingDocumentId = table.Column<int>(type: "integer", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_CameFromIncomingDocuments", x => x.Id);
					table.ForeignKey(
						name: "FK_CameFromIncomingDocuments_CameFrom_CameFromId",
						column: x => x.CameFromId,
						principalTable: "CameFrom",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_CameFromIncomingDocuments_Documents_IncomingDocumentId",
						column: x => x.IncomingDocumentId,
						principalTable: "Documents",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "CounterPartyIncomingDocuments",
				columns: table => new
				{
					Id = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					CounterPartyId = table.Column<int>(type: "integer", nullable: false),
					IncomingDocumentId = table.Column<int>(type: "integer", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_CounterPartyIncomingDocuments", x => x.Id);
					table.ForeignKey(
						name: "FK_CounterPartyIncomingDocuments_CounterParties_CounterPartyId",
						column: x => x.CounterPartyId,
						principalTable: "CounterParties",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_CounterPartyIncomingDocuments_Documents_IncomingDocumentId",
						column: x => x.IncomingDocumentId,
						principalTable: "Documents",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "DeliveryMethodIncomingDocuments",
				columns: table => new
				{
					Id = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					DeliveryMethodId = table.Column<int>(type: "integer", nullable: false),
					IncomingDocumentId = table.Column<int>(type: "integer", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_DeliveryMethodIncomingDocuments", x => x.Id);
					table.ForeignKey(
						name: "FK_DeliveryMethodIncomingDocuments_DeliveryMethods_DeliveryMet~",
						column: x => x.DeliveryMethodId,
						principalTable: "DeliveryMethods",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_DeliveryMethodIncomingDocuments_Documents_IncomingDocumentId",
						column: x => x.IncomingDocumentId,
						principalTable: "Documents",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "DocumentKindBasicDocuments",
				columns: table => new
				{
					Id = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					DocumentKindId = table.Column<int>(type: "integer", nullable: false),
					BasicDocumentId = table.Column<int>(type: "integer", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_DocumentKindBasicDocuments", x => x.Id);
					table.ForeignKey(
						name: "FK_DocumentKindBasicDocuments_DocumentKinds_DocumentKindId",
						column: x => x.DocumentKindId,
						principalTable: "DocumentKinds",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_DocumentKindBasicDocuments_Documents_BasicDocumentId",
						column: x => x.BasicDocumentId,
						principalTable: "Documents",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.InsertData(
				table: "Addressees",
				columns: new[] { "Id", "FullName" },
				values: new object[,]
				{
					{ 1, "Veselov Roman" },
					{ 2, "John Doe" }
				});

			migrationBuilder.InsertData(
				table: "CameFrom",
				columns: new[] { "Id", "Name" },
				values: new object[,]
				{
					{ 1, "Organization 1" },
					{ 2, "Organization 2" },
					{ 3, "Organization 3" }
				});

			migrationBuilder.InsertData(
				table: "CounterParties",
				columns: new[] { "Id", "Name" },
				values: new object[,]
				{
					{ 1, "Organization 1" },
					{ 2, "Organization 2" },
					{ 3, "Organization 3" }
				});

			migrationBuilder.InsertData(
				table: "DeliveryMethods",
				columns: new[] { "Id", "Name" },
				values: new object[,]
				{
					{ 1, "Email" },
					{ 2, "Mail" },
					{ 3, "EMDS" }
				});

			migrationBuilder.InsertData(
				table: "DocumentKinds",
				columns: new[] { "Id", "Name" },
				values: new object[,]
				{
					{ 1, "Basic" },
					{ 2, "Incoming" }
				});

			migrationBuilder.InsertData(
				table: "Documents",
				columns: new[] { "Id", "Discriminator", "DocumentNumber", "Name", "Subject" },
				values: new object[,]
				{
					{ 1, new Guid("06398d2c-5b15-4d14-a44a-e1cdbc2b4d02"), "BasicDocNumber1", "BasicDocName1", "BasicDocSubject1" },
					{ 2, new Guid("06398d2c-5b15-4d14-a44a-e1cdbc2b4d02"), "BasicDocNumber2", "BasicDocName1", "BasicDocSubject1" },
					{ 3, new Guid("d12dfde5-3397-471a-a07c-628dcafb65a9"), "IncomingDocNumber1", "IncomingDocName1", "IncomingDocSubject1" },
					{ 4, new Guid("d12dfde5-3397-471a-a07c-628dcafb65a9"), "IncomingDocNumber2", "IncomingDocName2", "IncomingDocSubject2" }
				});

			migrationBuilder.InsertData(
				table: "AddresseIncomingDocuments",
				columns: new[] { "Id", "AddresseId", "IncomingDocumentId" },
				values: new object[,]
				{
					{ 1, 1, 3 },
					{ 2, 2, 3 },
					{ 3, 1, 4 }
				});

			migrationBuilder.InsertData(
				table: "CameFromIncomingDocuments",
				columns: new[] { "Id", "CameFromId", "IncomingDocumentId" },
				values: new object[,]
				{
					{ 1, 1, 3 },
					{ 2, 1, 4 },
					{ 3, 2, 4 }
				});

			migrationBuilder.InsertData(
				table: "CounterPartyIncomingDocuments",
				columns: new[] { "Id", "CounterPartyId", "IncomingDocumentId" },
				values: new object[,]
				{
					{ 1, 1, 3 },
					{ 2, 2, 4 },
					{ 3, 1, 4 }
				});

			migrationBuilder.InsertData(
				table: "DeliveryMethodIncomingDocuments",
				columns: new[] { "Id", "DeliveryMethodId", "IncomingDocumentId" },
				values: new object[,]
				{
					{ 1, 1, 3 },
					{ 2, 2, 3 },
					{ 3, 3, 3 },
					{ 4, 2, 4 }
				});

			migrationBuilder.InsertData(
				table: "DocumentKindBasicDocuments",
				columns: new[] { "Id", "BasicDocumentId", "DocumentKindId" },
				values: new object[,]
				{
					{ 1, 1, 1 },
					{ 2, 2, 1 },
					{ 3, 3, 2 },
					{ 4, 4, 2 }
				});

			migrationBuilder.CreateIndex(
				name: "IX_AddresseIncomingDocuments_AddresseId",
				table: "AddresseIncomingDocuments",
				column: "AddresseId");

			migrationBuilder.CreateIndex(
				name: "IX_AddresseIncomingDocuments_IncomingDocumentId",
				table: "AddresseIncomingDocuments",
				column: "IncomingDocumentId");

			migrationBuilder.CreateIndex(
				name: "IX_CameFromIncomingDocuments_CameFromId",
				table: "CameFromIncomingDocuments",
				column: "CameFromId");

			migrationBuilder.CreateIndex(
				name: "IX_CameFromIncomingDocuments_IncomingDocumentId",
				table: "CameFromIncomingDocuments",
				column: "IncomingDocumentId");

			migrationBuilder.CreateIndex(
				name: "IX_CounterPartyIncomingDocuments_CounterPartyId",
				table: "CounterPartyIncomingDocuments",
				column: "CounterPartyId");

			migrationBuilder.CreateIndex(
				name: "IX_CounterPartyIncomingDocuments_IncomingDocumentId",
				table: "CounterPartyIncomingDocuments",
				column: "IncomingDocumentId");

			migrationBuilder.CreateIndex(
				name: "IX_DeliveryMethodIncomingDocuments_DeliveryMethodId",
				table: "DeliveryMethodIncomingDocuments",
				column: "DeliveryMethodId");

			migrationBuilder.CreateIndex(
				name: "IX_DeliveryMethodIncomingDocuments_IncomingDocumentId",
				table: "DeliveryMethodIncomingDocuments",
				column: "IncomingDocumentId");

			migrationBuilder.CreateIndex(
				name: "IX_DocumentKindBasicDocuments_BasicDocumentId",
				table: "DocumentKindBasicDocuments",
				column: "BasicDocumentId");

			migrationBuilder.CreateIndex(
				name: "IX_DocumentKindBasicDocuments_DocumentKindId",
				table: "DocumentKindBasicDocuments",
				column: "DocumentKindId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "AddresseIncomingDocuments");

			migrationBuilder.DropTable(
				name: "CameFromIncomingDocuments");

			migrationBuilder.DropTable(
				name: "CounterPartyIncomingDocuments");

			migrationBuilder.DropTable(
				name: "DeliveryMethodIncomingDocuments");

			migrationBuilder.DropTable(
				name: "DocumentKindBasicDocuments");

			migrationBuilder.DropTable(
				name: "Addressees");

			migrationBuilder.DropTable(
				name: "CameFrom");

			migrationBuilder.DropTable(
				name: "CounterParties");

			migrationBuilder.DropTable(
				name: "DeliveryMethods");

			migrationBuilder.DropTable(
				name: "DocumentKinds");

			migrationBuilder.DropTable(
				name: "Documents");
		}
	}
}