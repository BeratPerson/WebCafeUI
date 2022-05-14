namespace WebCafeUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ParentCategoryId = c.Int(nullable: false),
                        CategoryName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatorUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ProductProperties",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        PropertyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Price = c.Double(nullable: false),
                        ImagePath = c.String(),
                        IsdDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatorUserId = c.Int(nullable: false),
                        CategoryId_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.CategoryId_id)
                .Index(t => t.CategoryId_id);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SurName = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        PasswordAccept = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryId_id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId_id" });
            DropTable("dbo.Users");
            DropTable("dbo.Properties");
            DropTable("dbo.Products");
            DropTable("dbo.ProductProperties");
            DropTable("dbo.Categories");
        }
    }
}
