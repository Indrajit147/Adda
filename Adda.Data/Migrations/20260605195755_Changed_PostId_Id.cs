using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adda.Migrations
{
    /// <inheritdoc />
    public partial class Changed_PostId_Id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(sql: @"
                IF COL_LENGTH('dbo.Posts', 'PostId') IS NOT NULL
                    AND COL_LENGTH('dbo.Posts', 'Id') IS NULL
                BEGIN
                    EXEC sp_rename 'dbo.Posts.PostId', 'Id', 'COLUMN';
                END
                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(sql: @"
                IF COL_LENGTH('dbo.Posts', 'Id') IS NOT NULL
                    AND COL_LENGTH('dbo.Posts', 'PostId') IS NULL
                BEGIN
                    EXEC sp_rename 'dbo.Posts.Id', 'PostId', 'COLUMN';
                END
                ");
        }
    }
}
