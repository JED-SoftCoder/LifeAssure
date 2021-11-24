namespace LifeAssure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedPolicyTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Policy", "AgentId", "dbo.Agent");
            DropForeignKey("dbo.Policy", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Policy", new[] { "AgentId" });
            DropIndex("dbo.Policy", new[] { "CustomerId" });
            AlterColumn("dbo.Policy", "AgentId", c => c.Int());
            AlterColumn("dbo.Policy", "CustomerId", c => c.Int());
            CreateIndex("dbo.Policy", "AgentId");
            CreateIndex("dbo.Policy", "CustomerId");
            AddForeignKey("dbo.Policy", "AgentId", "dbo.Agent", "AgentId");
            AddForeignKey("dbo.Policy", "CustomerId", "dbo.Customer", "CustomerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Policy", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Policy", "AgentId", "dbo.Agent");
            DropIndex("dbo.Policy", new[] { "CustomerId" });
            DropIndex("dbo.Policy", new[] { "AgentId" });
            AlterColumn("dbo.Policy", "CustomerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Policy", "AgentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Policy", "CustomerId");
            CreateIndex("dbo.Policy", "AgentId");
            AddForeignKey("dbo.Policy", "CustomerId", "dbo.Customer", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.Policy", "AgentId", "dbo.Agent", "AgentId", cascadeDelete: true);
        }
    }
}
