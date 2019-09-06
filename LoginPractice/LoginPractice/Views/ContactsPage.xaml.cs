﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginPractice.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginPractice.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage : ContentPage
    {
        public ContactsPage()
        {
            InitializeComponent();
            this.BindingContext = new ContactsViewModel();
        }
    }
}