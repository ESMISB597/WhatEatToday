namespace WhatEatToday.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Shop : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        shop_id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        location = c.String(),
                        details = c.String(),
                        type = c.String(),
                        pic = c.String(),
                    })
                .PrimaryKey(t => t.shop_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Shops");
        }
    }
}
