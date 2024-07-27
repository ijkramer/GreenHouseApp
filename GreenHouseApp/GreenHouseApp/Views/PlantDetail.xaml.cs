using GreenHouseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GreenHouseApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlantDetail : ContentPage
    {
        private Plants plant;
        public PlantDetail(Plants plant)
        {
            InitializeComponent();
            this.plant = plant;
            LoadPlantDetails();
        }
        private async void DeletePlant(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Delete Plant", "Are you sure you want to delete this plant?", "Yes", "No");
            if (result)
            {
                await App.Database.DeleteItemAsync(plant);
                await Navigation.PopAsync();
            }
        }
        private void LoadPlantDetails()
        {
            plantName.Text = plant.Name;
            plantWaterDays.Text = plant.WaterDays.ToString();
            plantDescription.Text = plant.Description;
        }
    }
}
