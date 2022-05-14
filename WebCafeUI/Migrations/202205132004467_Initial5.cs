namespace WebCafeUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CategoryId_id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId_id" });
            AddColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "CategoryId_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "CategoryId_id", c => c.Int());
            DropColumn("dbo.Products", "CategoryId");
            CreateIndex("dbo.Products", "CategoryId_id");
            AddForeignKey("dbo.Products", "CategoryId_id", "dbo.Categories", "id");
        }
    }
}
