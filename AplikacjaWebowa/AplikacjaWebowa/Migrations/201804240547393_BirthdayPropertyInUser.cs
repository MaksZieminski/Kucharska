namespace AplikacjaWebowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BirthdayPropertyInUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Birthday", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Birthday");
        }
    }
}
