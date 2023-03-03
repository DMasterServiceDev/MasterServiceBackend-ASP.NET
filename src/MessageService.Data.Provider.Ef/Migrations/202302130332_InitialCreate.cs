using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MessageService.Data.Provider.Ef.Migrations;

[DbContext(typeof(MessageDbContext))]
[Migration("202302130332_InitialCreate")]
class InitialCreate : Migration
{
  protected override void Up(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.CreateTable(
        name: "messages",
        columns: table => new
        {
          id = table.Column<long>(type: "bigint", nullable: false)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
          content = table.Column<string>(type: "text", nullable: true),
          receiver_id = table.Column<long>(type: "bigint", nullable: false),
          created_by = table.Column<long>(type: "bigint", nullable: false),
          created_at_utc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
          modified_at_utc = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey("pk_messages", x => x.id);
        });
  }
}
