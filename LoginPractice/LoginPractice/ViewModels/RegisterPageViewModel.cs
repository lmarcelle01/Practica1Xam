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
    class RegisterPageViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Message { get; set; }
        public string PassConfirmation { get; set; }
        public User Student { get; set; }
        public ICommand RegisterCommand { get; set; }

        public RegisterPageViewModel()
        {
            Student = new User();

            RegisterCommand = new Command(async () => {

                if (string.IsNullOrWhiteSpace(Student.Name) || string.IsNullOrWhiteSpace(Student.Email) || string.IsNullOrWhiteSpace(Student.PassWord) || string.IsNullOrEmpty(PassConfirmation))
                {
                    Message = "No se permiten campos vacios!";
                }
                else if (Student.PassWord != PassConfirmation)
                {
                    Message = "Las contraseñas no coinciden!";
                }
                else
                {
                    await App.Current.MainPage.Navigation.PushAsync(new HomePage());
                }

            }
            );
        }



    }
}
