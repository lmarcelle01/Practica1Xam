using System;
using System.Collections.Generic;
using System.Text;
using LoginPractice.Models;
using System.Windows.Input;
using Xamarin.Forms;
using LoginPractice.Views;
using System.ComponentModel;

namespace LoginPractice.ViewModels
{
    class LoginPageViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public User Student { get; set; }

        public string Message { get; set; }
        public ICommand LoginCommand { get; set; }

        public ICommand RegisterCommand { get; set; }

        public ICommand GoToRegisterCommand { get; set; }

        public LoginPageViewModel()
        {
            Student = new User();

            LoginCommand = new Command(async () => {

                if (string.IsNullOrEmpty(Student.PassWord) || string.IsNullOrWhiteSpace(Student.Email))
                {
                    Message = "Todos los campos son obligatorios";
                }
                else
                {
                    await App.Current.MainPage.Navigation.PushAsync(new ContactsPage());
                }
            }
            );
             
            GoToRegisterCommand = new Command(async () => {

                await App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
            }
            );
        }




    }
}
