using System;
using System.Collections.Generic;
using FireBaseLoginApp.Admin.Models;
using FireBaseLoginApp.Admin.ViewModels;
using FireBaseLoginApp.Serivces;
using FireBaseLoginApp.Tables.Register;
using Xamarin.Forms;

namespace FireBaseLoginApp.Admin.Views
{
    public partial class AdminDashboardDetails : ContentPage
    {
      
        public AdminDashboardDetails(RegisterTable registerTable)
        {
            InitializeComponent();
            BindingContext = new AdminDashboardViewModel(registerTable);
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            Label lblClicked = (Label)sender;
            var item = (TapGestureRecognizer)lblClicked.GestureRecognizers[0];
            var tappedItem = item.CommandParameter as TasksModel;



        }
    }
}
