namespace WebCafeUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inita : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "IsDeleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Products", "IsdDeleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "IsdDeleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Products", "IsDeleted");
        }
    }
}
