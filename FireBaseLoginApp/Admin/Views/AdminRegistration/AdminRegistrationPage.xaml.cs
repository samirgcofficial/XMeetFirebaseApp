using System;
using System.Collections.Generic;
using FireBaseLoginApp.Serivces;
using Xamarin.Forms;

namespace FireBaseLoginApp.Admin.Views.AdminRegistration
{
    public partial class AdminRegistrationPage : ContentPage
    {
        public AdminRegistrationPage()
        {
            InitializeComponent();
        }

         async  void Button_Clicked(System.Object sender, System.EventArgs e)
           {
            var response = await ApiServices.ServiceClientInstance.RegisterAdminUser(USName.Text, LNName.Text);
            if (response == true)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Admin User Created Sucessfully", "Ok");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alert", " Admin User Created Sucessfully", "Ok");
            }

           }
    }
}
