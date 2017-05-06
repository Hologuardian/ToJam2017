using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public class Recipe
{
    public Recipe(List<Resource> ingredients, List<Resource> products, int time)
    {
        if (ingredients == null)
            ingredients = new List<Resource>();
        if (products == null)
            products = new List<Resource>();

        this.ingredients = ingredients;
        this.products = products;
        this.time = time;
    }

    public List<Resource> ingredients;
    public List<Resource> products;
    public int time;
}
