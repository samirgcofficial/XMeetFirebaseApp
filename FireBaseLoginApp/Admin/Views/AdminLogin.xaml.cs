using System;
using System.Collections.Generic;
using FireBaseLoginApp.Admin.ViewModels;
using FireBaseLoginApp.Admin.Views.AdminRegistration;
using Xamarin.Forms;

namespace FireBaseLoginApp.Admin.Views
{
    public partial class AdminLogin : ContentPage
    {
        public AdminLogin()
        {
            InitializeComponent();
            BindingContext = new AdminViewModel(Navigation);
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AdminRegistrationPage());
        }
    }
}
