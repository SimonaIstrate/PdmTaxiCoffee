using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PdmProject
{
    public partial class CoffeesPage : ContentPage
    {
        private List<Coffee> coffeesList = new List<Coffee>();
        List<Coffee> currentCoffeesList;
        private CoffeeDb coffeeDb;

        public CoffeesPage()
        {
            InitializeComponent();
            coffeeDb = new CoffeeDb();
            currentCoffeesList = coffeeDb.getcoffeesList();
            getCoffees();
        }

        public async void getCoffees()
        { 
            if (currentCoffeesList.Count > 0)
            {
                listViewCoffees.ItemsSource = currentCoffeesList;
            }
        }

        private void ToolbarItem_ClickedRegister(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

        private void ToolbarItem_ClickedAddCoffee(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddCoffeePage());
        }

        private void ToolbarItem_ClickedCoffees(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CoffeesPage());
        }

        private void ToolbarItem_ClickedDashboard(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DashboardPage());
        }
    }
}
