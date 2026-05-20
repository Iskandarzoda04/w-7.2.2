using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
           
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),

                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),

                    BirthYear = table.Column<int>(type: "integer", nullable: false),

                    Country = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),

                    Biography = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

         
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),

                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),

                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),

                    IsFiction = table.Column<bool>(type: "boolean", nullable: false),

                    Popularity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

           
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),

                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),

                    Year = table.Column<int>(type: "integer", nullable: false),

                    ISBN = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),

                    Pages = table.Column<int>(type: "integer", nullable: false), 

                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),

                    AuthorId = table.Column<int>(type: "integer", nullable: false),

                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);

                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

         
            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Books");
            migrationBuilder.DropTable(name: "Authors");
            migrationBuilder.DropTable(name: "Genres");
        }
    }
}