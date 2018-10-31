namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thumb : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "Thumbnail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Thumbnail", c => c.String());
        }
    }
}
