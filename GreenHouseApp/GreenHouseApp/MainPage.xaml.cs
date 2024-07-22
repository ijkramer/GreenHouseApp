using GreenHouseApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace GreenHouseApp
{
    public partial class MainPage : ContentPage
    {
        public Command AddItemCommand { get;  }
        public MainPage()
        {
            InitializeComponent();
            AddItemCommand = new Command(OnAddItem);
        }

         private async void OnAddItem(object o)
        {
            //Navigation.PushModalAsync(new AddPlant());
            //await Navigation.PushAsync(new AddPlant());
        }

        async void NavigateToAdd(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AddPlant());
        }
    }
}
