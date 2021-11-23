namespace LifeAssure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedCustomerPhone : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "PhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "PhoneNumber", c => c.Int(nullable: false));
        }
    }
}
