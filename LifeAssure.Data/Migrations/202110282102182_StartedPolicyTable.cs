namespace LifeAssure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StartedPolicyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Policy",
                c => new
                    {
                        PolicyId = c.Int(nullable: false, identity: true),
                        AdminId = c.Guid(nullable: false),
                        AgentId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        TypeOfPolicy = c.Int(nullable: false),
                        PolicyAmount = c.Double(nullable: false),
                        Details = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PolicyId)
                .ForeignKey("dbo.Agent", t => t.AgentId, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.AgentId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Policy", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Policy", "AgentId", "dbo.Agent");
            DropIndex("dbo.Policy", new[] { "CustomerId" });
            DropIndex("dbo.Policy", new[] { "AgentId" });
            DropTable("dbo.Policy");
        }
    }
}
