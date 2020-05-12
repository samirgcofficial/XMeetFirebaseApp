using System;
using System.Collections.Generic;
using FireBaseLoginApp.Admin.Models;
using FireBaseLoginApp.Serivces;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms;
using Entry = Microcharts.Entry;
namespace FireBaseLoginApp.Views.DashBoard
{
    public partial class DashboardPage : ContentPage
    {
        private string UserId;
        public DashboardPage(string UsrId)
        { 
            UserId = UsrId;
            InitializeComponent();

            FakeGraphEntries();
               

            GetMyTasks();
        }

        private void FakeGraphEntries()
        {
                 var entries = new[]
                 {
                      new Entry(200)
                        {
                         Label = "January",
                         ValueLabel = "200",
                         Color = SKColor.Parse("#3232ff")
                        },
                        new Entry(200)
                        {
                         Label = "February",
                         ValueLabel = "400",
                         Color = SKColor.Parse("#b2b2ff")
                        },

                         new Entry(200)
                        {
                         Label = "March",
                         ValueLabel = "-400",
                         Color = SKColor.Parse("#FF0000")
                        },

                        new Entry(200)
                        {
                         Label = "April",
                         ValueLabel = "700",
                         Color = SKColor.Parse("#329932")
                        },

                         new Entry(200)
                        {
                         Label = "May",
                         ValueLabel = "600",
                         Color = SKColor.Parse("#228B22")
                        },
                            new Entry(200)
                        {
                         Label = "June",
                         ValueLabel = "1600",
                         Color = SKColor.Parse("#008000")
                        },
                               new Entry(200)
                        {
                         Label = "July",
                         ValueLabel = "600",
                         Color = SKColor.Parse("#4ca64c")
                        },
                                  new Entry(200)
                        {
                         Label = "August",
                         ValueLabel = "-600",
                         Color = SKColor.Parse("#FF0000")
                        },
                 };

            FakeChart.Chart = new DonutChart { Entries = entries };
        }

        private async void GetMyTasks()
        {
            var response = await ApiServices.ServiceClientInstance.GetClientTasks(UserId);
            MyList.ItemsSource = response;

        }

       async void MyList_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if(((ListView)sender).SelectedItem==null)
            {
                return;
            }
            var content = e.SelectedItem as TasksModel;

            await Navigation.PushAsync(new DashboardPageDetails(content));

            ((ListView)sender).SelectedItem = null;

        }
    }
}
