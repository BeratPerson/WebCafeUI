namespace WebCafeUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inital42 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "IsSend", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "IsSend");
        }
    }
}
