namespace LifeAssure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedAgentTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Agent", "NumberOfCustomers");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Agent", "NumberOfCustomers", c => c.Int(nullable: false));
        }
    }
}
