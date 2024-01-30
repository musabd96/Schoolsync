using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    Address = table.Column<string>(type: "longtext", nullable: false)
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
                    Address = table.Column<string>(type: "longtext", nullable: false)
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
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("0429a046-e220-4a14-860f-6cd2dc4ecf91"), "Linnégatan 202, Göteborg", new DateOnly(2006, 4, 28), "emma.ekstrom@schoolsync.com", "Emma", "Ekström", "+46 72 123 45 67" },
                    { new Guid("09e2e69f-8ac0-4341-a7ae-848637c19e9a"), "Lisebergsgatan 1111, Göteborg", new DateOnly(2006, 2, 27), "astrid.svensson@schoolsync.com", "Astrid", "Svensson", "+46 72 123 45 67" },
                    { new Guid("18ede236-2a88-45c1-ae4c-8e098b5428b6"), "Karl Johansgatan 1313, Göteborg", new DateOnly(2007, 8, 20), "amanda.vikstrom@schoolsync.com", "Amanda", "Vikström", "+46 73 567 89 01" },
                    { new Guid("1c84df29-265f-4ef4-9a62-3236e9e81edb"), "Ekelundsgatan 1717, Göteborg", new DateOnly(2005, 7, 8), "viktoria.pettersson@schoolsync.com", "Viktoria", "Pettersson", "+46 73 567 89 01" },
                    { new Guid("2f4f6148-d43f-4319-ac1f-39a3599d0c14"), "Haga Nygata 101, Göteborg", new DateOnly(2007, 2, 15), "alexander.dahlstrom@schoolsync.com", "Alexander", "Dahlström", "+46 76 789 01 23" },
                    { new Guid("5599b8eb-7db2-4146-a975-e1f2a211b76c"), "Kungsgatan 123, Göteborg", new DateOnly(2006, 5, 12), "elsa.andersson@schoolsync.com", "Elsa", "Andersson", "+46 70 123 45 67" },
                    { new Guid("67671e6a-c482-4139-a0a7-5599c2128c8c"), "Magasinsgatan 1414, Göteborg", new DateOnly(2006, 11, 1), "gustav.werner@schoolsync.com", "Gustav", "Werner", "+46 76 789 01 23" },
                    { new Guid("6f2591e8-ced3-4a9e-9e73-63077de1d428"), "Avenyn 456, Göteborg", new DateOnly(2005, 8, 21), "oscar.bergqvist@schoolsync.com", "Oscar", "Bergqvist", "+46 72 345 67 89" },
                    { new Guid("6fe55b1c-e348-4a44-8948-fba52c6e87a4"), "Vasagatan 789, Göteborg", new DateOnly(2007, 11, 3), "hanna.carlsson@schoolsync.com", "Hanna", "Carlsson", "+46 73 567 89 01" },
                    { new Guid("7394f9e1-cf4f-42ee-bd13-1784d633d048"), "Nordenskiöldsgatan 909, Göteborg", new DateOnly(2005, 12, 16), "noah.lindgren@schoolsync.com", "Noah", "Lindgren", "+46 76 789 01 23" },
                    { new Guid("78048440-4a12-4aa2-9e98-b304df5a017a"), "Trädgårdsgatan 1919, Göteborg", new DateOnly(2005, 12, 31), "isabelle.holm@schoolsync.com", "Isabelle", "Holm", "+46 72 123 45 67" },
                    { new Guid("7940e5d9-abca-4633-8897-ec8e5149bb7c"), "Fiskebäcksgatan 1212, Göteborg", new DateOnly(2005, 5, 9), "erik.toresson@schoolsync.com", "Erik", "Toresson", "+46 70 345 67 89" },
                    { new Guid("8b214e7b-c043-42f1-80a2-6f699ad84338"), "Storgatan 707, Göteborg", new DateOnly(2005, 6, 25), "william.johansson@schoolsync.com", "William", "Johansson", "+46 70 345 67 89" },
                    { new Guid("a21d0e20-a426-42cb-9008-bc02cd2406ad"), "Västra Hamngatan 606, Göteborg", new DateOnly(2006, 3, 14), "maja.isaksson@schoolsync.com", "Maja", "Isaksson", "+46 72 123 45 67" },
                    { new Guid("a544aff0-7b33-406e-b90d-115e027bb1a1"), "Första Långgatan 404, Göteborg", new DateOnly(2007, 10, 19), "ella.gustavsson@schoolsync.com", "Ella", "Gustavsson", "+46 73 567 89 01" },
                    { new Guid("bcda90ba-a22a-43d7-9a56-0eaf783a687b"), "Södra Hamngatan 1515, Göteborg", new DateOnly(2005, 1, 15), "sofia.aberg@schoolsync.com", "Sofia", "Åberg", "+46 72 123 45 67" },
                    { new Guid("c5eae628-b53c-4ceb-aaa1-90f85ef8a039"), "Kungsportsavenyn 303, Göteborg", new DateOnly(2005, 7, 8), "liam.forsberg@schoolsync.com", "Liam", "Forsberg", "+46 70 345 67 89" },
                    { new Guid("c7b22823-caf4-4dcc-842c-3a0957e39adb"), "Färjenäsgatan 1818, Göteborg", new DateOnly(2006, 10, 19), "axel.sjoberg@schoolsync.com", "Axel", "Sjöberg", "+46 76 789 01 23" },
                    { new Guid("cfd66e76-c727-43c8-a6d9-5f363378ba83"), "Andra Långgatan 505, Göteborg", new DateOnly(2005, 1, 31), "oliver.hedlund@schoolsync.com", "Oliver", "Hedlund", "+46 76 789 01 23" },
                    { new Guid("d43c6516-8e47-4385-881e-bf0cc1b4c115"), "Östra Hamngatan 808, Göteborg", new DateOnly(2007, 9, 5), "alice.karlsson@schoolsync.com", "Alice", "Karlsson", "+46 73 567 89 01" },
                    { new Guid("df57d14f-971c-411a-b886-40a7ff2cdb93"), "Götgatan 1616, Göteborg", new DateOnly(2007, 4, 28), "filip.oberg@schoolsync.com", "Filip", "Öberg", "+46 70 345 67 89" },
                    { new Guid("f2fe8402-f7e3-4355-8977-1fe19394e1de"), "Mölndalsvägen 2020, Göteborg", new DateOnly(2007, 2, 14), "marcus.lundqvist@schoolsync.com", "Marcus", "Lundqvist", "+46 70 345 67 89" }
                });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("0980bf71-d31a-49fc-bb2b-7b61b118b283"), "Lärarstråket 6, Göteborg", new DateOnly(1973, 7, 8), "erik.berg@schoolsync.com", "Erik", "Berg", "+46 70 345 67 89" },
                    { new Guid("0b848ce3-8797-4555-ae8e-af12a0ba6194"), "Undervisningsvägen 3, Göteborg", new DateOnly(1982, 11, 3), "camilla.eriksson@schoolsync.com", "Camilla", "Eriksson", "+46 73 567 89 01" },
                    { new Guid("1bdc9d77-75fd-4f73-ad3d-0a6e18f752b9"), "Utvecklingsgatan 7, Göteborg", new DateOnly(1987, 10, 19), "sara.johansson@schoolsync.com", "Sara", "Johansson", "+46 73 567 89 01" },
                    { new Guid("2b15389e-c176-4349-b74b-4503084619c0"), "Lärarvägen 4, Göteborg", new DateOnly(1978, 2, 15), "mats.andersson@schoolsync.com", "Mats", "Andersson", "+46 76 789 01 23" },
                    { new Guid("89317b64-fb8c-48fd-81fb-871d4970550b"), "Skolgatan 1, Göteborg", new DateOnly(1980, 6, 15), "karin.lind@schoolsync.com", "Karin", "Lind", "+46 70 123 45 67" },
                    { new Guid("c30d0564-0bb4-42ef-b3e6-3b6e4af1c5cc"), "Pedagogvägen 5, Göteborg", new DateOnly(1985, 4, 28), "anna.hedstrom@schoolsync.com", "Anna", "Hedström", "+46 72 123 45 67" },
                    { new Guid("e00792b2-ea43-463f-876f-881037b37a81"), "Lärargatan 2, Göteborg", new DateOnly(1975, 9, 21), "anders.svensson@schoolsync.com", "Anders", "Svensson", "+46 72 345 67 89" },
                    { new Guid("f344552e-3fa5-4a90-ace3-181a68872092"), "Lärarvägen 8, Göteborg", new DateOnly(1979, 1, 31), "johan.lund@schoolsync.com", "Johan", "Lund", "+46 76 789 01 23" }
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
