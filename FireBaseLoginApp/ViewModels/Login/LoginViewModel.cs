using System;
using System.Threading.Tasks;
using System.Windows.Input;
using FireBaseLoginApp.Serivces;
using FireBaseLoginApp.Views.DashBoard;
using FireBaseLoginApp.Views.Register;
using Xamarin.Forms;

namespace FireBaseLoginApp.ViewModels.Login
{
    public class LoginViewModel : BindableObject
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

        public ICommand LoginUser { get; }
        public ICommand GoToRegistration { get; }
        public INavigation Navigation { get; }

        public LoginViewModel(INavigation navigation)
        {
            Navigation = navigation;
            LoginUser = new Command(async () => await PerformLogin());
            GoToRegistration = new Command(async () => await GotoRegistrationPage());
        }

        private async Task GotoRegistrationPage()
        {
            Navigation.PushAsync(new RegisterPage()) ;
        }

        private async Task PerformLogin()
        {
            var response = await ApiServices.ServiceClientInstance.LoginUser(UserName, Password);

            if (response!=null)
            {

                await Navigation.PushAsync(new DashboardPage(response.UserId.ToString()));

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Server Error", "Ok");
            }

        }
    }
}
