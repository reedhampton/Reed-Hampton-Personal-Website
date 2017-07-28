namespace ReedHampton.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateToDocuments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProfessionalDocuments", "Icon", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProfessionalDocuments", "Icon");
        }
    }
}
