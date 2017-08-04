namespace ReedHampton.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectPortfolioGitHub200 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DevelopmentProjects", "GitHubUrl", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DevelopmentProjects", "GitHubUrl", c => c.String(nullable: false));
        }
    }
}
