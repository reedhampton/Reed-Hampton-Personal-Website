namespace ReedHampton.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlbumThumbnailTwo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "AlbumThumbnailUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Albums", "AlbumThumbnailUrl");
        }
    }
}
