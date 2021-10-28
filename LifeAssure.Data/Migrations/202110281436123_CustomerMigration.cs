namespace LifeAssure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        AdminId = c.Guid(nullable: false),
                        AgentId = c.Int(),
                        Name = c.String(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        Address = c.String(nullable: false),
                        YearsOfPolicy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Agent", t => t.AgentId)
                .Index(t => t.AgentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "AgentId", "dbo.Agent");
            DropIndex("dbo.Customer", new[] { "AgentId" });
            DropTable("dbo.Customer");
        }
    }
}
