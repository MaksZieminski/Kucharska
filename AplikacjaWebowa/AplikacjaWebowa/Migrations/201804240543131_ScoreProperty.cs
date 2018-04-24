namespace AplikacjaWebowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScoreProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "Score", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "Score");
        }
    }
}
