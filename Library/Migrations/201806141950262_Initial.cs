namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Masters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FirstClientTime = c.Time(nullable: false, precision: 7),
                        LastClientTime = c.Time(nullable: false, precision: 7),
                        Interval = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        Master_Id = c.Int(),
                        Service_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Masters", t => t.Master_Id)
                .ForeignKey("dbo.Services", t => t.Service_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Master_Id)
                .Index(t => t.Service_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Login = c.String(),
                        HashedPassword = c.String(),
                        TelNumber = c.String(),
                        Discount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceMasters",
                c => new
                    {
                        Service_Id = c.Int(nullable: false),
                        Master_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Service_Id, t.Master_Id })
                .ForeignKey("dbo.Services", t => t.Service_Id, cascadeDelete: true)
                .ForeignKey("dbo.Masters", t => t.Master_Id, cascadeDelete: true)
                .Index(t => t.Service_Id)
                .Index(t => t.Master_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Orders", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.ServiceMasters", "Master_Id", "dbo.Masters");
            DropForeignKey("dbo.ServiceMasters", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.Orders", "Master_Id", "dbo.Masters");
            DropIndex("dbo.ServiceMasters", new[] { "Master_Id" });
            DropIndex("dbo.ServiceMasters", new[] { "Service_Id" });
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.Orders", new[] { "Service_Id" });
            DropIndex("dbo.Orders", new[] { "Master_Id" });
            DropTable("dbo.ServiceMasters");
            DropTable("dbo.Users");
            DropTable("dbo.Services");
            DropTable("dbo.Orders");
            DropTable("dbo.Masters");
        }
    }
}
