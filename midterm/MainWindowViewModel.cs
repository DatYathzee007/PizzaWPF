using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midterm
{
    public class MainWindowViewModel : ObservableRecipient
    {
        //first list
        public ObservableCollection<Ingredient> Ingredients { get; set; }
        private Ingredient selectedingredient;
        public Ingredient SelectedIngredient
        {
            get => selectedingredient;
            set
            {
                SetProperty(ref selectedingredient, value);
                AddtoPizza.NotifyCanExecuteChanged();
                EditIngredient.NotifyCanExecuteChanged();
            }
        }                
        //second list
        public ObservableCollection<Ingredient> Toppings { get; set; }
        private Ingredient selectedtopping;
        public Ingredient SelectedTopping
        {
            get => selectedtopping;
            set
            {
                SetProperty(ref selectedtopping, value);
                RemoveFromPizza.NotifyCanExecuteChanged();
            }
        }

        //Commands
        public RelayCommand AddtoPizza { get; set; }
        public RelayCommand RemoveFromPizza { get; set; }
        public RelayCommand ShowPizza { get; set; }
        public RelayCommand EditIngredient { get; set; }

        public MainWindowViewModel()
        {
            //first list
            Ingredients = new ObservableCollection<Ingredient>();
            ReadIngredients("ingredients.txt");

            //second list
            Toppings = new ObservableCollection<Ingredient>();

            //commands
            AddtoPizza = new RelayCommand(() =>
            {
                Toppings.Add(SelectedIngredient);
            }, () => SelectedIngredient != null);

            RemoveFromPizza = new RelayCommand(() =>
            {
                Toppings.Remove(SelectedTopping);
            }, () => SelectedTopping != null);

            ShowPizza = new RelayCommand(() =>
            {
                Pizza pizza = new Pizza() { Id = 1, ListOfIngredients = Toppings.ToList(), TotalPrice = Toppings.Sum(x => x.Price) };
                PizzaWindow pizzawindow = new PizzaWindow(pizza);
                pizzawindow.ShowDialog();
            });

            EditIngredient = new RelayCommand(() =>
            {
                EditIngredientWindow editwindow = new EditIngredientWindow(SelectedIngredient);
                editwindow.ShowDialog();
            }, () => SelectedIngredient != null);
        }
        private void ReadIngredients(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            while(!reader.EndOfStream)
            {
                string row = reader.ReadLine();
                string[] items = row.Split(',');
                Ingredients.Add(new Ingredient() { Id = int.Parse(items[0]), Name = items[1], Price = int.Parse(items[2]), Type = items[3] });
            }
        }
    }
}
