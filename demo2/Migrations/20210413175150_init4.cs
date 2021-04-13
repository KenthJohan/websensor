using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace demo1.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_temperatures_devices_device_id",
                table: "temperatures");

            migrationBuilder.DropTable(
                name: "positions_gcs");

            migrationBuilder.RenameTable(
                name: "temperatures",
                newName: "Sensorvalue");

            migrationBuilder.RenameIndex(
                name: "IX_temperatures_device_id",
                table: "Sensorvalue",
                newName: "IX_Sensorvalue_device_id");

            migrationBuilder.AlterColumn<float>(
                name: "temperature",
                table: "Sensorvalue",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<float>(
                name: "latitude",
                table: "Sensorvalue",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "longitude",
                table: "Sensorvalue",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "Sensorvalue",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Sensorvalue_devices_device_id",
                table: "Sensorvalue",
                column: "device_id",
                principalTable: "devices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sensorvalue_devices_device_id",
                table: "Sensorvalue");

            migrationBuilder.DropColumn(
                name: "latitude",
                table: "Sensorvalue");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "Sensorvalue");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "Sensorvalue");

            migrationBuilder.RenameTable(
                name: "Sensorvalue",
                newName: "temperatures");

            migrationBuilder.RenameIndex(
                name: "IX_Sensorvalue_device_id",
                table: "temperatures",
                newName: "IX_temperatures_device_id");

            migrationBuilder.AlterColumn<float>(
                name: "temperature",
                table: "temperatures",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "positions_gcs",
                columns: table => new
                {
                    device_id = table.Column<int>(type: "integer", nullable: false),
                    latitude = table.Column<float>(type: "real", nullable: false),
                    longitude = table.Column<float>(type: "real", nullable: false),
                    time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_positions_gcs_device_id",
                table: "positions_gcs",
                column: "device_id");

            migrationBuilder.AddForeignKey(
                name: "FK_temperatures_devices_device_id",
                table: "temperatures",
                column: "device_id",
                principalTable: "devices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
