using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midterm
{
    public class EditIngredientWindowViewModel
    {
        public Ingredient MyIngredient { get; set; }
        public void Setup(Ingredient ingredient)
        {
            MyIngredient = ingredient;
        }
        public EditIngredientWindowViewModel()
        {

        }
    }
}
