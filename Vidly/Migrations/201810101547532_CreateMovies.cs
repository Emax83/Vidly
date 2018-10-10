namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMovies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);


            Sql("INSERT INTO Movies (Name,Price) VALUES ('Terminator 1',15.5)");
            Sql("INSERT INTO Movies (Name,Price) VALUES ('Terminator 2',20.5)");
            Sql("INSERT INTO Movies (Name,Price) VALUES ('Terminator 3',14.99)");


        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
