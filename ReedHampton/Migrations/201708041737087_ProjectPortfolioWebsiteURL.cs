namespace ReedHampton.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectPortfolioWebsiteURL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DevelopmentProjects", "ProjectUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DevelopmentProjects", "ProjectUrl");
        }
    }
}
