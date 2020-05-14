using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using FireBaseLoginApp.Admin.Models;
using FireBaseLoginApp.Serivces;
using FireBaseLoginApp.Tables.Register;
using Xamarin.Forms;

namespace FireBaseLoginApp.Admin.ViewModels
{
    public class AdminDashboardViewModel : BindableObject
    {
        ObservableCollection<TasksModel> _clientTasks;
        public ObservableCollection<TasksModel> clientTasks
        {
            get { return _clientTasks; }
            set
            {
                _clientTasks = value;
                OnPropertyChanged();
            }
        }

        public string ClientID { get; set; }


        public ICommand DeleteCommand { get; }
        public ICommand UpdateDatabaseCommand { get; set; }
        public RegisterTable _SelectedContents { get; set; }

        public AdminDashboardViewModel(RegisterTable SelectedContents)
        {
            ClientID = SelectedContents.UserId.ToString();
            _SelectedContents = SelectedContents;
            GetUserTasks();
            DeleteCommand = new Command(DeleteLabelSelected);
            UpdateDatabaseCommand = new Command(async () => await UpdateUserDataBase());
        }

        private async Task UpdateUserDataBase()
        {
           

        }

       

        private async void DeleteLabelSelected(object obj)
        {
             var content = obj as TasksModel;
             clientTasks.Remove(content);

            //Delete it from Data base and Update it

            //Send Updated Information to the database

            var response = await ApiServices.ServiceClientInstance.DeleteDatabaseConetent(content);

            if(response == true)
            {
               await  App.Current.MainPage.DisplayAlert("Alert","File Deleted Successfully","Ok");
                 
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Server Issue", "Ok");
            }

        }

        private async void GetUserTasks()
        {
            var response = await ApiServices.ServiceClientInstance.GetClientTasks(ClientID);
            clientTasks = new ObservableCollection<TasksModel>(response);
        }


    }
}
