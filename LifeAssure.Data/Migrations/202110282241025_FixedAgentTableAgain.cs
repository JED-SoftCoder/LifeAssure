namespace LifeAssure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedAgentTableAgain : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Agent", "NumberOfPolicies");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Agent", "NumberOfPolicies", c => c.Int(nullable: false));
        }
    }
}
