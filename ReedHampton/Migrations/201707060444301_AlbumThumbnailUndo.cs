namespace ReedHampton.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlbumThumbnailUndo : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Albums", "ThumbnailURL");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Albums", "ThumbnailURL", c => c.String());
        }
    }
}
