namespace LifeAssure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFavorite : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agent", "IsFavorited", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customer", "IsFavorited", c => c.Boolean(nullable: false));
            AddColumn("dbo.Policy", "IsFavorited", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Policy", "IsFavorited");
            DropColumn("dbo.Customer", "IsFavorited");
            DropColumn("dbo.Agent", "IsFavorited");
        }
    }
}
