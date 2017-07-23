namespace ReedHampton.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FlipBoard100 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AboutMes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FlipBoardTitle = c.String(),
                        FlipBoardSubTitle = c.String(),
                        FlipboardThumnbailUrl = c.String(),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AboutMes");
        }
    }
}
