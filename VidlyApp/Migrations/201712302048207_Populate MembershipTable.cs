namespace VidlyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTable : DbMigration
    {
        public override void Up()
        {
			Sql("Insert into Membershiptypes (MembershipTypeName,SignUpFee,DurationInMonths,DiscountRate) Values('Pay as You Go',0,0,0)");
			Sql("Insert into Membershiptypes (MembershipTypeName,SignUpFee,DurationInMonths,DiscountRate) Values('Monthly', 30,1,5)");
			Sql("Insert into Membershiptypes (MembershipTypeName,SignUpFee,DurationInMonths,DiscountRate) Values('Quaterly', 50,4,10)");
			Sql("Insert into Membershiptypes (MembershipTypeName,SignUpFee,DurationInMonths,DiscountRate) Values('Annualy', 90,12,15)");
		}
        
        public override void Down()
        {
        }
    }
}
