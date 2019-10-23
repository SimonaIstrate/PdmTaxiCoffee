using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PdmProject
{
    public partial class AddCoffeePage : ContentPage
    { 
        private string Name;
        private string Description;
        private string Price;

        public event EventHandler CreateCoffeeSucceeded;

        private CoffeeDb coffeeDb;

        public AddCoffeePage()
        {
            InitializeComponent();

            coffeeName.TextChanged += coffeeName_TextChanged;
            coffeeDescription.TextChanged += coffeeDescription_TextChanged;
            coffeePrice.TextChanged += coffeePrice_TextChanged;
            btnAdd.Clicked += btnAdd_Clicked;

            coffeeDb = new CoffeeDb();
        }

        private void coffeeName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Name = ((Entry)sender).Text;
        }

        private void coffeeDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            Description = ((Entry)sender).Text;
        }

        private void coffeePrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            Price = ((Entry)sender).Text;
        }


        private void resetFields()
        {
            coffeeName.Text = "";
            coffeeDescription.Text = "";
            coffeePrice.Text = "";
        }

        private bool validateFields()
        {
            if (Name == null || Name == "")
            {
                DisplayAlert("Error", "Please insert name!", "Ok");
                return false;
            }
            if (Description == null || Description == "")
            {
                DisplayAlert("Error", "Please insert description!", "Ok");
                return false;
            }
            if (Price == null || Price == "" )
            {
                DisplayAlert("Error", "Please insert price!", "Ok");
                return false;
            }
            return true;
        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            if (validateFields())
            {

                Coffee coffee = new Coffee();
                coffee.Name = Name;
                coffee.Description = Description;
                coffee.Price = Int32.Parse(Price);

                if (coffeeDb.insert(coffee) > 0)
                {
                    DisplayAlert("Success", "Coffee was addedd successfully!", "Ok");
                    resetFields();
                }
                else
                {
                    DisplayAlert("Error", "An error was showed, please try again", "Close");
                }
            }

        }
    }
}
