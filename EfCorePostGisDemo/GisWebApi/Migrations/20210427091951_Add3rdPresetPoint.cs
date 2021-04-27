using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace GisWebApi.Migrations
{
    public partial class Add3rdPresetPoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "points",
                columns: new[] { "id", "location" },
                values: new object[] { 3, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (3 3)") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "points",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
