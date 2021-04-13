using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace demo1.Migrations
{
	public partial class init3 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "devices",
				columns: table => new
				{
					id = table.Column<int>(type: "integer", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					name = table.Column<string>(type: "text", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_devices", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "positions_gcs",
				columns: table => new
				{
					time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
					device_id = table.Column<int>(type: "integer", nullable: false),
					longitude = table.Column<float>(type: "real", nullable: false),
					latitude = table.Column<float>(type: "real", nullable: false)
				},
				constraints: table =>
				{
					table.ForeignKey(
						name: "FK_positions_gcs_devices_device_id",
						column: x => x.device_id,
						principalTable: "devices",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "temperatures",
				columns: table => new
				{
					time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
					device_id = table.Column<int>(type: "integer", nullable: false),
					temperature = table.Column<float>(type: "real", nullable: false)
				},
				constraints: table =>
				{
					table.ForeignKey(
						name: "FK_temperatures_devices_device_id",
						column: x => x.device_id,
						principalTable: "devices",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_positions_gcs_device_id",
				table: "positions_gcs",
				column: "device_id");

			migrationBuilder.CreateIndex(
				name: "IX_temperatures_device_id",
				table: "temperatures",
				column: "device_id");
				
			migrationBuilder.Sql("SELECT create_hypertable('temperatures', 'time', 'device_id', 2);");
			migrationBuilder.Sql("SELECT create_hypertable('positions_gcs', 'time', 'device_id', 2);");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "positions_gcs");

			migrationBuilder.DropTable(
				name: "temperatures");

			migrationBuilder.DropTable(
				name: "devices");
		}
	}
}
