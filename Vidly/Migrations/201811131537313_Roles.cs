namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Roles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 20),
                        IsSuperAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Name);


            Sql("INSERT INTO Roles (Name,IsSuperAdmin) VALUES ('SuperAdmin',1),('Admin',0),('User',0)");
        }
        
        public override void Down()
        {
            DropTable("dbo.Roles");
        }
    }
}
