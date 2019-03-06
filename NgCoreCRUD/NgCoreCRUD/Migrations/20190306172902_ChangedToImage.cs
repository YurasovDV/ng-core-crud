using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NgCoreCRUD.Migrations
{
    public partial class ChangedToImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                schema: "dbo",
                table: "Pictures",
                type: "image",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                schema: "dbo",
                table: "Pictures",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "image",
                oldNullable: true);
        }
    }
}
