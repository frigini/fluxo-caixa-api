using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FluxoCaixa.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddDataToTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("f2057168-9e8b-4cfa-a0bf-e114830731db"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6628ff16-2652-4045-84d8-8719e770089d"));

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "CreatedAt", "Description", "PaymentDate", "PaymentType", "PaymentValue", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("4cc732e5-eb95-43db-b55c-1e5d83cc35e3"), new DateTime(2024, 7, 10, 1, 9, 44, 349, DateTimeKind.Local).AddTicks(4154), "Restaurante", new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 100.0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("946e0050-86e7-42f7-ac17-9f9e48dbab75"), new DateTime(2024, 7, 10, 1, 9, 44, 349, DateTimeKind.Local).AddTicks(4149), "Assinatura streaming", new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 20.0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d36dd245-f6ed-45e9-8d53-86621fb6be66"), new DateTime(2024, 7, 10, 1, 9, 44, 349, DateTimeKind.Local).AddTicks(4143), "Conta de Luz", new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 200.0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d5ca8048-e6b2-4bf3-a482-fb2a893efe18"), new DateTime(2024, 7, 10, 1, 9, 44, 349, DateTimeKind.Local).AddTicks(4026), "Salário", new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2000.0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Password", "UpdatedAt", "Username" },
                values: new object[] { new Guid("fdf75ccb-c77a-4848-8807-e0821259a0ac"), new DateTime(2024, 7, 10, 1, 9, 44, 349, DateTimeKind.Local).AddTicks(3832), "123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("4cc732e5-eb95-43db-b55c-1e5d83cc35e3"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("946e0050-86e7-42f7-ac17-9f9e48dbab75"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("d36dd245-f6ed-45e9-8d53-86621fb6be66"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("d5ca8048-e6b2-4bf3-a482-fb2a893efe18"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fdf75ccb-c77a-4848-8807-e0821259a0ac"));

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "CreatedAt", "Description", "PaymentDate", "PaymentType", "PaymentValue", "UpdatedAt" },
                values: new object[] { new Guid("f2057168-9e8b-4cfa-a0bf-e114830731db"), new DateTime(2024, 7, 10, 0, 56, 19, 238, DateTimeKind.Local).AddTicks(5678), "Salário", new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2000.0m, new DateTime(2024, 7, 10, 0, 56, 19, 238, DateTimeKind.Local).AddTicks(6302) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Password", "UpdatedAt", "Username" },
                values: new object[] { new Guid("6628ff16-2652-4045-84d8-8719e770089d"), new DateTime(2024, 7, 10, 0, 56, 19, 238, DateTimeKind.Local).AddTicks(5410), "123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" });
        }
    }
}
