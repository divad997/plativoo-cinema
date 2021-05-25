using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaInfrastructure.Migrations
{
    public partial class MovieConfigurationFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("1d742364-c856-4e31-a0c0-4ae18b631770"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("233bfa34-2741-4663-a561-9810f95c2ee8"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("256153e2-e144-4143-bb07-bc140ff83123"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("a18a46fe-6e6a-4382-9eef-09ac77d8c5cc"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("c1b48aac-263b-4764-ae0d-dd9d51297639"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("df042bb3-70bd-4467-a53f-21e200a75ef8"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("e4de4f51-7e56-4d12-a73e-df884a895f5f"));

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: new Guid("1486270e-3059-4e8d-ba0b-5607080f29d1"));

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: new Guid("b79681d3-e38b-40cc-a654-912e921bcf12"));

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: new Guid("f519ae16-badf-4523-9995-8326a8df3585"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("16460579-6c68-4da9-9d96-de60571fbc27"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("348e8ec3-a092-4a64-a497-6de690349cf3"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("42f12480-a374-471b-9e56-5e83c425a692"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("861e42b0-f6ce-4185-80c5-69f1b46283c0"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("e1a7cf8b-2945-4578-8977-4337d85ebe48"));

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("5b2a83c9-7db4-4d17-8577-8907ef9ea15d"), new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert", "Downey Jr" },
                    { new Guid("96850b21-633c-4cd7-aff9-02de5a8b305a"), new DateTime(1981, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chris", "Evans" },
                    { new Guid("b7d25307-e1a2-4f38-9614-723b40067087"), new DateTime(1967, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mark", "Ruffalo" },
                    { new Guid("c15547bd-8996-4767-b0db-d5c8f24eea36"), new DateTime(1972, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gwyneth", "Paltrow" },
                    { new Guid("ea261dd1-223c-4823-8418-25fe6fd51c42"), new DateTime(1963, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johnny", "Depp" },
                    { new Guid("65927bde-a9f3-42b9-b9ae-208448c31f76"), new DateTime(1967, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Benicio", "Del Toro" },
                    { new Guid("74d8f9f1-9ae2-464d-90ce-ad806d54f7c3"), new DateTime(1975, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tobey", "Maguire" }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("07b9e9b1-5b85-4abe-8e6c-3af9b6858224"), new DateTime(1964, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joss", "Whedon" },
                    { new Guid("a980f781-9c70-4b10-bc5b-b11acdc27fae"), new DateTime(1966, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jon", "Favreu" },
                    { new Guid("91b57acf-ea13-4773-9f33-ae9f4d84daf0"), new DateTime(1940, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terry", "Gilliam" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("f2f66613-9378-4e5e-bca8-c8786f0154e6"), "Horror" },
                    { new Guid("db6a2124-1e44-40a9-bcce-be91c6400fff"), "Action" },
                    { new Guid("8e2d23d7-9eae-4195-a3a5-dccac6d05514"), "Comedy" },
                    { new Guid("75082de0-918b-493a-a071-f590177f8ed5"), "Thriller" },
                    { new Guid("4edb5883-8e24-47ca-a4ce-19fccb3dcf80"), "Drama" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("5b2a83c9-7db4-4d17-8577-8907ef9ea15d"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("65927bde-a9f3-42b9-b9ae-208448c31f76"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("74d8f9f1-9ae2-464d-90ce-ad806d54f7c3"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("96850b21-633c-4cd7-aff9-02de5a8b305a"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("b7d25307-e1a2-4f38-9614-723b40067087"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("c15547bd-8996-4767-b0db-d5c8f24eea36"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("ea261dd1-223c-4823-8418-25fe6fd51c42"));

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: new Guid("07b9e9b1-5b85-4abe-8e6c-3af9b6858224"));

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: new Guid("91b57acf-ea13-4773-9f33-ae9f4d84daf0"));

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: new Guid("a980f781-9c70-4b10-bc5b-b11acdc27fae"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4edb5883-8e24-47ca-a4ce-19fccb3dcf80"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("75082de0-918b-493a-a071-f590177f8ed5"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8e2d23d7-9eae-4195-a3a5-dccac6d05514"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("db6a2124-1e44-40a9-bcce-be91c6400fff"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f2f66613-9378-4e5e-bca8-c8786f0154e6"));

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("df042bb3-70bd-4467-a53f-21e200a75ef8"), new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert", "Downey Jr" },
                    { new Guid("1d742364-c856-4e31-a0c0-4ae18b631770"), new DateTime(1981, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chris", "Evans" },
                    { new Guid("c1b48aac-263b-4764-ae0d-dd9d51297639"), new DateTime(1967, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mark", "Ruffalo" },
                    { new Guid("233bfa34-2741-4663-a561-9810f95c2ee8"), new DateTime(1972, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gwyneth", "Paltrow" },
                    { new Guid("e4de4f51-7e56-4d12-a73e-df884a895f5f"), new DateTime(1963, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johnny", "Depp" },
                    { new Guid("a18a46fe-6e6a-4382-9eef-09ac77d8c5cc"), new DateTime(1967, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Benicio", "Del Toro" },
                    { new Guid("256153e2-e144-4143-bb07-bc140ff83123"), new DateTime(1975, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tobey", "Maguire" }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("f519ae16-badf-4523-9995-8326a8df3585"), new DateTime(1964, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joss", "Whedon" },
                    { new Guid("b79681d3-e38b-40cc-a654-912e921bcf12"), new DateTime(1966, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jon", "Favreu" },
                    { new Guid("1486270e-3059-4e8d-ba0b-5607080f29d1"), new DateTime(1940, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terry", "Gilliam" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("348e8ec3-a092-4a64-a497-6de690349cf3"), "Horror" },
                    { new Guid("e1a7cf8b-2945-4578-8977-4337d85ebe48"), "Action" },
                    { new Guid("42f12480-a374-471b-9e56-5e83c425a692"), "Comedy" },
                    { new Guid("861e42b0-f6ce-4185-80c5-69f1b46283c0"), "Thriller" },
                    { new Guid("16460579-6c68-4da9-9d96-de60571fbc27"), "Drama" }
                });
        }
    }
}
