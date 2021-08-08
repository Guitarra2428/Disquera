using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Disquera.AccesoDatos.Migrations
{
    public partial class NUEVO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    GeneroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.GeneroID);
                });

            migrationBuilder.CreateTable(
                name: "Artistas",
                columns: table => new
                {
                    ArtistaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    UrlImagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GeneroID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artistas", x => x.ArtistaID);
                    table.ForeignKey(
                        name: "FK_Artistas_Generos_GeneroID",
                        column: x => x.GeneroID,
                        principalTable: "Generos",
                        principalColumn: "GeneroID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    AlbumID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlImagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaLanzamiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArtistaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.AlbumID);
                    table.ForeignKey(
                        name: "FK_Albums_Artistas_ArtistaID",
                        column: x => x.ArtistaID,
                        principalTable: "Artistas",
                        principalColumn: "ArtistaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cancions",
                columns: table => new
                {
                    CancionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tema = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TiempoReproducion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlbumID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cancions", x => x.CancionID);
                    table.ForeignKey(
                        name: "FK_Cancions_Albums_AlbumID",
                        column: x => x.AlbumID,
                        principalTable: "Albums",
                        principalColumn: "AlbumID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistaID",
                table: "Albums",
                column: "ArtistaID");

            migrationBuilder.CreateIndex(
                name: "IX_Artistas_GeneroID",
                table: "Artistas",
                column: "GeneroID");

            migrationBuilder.CreateIndex(
                name: "IX_Cancions_AlbumID",
                table: "Cancions",
                column: "AlbumID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cancions");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Artistas");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
