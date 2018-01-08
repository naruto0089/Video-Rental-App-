namespace VidlyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMovieTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Movies", name: "GenreId_Id", newName: "GenreId");
            RenameIndex(table: "dbo.Movies", name: "IX_GenreId_Id", newName: "IX_GenreId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Movies", name: "IX_GenreId", newName: "IX_GenreId_Id");
            RenameColumn(table: "dbo.Movies", name: "GenreId", newName: "GenreId_Id");
        }
    }
}
