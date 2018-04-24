namespace AplikacjaWebowa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewEntityRecipeType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "RecipeTypeId", "dbo.RecipeTypes");
            DropIndex("dbo.Recipes", new[] { "RecipeTypeId" });
            DropColumn("dbo.Recipes", "RecipeTypeId");
            DropTable("dbo.RecipeTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RecipeTypes",
                c => new
                    {
                        RecipeTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RecipeTypeId);
            
            AddColumn("dbo.Recipes", "RecipeTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Recipes", "RecipeTypeId");
            AddForeignKey("dbo.Recipes", "RecipeTypeId", "dbo.RecipeTypes", "RecipeTypeId", cascadeDelete: true);
        }
    }
}
