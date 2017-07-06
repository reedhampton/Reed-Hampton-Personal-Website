namespace ReedHampton.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageSecond : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Images", "CreatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Images", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
