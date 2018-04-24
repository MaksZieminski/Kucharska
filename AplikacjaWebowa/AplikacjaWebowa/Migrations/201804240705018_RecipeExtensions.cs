namespace AplikacjaWebowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecipeExtensions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecipeTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Recipes", "RecipeTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Recipes", "RecipeTypeId");
            AddForeignKey("dbo.Recipes", "RecipeTypeId", "dbo.RecipeTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "RecipeTypeId", "dbo.RecipeTypes");
            DropIndex("dbo.Recipes", new[] { "RecipeTypeId" });
            DropColumn("dbo.Recipes", "RecipeTypeId");
            DropTable("dbo.RecipeTypes");
        }
    }
}
