using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Adress = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Adress = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Adress", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("0eea8fe8-3eca-415b-97b1-3d90aaa75abf"), "Avenyn 456, Göteborg", new DateOnly(2005, 8, 21), "oscar.bergqvist@schoolsync.com", "Oscar", "Bergqvist", "+46 72 345 67 89" },
                    { new Guid("1db948fa-70cb-4604-aa29-01a79555b4b8"), "Färjenäsgatan 1818, Göteborg", new DateOnly(2006, 10, 19), "axel.sjoberg@schoolsync.com", "Axel", "Sjöberg", "+46 76 789 01 23" },
                    { new Guid("4045699c-da31-432e-b0f2-7a4630409048"), "Magasinsgatan 1414, Göteborg", new DateOnly(2006, 11, 1), "gustav.werner@schoolsync.com", "Gustav", "Werner", "+46 76 789 01 23" },
                    { new Guid("4104c0d9-9ebf-48a0-853a-9898061f18c0"), "Södra Hamngatan 1515, Göteborg", new DateOnly(2005, 1, 15), "sofia.aberg@schoolsync.com", "Sofia", "Åberg", "+46 72 123 45 67" },
                    { new Guid("42d72f1c-b1be-4773-99de-160a43918d93"), "Haga Nygata 101, Göteborg", new DateOnly(2007, 2, 15), "alexander.dahlstrom@schoolsync.com", "Alexander", "Dahlström", "+46 76 789 01 23" },
                    { new Guid("563b2b3d-908d-46a6-b8ab-ab8a01697560"), "Västra Hamngatan 606, Göteborg", new DateOnly(2006, 3, 14), "maja.isaksson@schoolsync.com", "Maja", "Isaksson", "+46 72 123 45 67" },
                    { new Guid("5abb712b-18ff-4e22-a4f7-efc1015ed4ea"), "Storgatan 707, Göteborg", new DateOnly(2005, 6, 25), "william.johansson@schoolsync.com", "William", "Johansson", "+46 70 345 67 89" },
                    { new Guid("618c8c20-86f2-4479-a550-b540dcfaa1e9"), "Karl Johansgatan 1313, Göteborg", new DateOnly(2007, 8, 20), "amanda.vikstrom@schoolsync.com", "Amanda", "Vikström", "+46 73 567 89 01" },
                    { new Guid("78dcb205-e5b3-4c79-bf8d-467a1d6ee312"), "Ekelundsgatan 1717, Göteborg", new DateOnly(2005, 7, 8), "viktoria.pettersson@schoolsync.com", "Viktoria", "Pettersson", "+46 73 567 89 01" },
                    { new Guid("82f4b83a-07b0-479b-ba3b-2e2eb6573022"), "Östra Hamngatan 808, Göteborg", new DateOnly(2007, 9, 5), "alice.karlsson@schoolsync.com", "Alice", "Karlsson", "+46 73 567 89 01" },
                    { new Guid("839277e5-ffcc-4ccc-9ae9-187b4394a438"), "Götgatan 1616, Göteborg", new DateOnly(2007, 4, 28), "filip.oberg@schoolsync.com", "Filip", "Öberg", "+46 70 345 67 89" },
                    { new Guid("a02b5c55-e1d0-482e-8034-34810d0e4782"), "Linnégatan 202, Göteborg", new DateOnly(2006, 4, 28), "emma.ekstrom@schoolsync.com", "Emma", "Ekström", "+46 72 123 45 67" },
                    { new Guid("ba109366-4630-47e0-afc7-b7b8ecdae08c"), "Vasagatan 789, Göteborg", new DateOnly(2007, 11, 3), "hanna.carlsson@schoolsync.com", "Hanna", "Carlsson", "+46 73 567 89 01" },
                    { new Guid("c140e092-15a4-4a51-b06d-9c9064751118"), "Mölndalsvägen 2020, Göteborg", new DateOnly(2007, 2, 14), "marcus.lundqvist@schoolsync.com", "Marcus", "Lundqvist", "+46 70 345 67 89" },
                    { new Guid("c9366e0f-91b2-4267-b89d-81c626fd2b6b"), "Fiskebäcksgatan 1212, Göteborg", new DateOnly(2005, 5, 9), "erik.toresson@schoolsync.com", "Erik", "Toresson", "+46 70 345 67 89" },
                    { new Guid("cc8e85aa-5cd1-41bb-acd6-6540b7920297"), "Kungsgatan 123, Göteborg", new DateOnly(2006, 5, 12), "elsa.andersson@schoolsync.com", "Elsa", "Andersson", "+46 70 123 45 67" },
                    { new Guid("d108e62b-0f15-4228-9b1b-b082a13e97b9"), "Första Långgatan 404, Göteborg", new DateOnly(2007, 10, 19), "ella.gustavsson@schoolsync.com", "Ella", "Gustavsson", "+46 73 567 89 01" },
                    { new Guid("d274a649-30af-4ec0-9322-ae9d57b68340"), "Lisebergsgatan 1111, Göteborg", new DateOnly(2006, 2, 27), "astrid.svensson@schoolsync.com", "Astrid", "Svensson", "+46 72 123 45 67" },
                    { new Guid("d6a77abb-9860-4eab-a2c9-7bb67db3148e"), "Nordenskiöldsgatan 909, Göteborg", new DateOnly(2005, 12, 16), "noah.lindgren@schoolsync.com", "Noah", "Lindgren", "+46 76 789 01 23" },
                    { new Guid("e3b185ae-02c2-479c-a557-9982761c7be8"), "Andra Långgatan 505, Göteborg", new DateOnly(2005, 1, 31), "oliver.hedlund@schoolsync.com", "Oliver", "Hedlund", "+46 76 789 01 23" },
                    { new Guid("e46b745a-d292-4de0-b171-a99fec202f70"), "Kungsportsavenyn 303, Göteborg", new DateOnly(2005, 7, 8), "liam.forsberg@schoolsync.com", "Liam", "Forsberg", "+46 70 345 67 89" },
                    { new Guid("f40ac66c-caad-43b5-a0ef-155d3dd6077f"), "Trädgårdsgatan 1919, Göteborg", new DateOnly(2005, 12, 31), "isabelle.holm@schoolsync.com", "Isabelle", "Holm", "+46 72 123 45 67" }
                });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "Adress", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("002f7674-874f-490d-85aa-6db99c9223ac"), "Lärarvägen 8, Göteborg", new DateOnly(1979, 1, 31), "johan.lund@schoolsync.com", "Johan", "Lund", "+46 76 789 01 23" },
                    { new Guid("38648c1a-4b93-435c-9d93-d08c347e69e9"), "Skolgatan 1, Göteborg", new DateOnly(1980, 6, 15), "karin.lind@schoolsync.com", "Karin", "Lind", "+46 70 123 45 67" },
                    { new Guid("3ab7cd74-7e03-408a-8187-ebfcbb24f8f3"), "Lärargatan 2, Göteborg", new DateOnly(1975, 9, 21), "anders.svensson@schoolsync.com", "Anders", "Svensson", "+46 72 345 67 89" },
                    { new Guid("67c77b82-ed33-406d-8fad-cd05195548c8"), "Pedagogvägen 5, Göteborg", new DateOnly(1985, 4, 28), "anna.hedstrom@schoolsync.com", "Anna", "Hedström", "+46 72 123 45 67" },
                    { new Guid("862abebe-db3d-4323-8c35-af794e8ee05f"), "Lärarstråket 6, Göteborg", new DateOnly(1973, 7, 8), "erik.berg@schoolsync.com", "Erik", "Berg", "+46 70 345 67 89" },
                    { new Guid("875cf839-4c6a-44db-b7f6-d5eb014e09b0"), "Utvecklingsgatan 7, Göteborg", new DateOnly(1987, 10, 19), "sara.johansson@schoolsync.com", "Sara", "Johansson", "+46 73 567 89 01" },
                    { new Guid("af259c3d-4527-4382-a888-03eb38d114af"), "Undervisningsvägen 3, Göteborg", new DateOnly(1982, 11, 3), "camilla.eriksson@schoolsync.com", "Camilla", "Eriksson", "+46 73 567 89 01" },
                    { new Guid("d990d5ea-5c9b-4efa-bc37-311eb9de4af8"), "Lärarvägen 4, Göteborg", new DateOnly(1978, 2, 15), "mats.andersson@schoolsync.com", "Mats", "Andersson", "+46 76 789 01 23" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
