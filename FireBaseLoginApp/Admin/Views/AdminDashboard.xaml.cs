using System;
using System.Collections.Generic;
using FireBaseLoginApp.Admin.Models;
using FireBaseLoginApp.Serivces;
using FireBaseLoginApp.Tables.Register;
using Xamarin.Forms;

namespace FireBaseLoginApp.Admin.Views
{
    public partial class AdminDashboard : ContentPage
    {
        public AdminDashboard()
        {
            InitializeComponent();
            GetListofClients();
        }
        private async void GetListofClients()
        {
            var response = await ApiServices.ServiceClientInstance.GetRegisteredUsers();

            MyList.ItemsSource = response;

        }
        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var CellContents = ((Button)sender).BindingContext as RegisterTable;

            //Step1 : Add task title
            var addtasktitle = await DisplayPromptAsync("Question", "What is the task name for  " + CellContents.UserName + " User ");

            //Step 2 : Add total no of tasks
            var addtotaltasks = await DisplayPromptAsync("Question", "How many task assign to  " + CellContents.UserName,keyboard: Keyboard.Numeric);

            int totaltasks = Convert.ToInt32(addtotaltasks);


            //Step 3 : Create a new task for the user
            TasksModel tasksModel = new TasksModel()
            {
                ClientID = CellContents.UserId,
                TaskId = Guid.NewGuid(),
                TaskTitle = addtasktitle,
                clientTasks = new List<ClientTask>()
            };


            //Step 4 : Add tasks to the total no of task 
            int i = 1;
            do
            {
                string result = await DisplayPromptAsync("Question", "Add Task " + i + " to " + CellContents.UserName);

                ClientTask clientTask = new ClientTask()
                {
                    TaskName = result
                };
              
                tasksModel.clientTasks.Add(clientTask);

                i++;

            } while (i <= totaltasks);

            //Step 6 : Push the task to the database

            await ApiServices.ServiceClientInstance.AssignTaskToClient(tasksModel);

            await DisplayAlert("Alert", "Task sucessfully assigned to " + CellContents.UserName, " OK ");

            //Go back to the 1st Screen

           
        }

       async void MyList_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var content = e.SelectedItem as RegisterTable;
            await Navigation.PushAsync(new AdminDashboardDetails(content));
            MyList.SelectedItem = null;

        }
    }
}
