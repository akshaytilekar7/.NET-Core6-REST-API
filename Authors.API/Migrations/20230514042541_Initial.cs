using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Authors.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<long>(type: "INTEGER", nullable: false),
                    MainCategory = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1500, nullable: true),
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName", "MainCategory" },
                values: new object[,]
                {
                    { 101, 1279360106496000330L, "Berry", "Griffin Beak Eldritch", "Ships" },
                    { 102, 1277955145728000330L, "Nancy", "Swashbuckler Rye", "Rum" },
                    { 103, 1264753115136000330L, "Eli", "Ivory Bones Sweet", "Singing" },
                    { 104, 1264248815616000330L, "Arnold", "The Unseen Stafford", "Singing" },
                    { 105, 1264066560000000330L, "Seabury", "Toxic Reyson", "Maps" },
                    { 106, 1279813091328000330L, "Rutherford", "Fearless Cloven", "General debauchery" },
                    { 107, 1280793378816000330L, "Atherton", "Crow Ridley", "Rum" },
                    { 108, 1280793378816000330L, "mike", "tyson", "Rum" },
                    { 109, 1280793378816000330L, "arthava", "shinde", "Rum" },
                    { 110, 1280793378816000330L, "shyubham", "jyoti", "Rum" },
                    { 111, 1280793378816000330L, "baba", "k", "Rum" },
                    { 112, 1280793378816000330L, "rohan", "jamanat", "Rum" },
                    { 113, 1280793378816000330L, "guddu", "pandit", "Rum" },
                    { 114, 1280793378816000330L, "kamalesh", "timwari", "Rum" },
                    { 115, 1280793378816000330L, "jahangir", "aman", "Rum" },
                    { 116, 1280793378816000330L, "tirtha", "kamat", "Rum" },
                    { 117, 1280793378816000330L, "jan", "jani", "Rum" },
                    { 118, 1280793378816000330L, "akshay", "bhau", "Rum" },
                    { 119, 1280793378816000330L, "udasas", "rahil", "Rum" },
                    { 120, 1280793378816000330L, "sahil", "nasy", "Rum" },
                    { 121, 1280793378816000330L, "pyarag", "aadsd", "Rum" },
                    { 8001, 1280793378816000330L, "pyarag", "aadsd", "Rum" },
                    { 8002, 1280793378816000330L, "sahil", "nasy", "Rum" },
                    { 8003, 1280793378816000330L, "udasas", "rahil", "Rum" },
                    { 8004, 1280793378816000330L, "akshay", "bhau", "Rum" },
                    { 8005, 1280793378816000330L, "jan", "jani", "Rum" },
                    { 8006, 1280793378816000330L, "jahangir", "aman", "Rum" },
                    { 8007, 1280793378816000330L, "kamalesh", "timwari", "Rum" },
                    { 8009, 1280793378816000330L, "guddu", "pandit", "Rum" },
                    { 8010, 1280793378816000330L, "rohan", "jamanat", "Rum" },
                    { 8011, 1280793378816000330L, "baba", "k", "Rum" },
                    { 8012, 1280793378816000330L, "shyubham", "jyoti", "Rum" },
                    { 8013, 1280793378816000330L, "pyarag", "aadsd", "Rum" },
                    { 8014, 1280793378816000330L, "sahil", "nasy", "Rum" },
                    { 8015, 1280793378816000330L, "udasas", "rahil", "Rum" },
                    { 8016, 1280793378816000330L, "jan", "jani", "Rum" },
                    { 8017, 1280793378816000330L, "tirtha", "kamat", "Rum" },
                    { 8018, 1280793378816000330L, "jahangir", "aman", "Rum" },
                    { 8019, 1280793378816000330L, "kamalesh", "timwari", "Rum" },
                    { 8020, 1280793378816000330L, "guddu", "pandit", "Rum" },
                    { 8021, 1280793378816000330L, "rohan", "jamanat", "Rum" },
                    { 8022, 1280793378816000330L, "baba", "k", "Rum" },
                    { 8023, 1280793378816000330L, "shyubham", "jyoti", "Rum" },
                    { 8024, 1280793378816000330L, "pyarag", "aadsd", "Rum" },
                    { 8025, 1280793378816000330L, "sahil", "nasy", "Rum" },
                    { 8026, 1280793378816000330L, "udasas", "rahil", "Rum" },
                    { 8027, 1280793378816000330L, "akshay", "bhau", "Rum" },
                    { 8028, 1280793378816000330L, "jan", "jani", "Rum" },
                    { 8029, 1280793378816000330L, "tirtha", "kamat", "Rum" },
                    { 8030, 1280793378816000330L, "jahangir", "aman", "Rum" },
                    { 8031, 1280793378816000330L, "kamalesh", "timwari", "Rum" },
                    { 8032, 1280793378816000330L, "guddu", "pandit", "Rum" },
                    { 8033, 1280793378816000330L, "rohan", "jamanat", "Rum" },
                    { 8034, 1280793378816000330L, "baba", "k", "Rum" },
                    { 8035, 1280793378816000330L, "shyubham", "jyoti", "Rum" },
                    { 8117, 1280793378816000330L, "tirtha", "kamat", "Rum" },
                    { 9001, 1280793378816000330L, "akshay", "bhau", "Rum" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "AuthorId", "Description", "Title" },
                values: new object[,]
                {
                    { 501, 101, "Commandeering a ship in rough waters isn't easy.  Commandeering it without getting caught is even harder.  In this course you'll learn how to sail away and avoid those pesky musketeers.", "Commandeering a Ship Without Getting Caught" },
                    { 502, 102, "In this course, the author provides tips to avoid, or, if needed, overthrow pirate mutiny.", "Overthrowing Mutiny" },
                    { 503, 103, "Every good pirate loves rum, but it also has a tendency to get you into trouble.  In this course you'll learn how to avoid that.  This new exclusive edition includes an additional chapter on how to run fast without falling while drunk.", "Avoiding Brawls While Drinking as Much Rum as You Desire" },
                    { 504, 104, "In this course you'll learn how to sing all-time favourite pirate songs without sounding like you actually know the words or how to hold a note.", "Singalong Pirate Hits" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AuthorId",
                table: "Courses",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
