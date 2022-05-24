using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midterm
{
    public class PizzaWindowViewModel
    {
        public Pizza MyPizza { get; set; }
        public List<string> Toppings { get; set; }
        public void Setup(Pizza pizza)
        {
            MyPizza = pizza;
            Toppings = pizza.ShowIngredientsName();
        }
        public PizzaWindowViewModel()
        {
            
        }
    }
}
