namespace LiveCurrencyWindowsService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ValCurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ValTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        ValCursId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ValCurs", t => t.ValCursId, cascadeDelete: true)
                .Index(t => t.ValCursId);
            
            CreateTable(
                "dbo.Valutes",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        Nominal = c.String(),
                        Name = c.String(),
                        Value = c.String(),
                        ValTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.ValTypes", t => t.ValTypeId, cascadeDelete: true)
                .Index(t => t.ValTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ValTypes", "ValCursId", "dbo.ValCurs");
            DropForeignKey("dbo.Valutes", "ValTypeId", "dbo.ValTypes");
            DropIndex("dbo.Valutes", new[] { "ValTypeId" });
            DropIndex("dbo.ValTypes", new[] { "ValCursId" });
            DropTable("dbo.Valutes");
            DropTable("dbo.ValTypes");
            DropTable("dbo.ValCurs");
        }
    }
}
