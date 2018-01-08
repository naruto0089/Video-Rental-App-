namespace VidlyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dropdatafromcustomertable : DbMigration
    {
        public override void Up()
        {
			Sql("Truncate Table Customers");
        }
        
        public override void Down()
        {
        }
    }
}
