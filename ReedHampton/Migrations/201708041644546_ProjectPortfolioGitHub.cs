namespace ReedHampton.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectPortfolioGitHub : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DevelopmentProjects", "GitHubUrl", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DevelopmentProjects", "GitHubUrl");
        }
    }
}
