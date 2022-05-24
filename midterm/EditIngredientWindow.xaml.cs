using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace midterm
{
    /// <summary>
    /// Interaction logic for EditIngredientWindow.xaml
    /// </summary>
    public partial class EditIngredientWindow : Window
    {
        public EditIngredientWindow(Ingredient ingredient)
        {
            InitializeComponent();
            EditIngredientWindowViewModel viewmodel = new EditIngredientWindowViewModel();
            viewmodel.Setup(ingredient);
            this.DataContext = viewmodel;
        }

        private void BtnClick(object sender, RoutedEventArgs e)
        {          
            if(ClosingCondition())
            {
                this.DialogResult = true;
            }
        }
        private bool ClosingCondition()
        {
            bool result = false;
            List<char> numbers = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            foreach (char item in pricebox.Text)
            {
                if(numbers.Any(x => x == item))
                {
                    result = true;
                }
                if(result == false)
                {
                    return false;
                }
                result = false;
            }
            return true;
        }
    }
}
