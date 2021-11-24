namespace LifeAssure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedPolicyTableInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Policy", "PolicyAmount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Policy", "PolicyAmount", c => c.Double(nullable: false));
        }
    }
}
