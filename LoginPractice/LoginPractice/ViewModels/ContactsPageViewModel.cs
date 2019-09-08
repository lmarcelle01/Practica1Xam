using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using LoginPractice.Models;
using LoginPractice.Views;
using Xamarin.Forms;

namespace LoginPractice.ViewModels
{
    class ContactsPageViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        Contact _contact;
        
        public Contact Contact {
            get
            {
                return _contact;
            }
            set
            {
                _contact = value;
            }

        }

        public ICommand GoToAddCommand { get; set; }
        public ICommand DeleteElementCommand { get; set; }

        public ICommand ShowMoreCommand { get; set; }

        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();
        public ContactsPageViewModel()
        {

            GoToAddCommand = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new AddContactPage());

                MessagingCenter.Subscribe<AddContactPageViewModel, Contact>(this, "SendContactID", ((sender, param) =>
                {
                    Contacts.Add(param);
                    MessagingCenter.Unsubscribe<AddContactPageViewModel, Contact>(this, "SendContactID");
                }));
            });

            DeleteElementCommand = new Command<Contact>( (param) =>
            {
                Contacts.Remove(param);

            });

            ShowMoreCommand = new Command<Contact>(async (param) =>
            {
                var Call = String.Format("Call: +{0}", param.PhoneNumber);
                var Action = await App.Current.MainPage.DisplayActionSheet(null, "Cancel", null, Call, "Edit");
                switch (Action)
                {
                    case "Edit":
                        EditContact(param);
                        break;
                    default:
                        CallContact(param);
                        break;                                     
                }
            });
        }

        async public void EditContact(Contact contact)
        {
            await App.Current.MainPage.Navigation.PushAsync(new AddContactPage());
            MessagingCenter.Send<ContactsPageViewModel, Contact>(this, "EditContactID", contact);
            MessagingCenter.Subscribe<AddContactPageViewModel, Contact>(this, "SaveEdit", ((sender, param) =>
            {
                foreach(var Person in Contacts)
                {
                    if(Person == contact)
                    {
                        Person.Name = param.Name;
                        Person.PhoneNumber = param.PhoneNumber;
                    }
                }
                MessagingCenter.Unsubscribe<AddContactPageViewModel, Contact>(this, "SaveEdit");
            }));


        }

        public void CallContact(Contact contact)
        {
            Device.OpenUri(new Uri(String.Format("tel: +{0}", contact.PhoneNumber)));
        }

    }
}
