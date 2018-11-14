namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class USerRoles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Name = c.String(),
                        IsSuperAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            DropTable("dbo.Roles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 20),
                        IsSuperAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropTable("dbo.UserRoles");
        }
    }
}
