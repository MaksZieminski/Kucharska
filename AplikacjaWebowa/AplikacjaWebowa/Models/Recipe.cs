using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AplikacjaWebowa.Models
{
    public class Recipe
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Score { get; set; }
        public RecipeType RecipeType { get; set; }
        public int RecipeTypeId { get; set; }

        //public Recipe()
        //{
        //    Random rd = new Random();
        //    Score = rd.NextDouble()*5;

        //}


    }
}