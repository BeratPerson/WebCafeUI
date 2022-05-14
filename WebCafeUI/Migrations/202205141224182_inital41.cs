namespace WebCafeUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inital41 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        productId = c.Int(nullable: false),
                        NameSurName = c.String(),
                        phone = c.String(),
                        Mail = c.String(),
                        optional = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
        }
    }
}
