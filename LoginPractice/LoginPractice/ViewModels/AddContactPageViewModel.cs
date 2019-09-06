using LoginPractice.Models;
using LoginPractice.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginPractice.ViewModels
{
    class AddContactPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        Contact _Contact;
        public Contact Contact {
            get
            {
                return _Contact;
            }
            set
            {
                _Contact = value;
            }
        }

        public ICommand AddNewContact { get; set; }
        public AddContactPageViewModel()
        {

            Contact = new Contact();
            AddNewContact = new Command(async () => {
                MessagingCenter.Send<AddContactPageViewModel, Contact>(this, "SaveEdit", Contact);
                MessagingCenter.Send<AddContactPageViewModel, Contact>(this, "SendContactID", Contact);
                await App.Current.MainPage.Navigation.PopAsync();
            }
            );

            MessagingCenter.Subscribe<ContactsViewModel, Contact>(this, "EditContactID", ((sender, param) =>
            {
                Contact = param;
                MessagingCenter.Unsubscribe<ContactsViewModel, Contact>(this, "EditContactID");
            }));

        }
    }
}
