using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Movies_RestApi.Migrations
{
    /// <inheritdoc />
    public partial class AddMovieActorSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Movies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "MovieActor",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 1, 3 },
                    { 3, 3 },
                    { 4, 4 },
                    { 6, 4 },
                    { 2, 5 },
                    { 7, 5 },
                    { 1, 6 },
                    { 4, 6 },
                    { 6, 7 },
                    { 2, 8 },
                    { 7, 8 },
                    { 1, 9 },
                    { 3, 9 },
                    { 6, 10 },
                    { 7, 10 },
                    { 4, 11 },
                    { 2, 12 },
                    { 3, 12 },
                    { 1, 13 },
                    { 4, 14 },
                    { 6, 15 },
                    { 7, 15 }
                });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rating",
                value: 8.5);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rating",
                value: 9.0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Rating",
                value: 10.0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                column: "Rating",
                value: 7.5);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                column: "Rating",
                value: 8.0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                column: "Rating",
                value: 6.5);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7,
                column: "Rating",
                value: 8.0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8,
                column: "Rating",
                value: 6.5);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9,
                column: "Rating",
                value: 9.0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10,
                column: "Rating",
                value: 10.0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 11,
                column: "Rating",
                value: 7.5);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 12,
                column: "Rating",
                value: 5.5);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 13,
                column: "Rating",
                value: 8.5);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 14,
                column: "Rating",
                value: 9.5);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 15,
                column: "Rating",
                value: 10.0);

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "Duration",
                value: 110);

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "Duration",
                value: 135);

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "Duration",
                value: 95);

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "Duration",
                value: 100);

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 5,
                column: "Duration",
                value: 80);

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 6,
                column: "Duration",
                value: 140);

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 7,
                column: "Duration",
                value: 160);

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 8,
                column: "Duration",
                value: 125);

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 9,
                column: "Duration",
                value: 100);

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 10,
                column: "Duration",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 11,
                column: "Duration",
                value: 90);

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 12,
                column: "Duration",
                value: 100);

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 13,
                column: "Duration",
                value: 110);

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 14,
                column: "Duration",
                value: 125);

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 15,
                column: "Duration",
                value: 105);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rating",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rating",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 3,
                column: "Rating",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 4,
                column: "Rating",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 5,
                column: "Rating",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 6,
                column: "Rating",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 7,
                column: "Rating",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 8,
                column: "Rating",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 9,
                column: "Rating",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 10,
                column: "Rating",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 11,
                column: "Rating",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 12,
                column: "Rating",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 13,
                column: "Rating",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 14,
                column: "Rating",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 15,
                column: "Rating",
                value: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 7, 5 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 6, 7 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 6, 10 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 7, 10 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 4, 11 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 2, 12 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 3, 12 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 1, 13 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 4, 14 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 6, 15 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 7, 15 });

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Movies");

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 5,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 6,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 7,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 8,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 9,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 10,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 11,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 12,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 13,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 14,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductionDetails",
                keyColumn: "Id",
                keyValue: 15,
                column: "Duration",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rating",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rating",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 3,
                column: "Rating",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 4,
                column: "Rating",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 5,
                column: "Rating",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 6,
                column: "Rating",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 7,
                column: "Rating",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 8,
                column: "Rating",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 9,
                column: "Rating",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 10,
                column: "Rating",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 11,
                column: "Rating",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 12,
                column: "Rating",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 13,
                column: "Rating",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 14,
                column: "Rating",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 15,
                column: "Rating",
                value: 0);
        }
    }
}
