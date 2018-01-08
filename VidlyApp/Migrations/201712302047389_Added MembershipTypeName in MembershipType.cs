namespace VidlyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMembershipTypeNameinMembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "MembershipTypeName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "MembershipTypeName");
        }
    }
}
