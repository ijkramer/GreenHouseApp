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
           
        }
      
       
        private async void savePlant(object sender, EventArgs e)
        {
            var newPlant = new Plants { Name = plantName.Text, WaterDays = Int32.Parse(plantWaterDays.Text), Description = plantDescription.Text };
            await App.Database.SaveItemAsync(newPlant);
            plantName.Text = string.Empty;
            plantDescription.Text = string.Empty;
            plantWaterDays.Text = string.Empty;

        }

  

    }
}