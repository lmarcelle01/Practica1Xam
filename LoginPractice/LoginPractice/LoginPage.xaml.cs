using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginPractice
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }


        public async void ValidateLogIn(object ob, EventArgs args)
        {
            
            
            if (string.IsNullOrEmpty(Password.Text) || string.IsNullOrWhiteSpace(UserName.Text))
            {
               await DisplayAlert("Error", "NO se permiten campos vacios", "Ok");
            }
            else
            {
                string Message = $"Hola {UserName.Text}";
                await DisplayAlert("Bienvenido!", Message, "ok");
            }
        }


    }
}