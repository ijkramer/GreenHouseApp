using GreenHouseApp.Models;
using GreenHouseApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace GreenHouseApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadPlants();
        }

        private async void LoadPlants()
        {
            var plants = await App.Database.GetItemsAsync();
            TodoItemsStack.Children.Clear();
            foreach (var plant in plants)
            {
                var plantLayout = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    Padding = new Thickness(10),
                    Margin = new Thickness(0, 5),
                    BackgroundColor = Color.FromHex("#D0F0C0")
            };

                plantLayout.Children.Add(new Label { Text = $"Name: {plant.Name}", FontSize = 18, FontAttributes = FontAttributes.Bold });
                plantLayout.Children.Add(new Label { Text = $"Days: {plant.WaterDays}", FontSize = 18 });
                plantLayout.Children.Add(new Label { Text = $"Description: {plant.Description}", FontSize = 18 });

                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += async (s, e) =>
                {
                    await Navigation.PushAsync(new PlantDetail(plant));
                };
                plantLayout.GestureRecognizers.Add(tapGestureRecognizer);

                TodoItemsStack.Children.Add(plantLayout);
            }
        }
        private async void NavigateToAdd(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddPlant());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadPlants();
        }
    }
}