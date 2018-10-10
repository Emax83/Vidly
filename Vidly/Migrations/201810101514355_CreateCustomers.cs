namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Customers (Id,Name,IsSubscribedToNewsletter,MembershipTypeId) VALUES (1,'Emanuele',1,1)");
            Sql("insert into Customers (Id,Name,IsSubscribedToNewsletter,MembershipTypeId) VALUES (1,'Valeria',0,2)");
            Sql("insert into Customers (Id,Name,IsSubscribedToNewsletter,MembershipTypeId) VALUES (1,'Gianni',1,3)");
            Sql("insert into Customers (Id,Name,IsSubscribedToNewsletter,MembershipTypeId) VALUES (1,'Pinotto',0,4)");
        }
        
        public override void Down()
        {
        }
    }
}
