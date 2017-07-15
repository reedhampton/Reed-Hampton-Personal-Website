namespace ReedHampton.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DevelopmentProject100 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DevelopmentProjects",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ProjectImageUrl = c.String(),
                        ShortName = c.String(nullable: false),
                        ShortDescription = c.String(nullable: false),
                        LongName = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        Date = c.String(nullable: false),
                        LongDescription = c.String(nullable: false),
                        SkillsNeeded = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DevelopmentProjects");
        }
    }
}
