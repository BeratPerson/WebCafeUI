﻿namespace WebCafeUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsAdmin", c => c.Boolean(nullable: false));
            DropColumn("dbo.Users", "Permission");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Permission", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "IsAdmin");
        }
    }
}
