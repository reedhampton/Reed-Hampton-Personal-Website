namespace ReedHampton.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfessionalDocuments101 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProfessionalDocuments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        FileURL = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProfessionalDocuments");
        }
    }
}
