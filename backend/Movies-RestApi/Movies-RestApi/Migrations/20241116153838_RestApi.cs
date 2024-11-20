using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Movies_RestApi.Migrations
{
    /// <inheritdoc />
    public partial class RestApi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Studio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    DirectorId = table.Column<int>(type: "int", nullable: false),
                    ProductionDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_ProductionDetails_ProductionDetailsId",
                        column: x => x.ProductionDetailsId,
                        principalTable: "ProductionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieActor",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActor", x => new { x.MovieId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_MovieActor_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActor_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Leonardo", "DiCaprio" },
                    { 2, "Brad", "Pitt" },
                    { 3, "Scarlett", "Johansson" },
                    { 4, "Tom", "Hanks" },
                    { 5, "Natalie", "Portman" },
                    { 6, "Johnny", "Depp" },
                    { 7, "Morgan", "Freeman" }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Steven", "Spielberg" },
                    { 2, "Christopher", "Nolan" },
                    { 3, "Quentin", "Tarantino" },
                    { 4, "Martin", "Scorsese" },
                    { 5, "James", "Cameron" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Drama" },
                    { 3, "Comedy" },
                    { 4, "Horror" },
                    { 5, "Science Fiction" },
                    { 6, "Fantasy" },
                    { 7, "Adventure" }
                });

            migrationBuilder.InsertData(
                table: "ProductionDetails",
                columns: new[] { "Id", "Budget", "Duration", "Studio" },
                values: new object[,]
                {
                    { 1, 160000000m, 0, "Warner Bros" },
                    { 2, 8000000m, 0, "Miramax" },
                    { 3, 63000000m, 0, "Universal Pictures" },
                    { 4, 135000000m, 0, "20th Century Fox" },
                    { 5, 200000000m, 0, "Paramount Pictures" },
                    { 6, 185000000m, 0, "Warner Bros" },
                    { 7, 237000000m, 0, "Lightstorm Entertainment" },
                    { 8, 165000000m, 0, "Paramount Pictures" },
                    { 9, 6000000m, 0, "Paramount Pictures" },
                    { 10, 63000000m, 0, "Warner Bros" },
                    { 11, 103000000m, 0, "DreamWorks" },
                    { 12, 100000000m, 0, "Paramount Pictures" },
                    { 13, 140000000m, 0, "Walt Disney Pictures" },
                    { 14, 220000000m, 0, "Marvel Studios" },
                    { 15, 63000000m, 0, "20th Century Fox" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DirectorId", "GenreId", "ProductionDetailsId", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, 2, 5, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception" },
                    { 2, 3, 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction" },
                    { 3, 1, 1, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jurassic Park" },
                    { 4, 4, 2, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Revenant" },
                    { 5, 5, 2, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Titanic" },
                    { 6, 2, 1, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight" },
                    { 7, 5, 6, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar" },
                    { 8, 2, 5, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Interstellar" },
                    { 9, 4, 2, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather" },
                    { 10, 1, 5, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" },
                    { 11, 3, 7, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gladiator" },
                    { 12, 4, 2, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Wolf of Wall Street" },
                    { 13, 1, 7, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pirates of the Caribbean" },
                    { 14, 2, 1, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Avengers" },
                    { 15, 3, 2, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fight Club" }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "AuthorName", "Comment", "MovieId", "Rating", "ReviewDate" },
                values: new object[,]
                {
                    { 1, "John", "Amazing movie!", 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Alice", "A true classic!", 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Robert", "Very exciting!", 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Emily", "Great acting!", 4, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Mark", "Loved the story.", 5, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Sophia", "Fantastic visuals!", 6, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "David", "A must-watch!", 7, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Chris", "Very emotional!", 8, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Sarah", "An all-time favorite!", 9, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Anna", "Mind-blowing!", 10, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "Tom", "Epic battles!", 11, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "Paul", "Very entertaining!", 12, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "Laura", "A fun adventure!", 13, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "Diana", "Superheroes at their best!", 14, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "Steve", "A masterpiece!", 15, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieActor_ActorId",
                table: "MovieActor",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ProductionDetailsId",
                table: "Movies",
                column: "ProductionDetailsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Review_MovieId",
                table: "Review",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActor");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "ProductionDetails");
        }
    }
}
