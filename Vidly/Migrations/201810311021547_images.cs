namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class images : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "Cover");
            DropColumn("dbo.Movies", "Backdrop");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Backdrop", c => c.String());
            AddColumn("dbo.Movies", "Cover", c => c.String());
        }
    }
}
