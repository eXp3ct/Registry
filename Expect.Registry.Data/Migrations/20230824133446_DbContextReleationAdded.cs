using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Expect.Registry.Data.Migrations
{
	/// <inheritdoc />
	public partial class DbContextReleationAdded : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_CameFromIncomingDocuments_CameFrom_CameFromId",
				table: "CameFromIncomingDocuments");

			migrationBuilder.DropPrimaryKey(
				name: "PK_CameFrom",
				table: "CameFrom");

			migrationBuilder.RenameTable(
				name: "CameFrom",
				newName: "CameFroms");

			migrationBuilder.AddPrimaryKey(
				name: "PK_CameFroms",
				table: "CameFroms",
				column: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_CameFromIncomingDocuments_CameFroms_CameFromId",
				table: "CameFromIncomingDocuments",
				column: "CameFromId",
				principalTable: "CameFroms",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_CameFromIncomingDocuments_CameFroms_CameFromId",
				table: "CameFromIncomingDocuments");

			migrationBuilder.DropPrimaryKey(
				name: "PK_CameFroms",
				table: "CameFroms");

			migrationBuilder.RenameTable(
				name: "CameFroms",
				newName: "CameFrom");

			migrationBuilder.AddPrimaryKey(
				name: "PK_CameFrom",
				table: "CameFrom",
				column: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_CameFromIncomingDocuments_CameFrom_CameFromId",
				table: "CameFromIncomingDocuments",
				column: "CameFromId",
				principalTable: "CameFrom",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}
	}
}