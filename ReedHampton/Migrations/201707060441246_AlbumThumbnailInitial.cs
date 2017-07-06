namespace ReedHampton.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlbumThumbnailInitial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "ThumbnailURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Albums", "ThumbnailURL");
        }
    }
}
