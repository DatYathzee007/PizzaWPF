using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midterm
{
    public class Pizza
    {
        public int Id { get; set; }
        public List<Ingredient> ListOfIngredients { get; set; }
        public int TotalPrice { get; set; }
        public List<string> ShowIngredientsName()
        {
            List<string> names = new List<string>();
            foreach (Ingredient item in ListOfIngredients)
            {
                names.Add(item.Name);
            }
            return names;
        }
    }
}
