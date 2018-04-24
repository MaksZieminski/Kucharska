using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AplikacjaWebowa.Models
{
   

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("AplicationDbContext")
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RecipeType> RecipesTypes { get; set; }
    }
    
}