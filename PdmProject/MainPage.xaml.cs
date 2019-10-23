using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PdmProject
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);

        }

        private void btn_LoginClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
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
