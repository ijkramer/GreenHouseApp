using CommunityToolkit.Mvvm.ComponentModel;
using GreenHouseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace GreenHouseApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPlant 
    {
        public ICommand PlantSave { get; private set; }
        public ICommand PlantCancel { get; private set; }

        public AddPlant()
    {
            InitializeComponent();
            PlantCancel = new Command(cancelPlant);
            PlantSave = new Command(savePlant);
        }
      
        private async void cancelPlant()
        {
            Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 1]);
        }
        private async void savePlant()
        {
            var newPlant = new Plants { Name = plantName.Text, WaterDays = Int32.Parse(plantWaterDays.Text), Description = plantDescription.Text };
            await App.Database.SaveItemAsync(newPlant);
            plantName.Text = string.Empty;

        }

  

    }
}