namespace ReedHampton.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactInformation100 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactInformations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ContactName = c.String(),
                        PrimaryEmail = c.String(),
                        SecondaryEmail = c.String(),
                        GitHubLink = c.String(),
                        LinkedInLink = c.String(),
                        FacebookLink = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactInformations");
        }
    }
}
