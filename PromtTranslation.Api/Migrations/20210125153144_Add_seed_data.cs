using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PromtTranslation.Api.Migrations
{
    public partial class Add_seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TranslationTextModel_TranslationModel_TranslationModelId",
                table: "TranslationTextModel");

            migrationBuilder.AlterColumn<Guid>(
                name: "TranslationModelId",
                table: "TranslationTextModel",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "RouteModel",
                columns: new[] { "Id", "RouteName" },
                values: new object[,]
                {
                    { new Guid("39ae78b7-2b8a-43df-9499-145a6c1e8d10"), "ru" },
                    { new Guid("2f803145-f343-4481-849c-556eaa2c9571"), "en" },
                    { new Guid("1d7926ed-fbd0-4ab3-ba82-cade9bb79129"), "fr" },
                    { new Guid("061f4be2-10e8-4904-90e4-eb91a5a97668"), "it" },
                    { new Guid("0a52de70-c1d1-4654-bb94-cbb0b39a2f5d"), "da" }
                });

            migrationBuilder.InsertData(
                table: "StatusModel",
                columns: new[] { "Id", "StatusValue" },
                values: new object[,]
                {
                    { new Guid("7c4687c6-fddf-470c-b697-6a64528804c1"), "Добавлен" },
                    { new Guid("105cd0f4-a93e-4971-bdd4-a4c752813a6c"), "Обрабатывается" },
                    { new Guid("b4773afd-793c-46bf-9a9c-f54c75306612"), "Обравботан" }
                });

            migrationBuilder.InsertData(
                table: "LanguageRouteStepsModel",
                columns: new[] { "Id", "LanguageFrom", "LanguageTo", "RouteId" },
                values: new object[,]
                {
                    { new Guid("9dff18fc-2aa8-40e1-a4ad-8c0e4e8af887"), "ru", "en", new Guid("39ae78b7-2b8a-43df-9499-145a6c1e8d10") },
                    { new Guid("87f50c0a-f4ee-4efc-93d6-28bd45da8c47"), "da", "it", new Guid("0a52de70-c1d1-4654-bb94-cbb0b39a2f5d") },
                    { new Guid("bfe8a521-8ba9-42eb-b057-790dc3ef0a75"), "da", "en", new Guid("0a52de70-c1d1-4654-bb94-cbb0b39a2f5d") },
                    { new Guid("76b665df-3c08-4281-9831-9a65ed094ce5"), "it", "da", new Guid("061f4be2-10e8-4904-90e4-eb91a5a97668") },
                    { new Guid("69486995-40d6-424b-9040-cb31500390a7"), "it", "fr", new Guid("061f4be2-10e8-4904-90e4-eb91a5a97668") },
                    { new Guid("16da83cd-e58e-4891-be53-2d70c456a887"), "it", "en", new Guid("061f4be2-10e8-4904-90e4-eb91a5a97668") },
                    { new Guid("6a40c7ec-5892-4f9e-aa01-e4a9ddd3fb91"), "it", "ru", new Guid("061f4be2-10e8-4904-90e4-eb91a5a97668") },
                    { new Guid("2ffb76ac-bcff-428b-acf9-8198e2f1db24"), "fr", "da", new Guid("1d7926ed-fbd0-4ab3-ba82-cade9bb79129") },
                    { new Guid("e384dea0-7bd5-48e5-92ee-7219345fd63b"), "fr", "it", new Guid("1d7926ed-fbd0-4ab3-ba82-cade9bb79129") },
                    { new Guid("2b49b3b9-ea68-4eed-9f38-e380b2cc8c5e"), "fr", "en", new Guid("1d7926ed-fbd0-4ab3-ba82-cade9bb79129") },
                    { new Guid("c34c0955-2516-40c2-8e92-616130a85fc0"), "fr", "ru", new Guid("1d7926ed-fbd0-4ab3-ba82-cade9bb79129") },
                    { new Guid("d6f6eade-e731-43c4-9874-ea29352f70ec"), "en", "it", new Guid("2f803145-f343-4481-849c-556eaa2c9571") },
                    { new Guid("e180ca3e-4516-4cf6-b966-8458db70b870"), "en", "fr", new Guid("2f803145-f343-4481-849c-556eaa2c9571") },
                    { new Guid("327aa458-9c53-46e8-998b-9a1c5ec7b087"), "en", "da", new Guid("2f803145-f343-4481-849c-556eaa2c9571") },
                    { new Guid("0a95de40-468b-4d4c-b97f-53d4b3616de1"), "en", "ru", new Guid("2f803145-f343-4481-849c-556eaa2c9571") },
                    { new Guid("d5cd212b-5a47-49cb-bca9-12fdd86ee304"), "en", "da", new Guid("39ae78b7-2b8a-43df-9499-145a6c1e8d10") },
                    { new Guid("36ff39a8-33cf-4b3f-90e5-6480508aaf53"), "ru", "it", new Guid("39ae78b7-2b8a-43df-9499-145a6c1e8d10") },
                    { new Guid("19a012c9-7b00-4cc9-b7fa-21d0872c8f65"), "ru", "fr", new Guid("39ae78b7-2b8a-43df-9499-145a6c1e8d10") },
                    { new Guid("b93422af-377e-4cd3-b798-0e55455f7397"), "da", "fr", new Guid("0a52de70-c1d1-4654-bb94-cbb0b39a2f5d") },
                    { new Guid("b00bbeeb-e964-41a0-bf3a-36517f5f6e5b"), "en", "ru", new Guid("0a52de70-c1d1-4654-bb94-cbb0b39a2f5d") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TranslationTextModel_TranslationModel_TranslationModelId",
                table: "TranslationTextModel",
                column: "TranslationModelId",
                principalTable: "TranslationModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TranslationTextModel_TranslationModel_TranslationModelId",
                table: "TranslationTextModel");

            migrationBuilder.DeleteData(
                table: "LanguageRouteStepsModel",
                keyColumn: "Id",
                keyValue: new Guid("0a95de40-468b-4d4c-b97f-53d4b3616de1"));

            migrationBuilder.DeleteData(
                table: "LanguageRouteStepsModel",
                keyColumn: "Id",
                keyValue: new Guid("16da83cd-e58e-4891-be53-2d70c456a887"));

            migrationBuilder.DeleteData(
                table: "LanguageRouteStepsModel",
                keyColumn: "Id",
                keyValue: new Guid("19a012c9-7b00-4cc9-b7fa-21d0872c8f65"));

            migrationBuilder.DeleteData(
                table: "LanguageRouteStepsModel",
                keyColumn: "Id",
                keyValue: new Guid("2b49b3b9-ea68-4eed-9f38-e380b2cc8c5e"));

            migrationBuilder.DeleteData(
                table: "LanguageRouteStepsModel",
                keyColumn: "Id",
                keyValue: new Guid("2ffb76ac-bcff-428b-acf9-8198e2f1db24"));

            migrationBuilder.DeleteData(
                table: "LanguageRouteStepsModel",
                keyColumn: "Id",
                keyValue: new Guid("327aa458-9c53-46e8-998b-9a1c5ec7b087"));

            migrationBuilder.DeleteData(
                table: "LanguageRouteStepsModel",
                keyColumn: "Id",
                keyValue: new Guid("36ff39a8-33cf-4b3f-90e5-6480508aaf53"));

            migrationBuilder.DeleteData(
                table: "LanguageRouteStepsModel",
                keyColumn: "Id",
                keyValue: new Guid("69486995-40d6-424b-9040-cb31500390a7"));

            migrationBuilder.DeleteData(
                table: "LanguageRouteStepsModel",
                keyColumn: "Id",
                keyValue: new Guid("6a40c7ec-5892-4f9e-aa01-e4a9ddd3fb91"));

            migrationBuilder.DeleteData(
                table: "LanguageRouteStepsModel",
                keyColumn: "Id",
                keyValue: new Guid("76b665df-3c08-4281-9831-9a65ed094ce5"));

            migrationBuilder.DeleteData(
                table: "LanguageRouteStepsModel",
                keyColumn: "Id",
                keyValue: new Guid("87f50c0a-f4ee-4efc-93d6-28bd45da8c47"));

            migrationBuilder.DeleteData(
                table: "LanguageRouteStepsModel",
                keyColumn: "Id",
                keyValue: new Guid("9dff18fc-2aa8-40e1-a4ad-8c0e4e8af887"));

            migrationBuilder.DeleteData(
                table: "LanguageRouteStepsModel",
                keyColumn: "Id",
                keyValue: new Guid("b00bbeeb-e964-41a0-bf3a-36517f5f6e5b"));

            migrationBuilder.DeleteData(
                table: "LanguageRouteStepsModel",
                keyColumn: "Id",
                keyValue: new Guid("b93422af-377e-4cd3-b798-0e55455f7397"));

            migrationBuilder.DeleteData(
                table: "LanguageRouteStepsModel",
                keyColumn: "Id",
                keyValue: new Guid("bfe8a521-8ba9-42eb-b057-790dc3ef0a75"));

            migrationBuilder.DeleteData(
                table: "LanguageRouteStepsModel",
                keyColumn: "Id",
                keyValue: new Guid("c34c0955-2516-40c2-8e92-616130a85fc0"));

            migrationBuilder.DeleteData(
                table: "LanguageRouteStepsModel",
                keyColumn: "Id",
                keyValue: new Guid("d5cd212b-5a47-49cb-bca9-12fdd86ee304"));

            migrationBuilder.DeleteData(
                table: "LanguageRouteStepsModel",
                keyColumn: "Id",
                keyValue: new Guid("d6f6eade-e731-43c4-9874-ea29352f70ec"));

            migrationBuilder.DeleteData(
                table: "LanguageRouteStepsModel",
                keyColumn: "Id",
                keyValue: new Guid("e180ca3e-4516-4cf6-b966-8458db70b870"));

            migrationBuilder.DeleteData(
                table: "LanguageRouteStepsModel",
                keyColumn: "Id",
                keyValue: new Guid("e384dea0-7bd5-48e5-92ee-7219345fd63b"));

            migrationBuilder.DeleteData(
                table: "StatusModel",
                keyColumn: "Id",
                keyValue: new Guid("105cd0f4-a93e-4971-bdd4-a4c752813a6c"));

            migrationBuilder.DeleteData(
                table: "StatusModel",
                keyColumn: "Id",
                keyValue: new Guid("7c4687c6-fddf-470c-b697-6a64528804c1"));

            migrationBuilder.DeleteData(
                table: "StatusModel",
                keyColumn: "Id",
                keyValue: new Guid("b4773afd-793c-46bf-9a9c-f54c75306612"));

            migrationBuilder.DeleteData(
                table: "RouteModel",
                keyColumn: "Id",
                keyValue: new Guid("061f4be2-10e8-4904-90e4-eb91a5a97668"));

            migrationBuilder.DeleteData(
                table: "RouteModel",
                keyColumn: "Id",
                keyValue: new Guid("0a52de70-c1d1-4654-bb94-cbb0b39a2f5d"));

            migrationBuilder.DeleteData(
                table: "RouteModel",
                keyColumn: "Id",
                keyValue: new Guid("1d7926ed-fbd0-4ab3-ba82-cade9bb79129"));

            migrationBuilder.DeleteData(
                table: "RouteModel",
                keyColumn: "Id",
                keyValue: new Guid("2f803145-f343-4481-849c-556eaa2c9571"));

            migrationBuilder.DeleteData(
                table: "RouteModel",
                keyColumn: "Id",
                keyValue: new Guid("39ae78b7-2b8a-43df-9499-145a6c1e8d10"));

            migrationBuilder.AlterColumn<Guid>(
                name: "TranslationModelId",
                table: "TranslationTextModel",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_TranslationTextModel_TranslationModel_TranslationModelId",
                table: "TranslationTextModel",
                column: "TranslationModelId",
                principalTable: "TranslationModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
