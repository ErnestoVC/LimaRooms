using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: true),
                    apellidos = table.Column<string>(nullable: true),
                    nacionalidad = table.Column<string>(nullable: true),
                    telefono = table.Column<string>(nullable: true),
                    correo = table.Column<string>(nullable: true),
                    tipoDocumento = table.Column<string>(nullable: true),
                    nroDocumento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inmobiliarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: true),
                    tipoInmobiliario = table.Column<string>(nullable: true),
                    direccion = table.Column<string>(nullable: true),
                    precio = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inmobiliarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recibos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NroRecibo = table.Column<string>(nullable: true),
                    Total = table.Column<double>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recibos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recibos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClienteId = table.Column<int>(nullable: false),
                    InmobiliarioId = table.Column<int>(nullable: false),
                    Inicio = table.Column<DateTime>(nullable: false),
                    Fin = table.Column<DateTime>(nullable: false),
                    tipoContrato = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contratos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contratos_Inmobiliarios_InmobiliarioId",
                        column: x => x.InmobiliarioId,
                        principalTable: "Inmobiliarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetealleRecibos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cantidad = table.Column<int>(nullable: false),
                    adicional = table.Column<double>(nullable: false),
                    ReciboId = table.Column<int>(nullable: false),
                    InmobiliarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetealleRecibos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetealleRecibos_Inmobiliarios_InmobiliarioId",
                        column: x => x.InmobiliarioId,
                        principalTable: "Inmobiliarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetealleRecibos_Recibos_ReciboId",
                        column: x => x.ReciboId,
                        principalTable: "Recibos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_ClienteId",
                table: "Contratos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_InmobiliarioId",
                table: "Contratos",
                column: "InmobiliarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DetealleRecibos_InmobiliarioId",
                table: "DetealleRecibos",
                column: "InmobiliarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DetealleRecibos_ReciboId",
                table: "DetealleRecibos",
                column: "ReciboId");

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_ClienteId",
                table: "Recibos",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "DetealleRecibos");

            migrationBuilder.DropTable(
                name: "Inmobiliarios");

            migrationBuilder.DropTable(
                name: "Recibos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
