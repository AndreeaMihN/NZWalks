using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataFOrDIfficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6ae2ebd0-18be-4814-aaf7-88a490c156d8"), "Medium" },
                    { new Guid("8a92bb87-047b-434c-9313-af3bf640d500"), "Easy" },
                    { new Guid("e9a0658e-3ad6-43f5-bf38-0b9c75d49742"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("463d1d81-ba8e-41d6-b623-4991c0dd44e1"), "STL", "Southland", null },
                    { new Guid("4d153e35-3652-47f5-8bff-57bec623395b"), "AKL", "Auckland", "https://somthig.jpg" },
                    { new Guid("86bfe4e4-8571-44aa-960e-377c22c752bb"), "NTL", "Northland", null },
                    { new Guid("977b4c76-42ad-4e23-b20f-617519f8d12c"), "BOP", "Bay of Plenty", null },
                    { new Guid("aba7c750-d54d-4aa5-bb01-c4b6587d8b57"), "WGN", "Wellington", "https://somthig.jpg" },
                    { new Guid("c22d158e-838c-42b9-916c-21b96f4e96ad"), "NSN", "Nelson", "https://somthig.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("6ae2ebd0-18be-4814-aaf7-88a490c156d8"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("8a92bb87-047b-434c-9313-af3bf640d500"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("e9a0658e-3ad6-43f5-bf38-0b9c75d49742"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("463d1d81-ba8e-41d6-b623-4991c0dd44e1"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4d153e35-3652-47f5-8bff-57bec623395b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("86bfe4e4-8571-44aa-960e-377c22c752bb"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("977b4c76-42ad-4e23-b20f-617519f8d12c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("aba7c750-d54d-4aa5-bb01-c4b6587d8b57"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c22d158e-838c-42b9-916c-21b96f4e96ad"));
        }
    }
}
