using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Resources
{
    [Serializable]
    public class Recipe
    {
        public enum RecipeType
        {
            None,
            Reaction,
            Factory,
            Reprocess,
            Farming
        }

        public Recipe()
        {
            ingredients = new List<Resource>();
            products = new List<Resource>();
            time = 1;
            powerCost = 0;
            type = RecipeType.None;
            Name = "";
        }

        public Recipe(List<Resource> ingredients, List<Resource> products, int time, float powerCost, RecipeType type)
        {
            if (ingredients == null)
                ingredients = new List<Resource>();
            if (products == null)
                products = new List<Resource>();

            this.ingredients = ingredients;
            this.products = products;
            this.time = time;
            this.powerCost = powerCost;
            this.type = type;
            Name = "";
        }

        public string Name;
        public List<Resource> ingredients;
        public List<Resource> products;
        public int time;
        public float powerCost;
        public RecipeType type;
    }
}