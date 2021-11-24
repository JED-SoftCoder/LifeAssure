namespace LifeAssure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgentMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agent", "AdminId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Agent", "AdminId");
        }
    }
}
