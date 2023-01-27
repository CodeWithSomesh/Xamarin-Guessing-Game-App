using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Guessing_Game_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        //Initialize Global Variables 
        int generatedNumber = 0;
        int inputAttempts = 3;

        //Use the C# "Random" Class to Generate Random Integers 
        Random random = new Random();

        public Page1()
        {
            InitializeComponent();
            numberGenerator();
        }

        void numberGenerator()
        {
            //Returns a positive random integer within the range of 0 to 10 
            generatedNumber = random.Next(0, 11);

        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            //Initialize Variables 
            string input = number.Text; //The input in the entry form is a string
            int userInputNumber = 0;

            //Convert the string variable to integer 
            int.TryParse(number.Text, out userInputNumber); //Now, the input in the entry form is converted from a string to an integer 

            //If the Entry Form is empty with no input then error message is displayed
            if (string.IsNullOrEmpty(input))
            {
                DisplayAlert("ALERT!", "Please Enter A Number To Proceed.", "Try Again");
            }
            //Appropriate message is dislpayed for every condition
            else if (inputAttempts <= 0)
            {
                DisplayAlert("ALERT!", "You Have Attempted More Than 3 Times. Click The Play Again Button To Replay The Game.", "OK");
            }
            else if (userInputNumber == generatedNumber)
            {
                DisplayAlert("HOORAY!!!", "Congratulations, You Have Guessed The Number Correctly. Click The Play Again Button To Replay The Game.", "OK");
                inputAttempts--;
                Navigation.PushAsync(new Page2());

            }
            else if (userInputNumber != generatedNumber && inputAttempts == 1)
            {
                DisplayAlert("YOU LOST!!!", "You Have Failed To Guess The Number Within 3 Attempts. Click The Play Again Button To Replay The Game.", "OK");
                inputAttempts--;
            }
            else if (userInputNumber > generatedNumber && inputAttempts == 3)
            {
                inputAttempts--;
                DisplayAlert("OOPS, WRONG!", "Guess Again But This Time Guess LOWER. You Have 2 More Attempts.", "Try Again");
            }
            else if (userInputNumber > generatedNumber && inputAttempts == 2)
            {
                inputAttempts--;
                DisplayAlert("OOPS, WRONG!", "Guess Again But This Time Guess LOWER. You Have 1 More Attempts.", "Try Again");
            }
            else if (userInputNumber < generatedNumber && inputAttempts == 3)
            {
                inputAttempts--;
                DisplayAlert("OOPS, WRONG!", "Guess Again But This Time Guess HIGHER. You Have 2 More Attempts.", "Try Again");

            }
            else if (userInputNumber < generatedNumber && inputAttempts == 2)
            {
                inputAttempts--;
                DisplayAlert("OOPS, WRONG!", "Guess Again But This Time Guess HIGHER. You Have 1 More Attempts.", "Try Again");
            }
            else
            {
                DisplayAlert("ALERT!", "Invalid Input. Please Enter An Integer Number.", "OK");
            }
        }


        private void Button_Clicked_1(object sender, EventArgs e)
        {
            numberGenerator();
            number.Text = "";
            inputAttempts = 3;
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}