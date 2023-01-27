using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Guessing_Game_App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //Initialize Variables 
            string nameOfPlayer = playerName.Text;

            //If the Entry Form is empty with no input then error message is displayed
            if (string.IsNullOrEmpty(nameOfPlayer))
            {
                DisplayAlert("ALERT!", "Please Enter Player Name To Proceed.", "Try Again");
            }
            else
            {
                Navigation.PushAsync(new Page1());
            }
        }
    }
}
