namespace VidlyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomerandMemebershiptype : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SignUpFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "IsSuscribedToNewsLetter", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "MembershipTypeId_Id", c => c.Int());
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypeId_Id");
            AddForeignKey("dbo.Customers", "MembershipTypeId_Id", "dbo.MembershipTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId_Id", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId_Id" });
            AlterColumn("dbo.Customers", "Name", c => c.String());
            DropColumn("dbo.Customers", "MembershipTypeId_Id");
            DropColumn("dbo.Customers", "IsSuscribedToNewsLetter");
            DropTable("dbo.MembershipTypes");
        }
    }
}
