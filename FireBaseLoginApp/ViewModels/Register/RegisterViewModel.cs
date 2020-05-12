using System;
using System.Threading.Tasks;
using System.Windows.Input;
using FireBaseLoginApp.Serivces;
using FireBaseLoginApp.Tables.Register;
using Xamarin.Forms;

namespace FireBaseLoginApp.ViewModels.Register
{
    public class RegisterViewModel  : BindableObject
    {
        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set
            {
                _UserName = value;
                OnPropertyChanged();
            }
        }
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                OnPropertyChanged();
            }
        }

        public ICommand RegisterUser { get;  }


        public RegisterViewModel()
        {
            RegisterUser = new Command(async () => await SetRegisterUser());
        }

        private async Task SetRegisterUser()
        {
            var response = await ApiServices.ServiceClientInstance.RegisterUser(UserName, Password);
            if (response == true)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "User Created Sucessfully", "Ok");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alert", "User Created Sucessfully", "Ok");
            }
        }
    }
}

