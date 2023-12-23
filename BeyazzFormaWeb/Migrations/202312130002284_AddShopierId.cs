namespace BeyazzFormaWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShopierId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ShopierId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ShopierId");
        }
    }
}
