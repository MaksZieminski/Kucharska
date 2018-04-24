using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AplikacjaWebowa.Models;

namespace AplikacjaWebowa.ViewModels
{
    public class RandomRecipeViewModel
    {
        public Recipe recipe = new Recipe();
        public List<User> users = new List<User>();
    }
}