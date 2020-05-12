using System;
using System.Collections.Generic;
using FireBaseLoginApp.ViewModels.Register;
using Xamarin.Forms;

namespace FireBaseLoginApp.Views.Register
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = new RegisterViewModel();
        }
    }
}
