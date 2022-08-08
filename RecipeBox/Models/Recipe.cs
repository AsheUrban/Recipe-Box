using System.Collections.Generic;


namespace RecipeBox.Models
{
    public class Recipe
    {
        public Recipe()
        {
            this.JoinEntities = new HashSet<TagRecipe>();
        }
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public string Instruction { get; set; }
        public string Ingredient { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<TagRecipe> JoinEntities { get;}
    }
}