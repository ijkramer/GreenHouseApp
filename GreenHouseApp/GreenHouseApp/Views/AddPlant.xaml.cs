using GreenHouseApp.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GreenHouseApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPlant : ContentPage
    {
        public AddPlant()
        {
            InitializeComponent();
        }

        private async void SavePlant(object sender, EventArgs e)
        {
            var newPlant = new Plants
            {
                Name = plantName.Text,
                WaterDays = int.Parse(plantWaterDays.Text),
                Description = plantDescription.Text
            };
            await App.Database.SaveItemAsync(newPlant);
            await Navigation.PopModalAsync();
        }
    }
}