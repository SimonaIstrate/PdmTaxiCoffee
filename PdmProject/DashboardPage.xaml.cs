using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PdmProject
{
    public partial class DashboardPage : ContentPage
    {
        public List<CoffeShops> coffeShopList = new List<CoffeShops>();

        public DashboardPage()
        {
            InitializeComponent();
            getCoffeeShops();

        }

        public async void getCoffeeShops()
        {
            CoffeeManager Manager = new CoffeeManager();
            coffeShopList = await Manager.getCoffeShops();

            if (coffeShopList.Count > 0)
            {
                listViewCoffeeShops.ItemsSource = coffeShopList;
            }
            
        }
    }
}
