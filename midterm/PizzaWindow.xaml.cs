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
    /// Interaction logic for PizzaWindow.xaml
    /// </summary>
    public partial class PizzaWindow : Window
    {
        public PizzaWindow(Pizza pizza)
        {
            InitializeComponent();
            PizzaWindowViewModel viewmodel = new PizzaWindowViewModel();
            viewmodel.Setup(pizza);
            this.DataContext = viewmodel;
        }
    }
}
