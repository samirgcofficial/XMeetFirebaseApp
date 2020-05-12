using System;
using System.Collections.Generic;
using FireBaseLoginApp.Admin.Models;
using Xamarin.Forms;

namespace FireBaseLoginApp.Views.DashBoard
{
    public partial class DashboardPageDetails : ContentPage
    {
        public DashboardPageDetails(TasksModel tasksModel)
        {
            InitializeComponent();

            TaskId.Text = tasksModel.TaskId.ToString();
            TaskTitle.Text = tasksModel.TaskTitle.ToString();
            ClientID.Text = tasksModel.ClientID.ToString();
            MyList.ItemsSource = tasksModel.clientTasks;

        }
    }
}
