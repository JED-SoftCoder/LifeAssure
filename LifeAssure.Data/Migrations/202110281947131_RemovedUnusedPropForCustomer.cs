namespace LifeAssure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedUnusedPropForCustomer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customer", "YearsOfPolicy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "YearsOfPolicy", c => c.Int(nullable: false));
        }
    }
}
