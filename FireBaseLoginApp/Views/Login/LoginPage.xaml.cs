
using FireBaseLoginApp.Admin.Views;
using FireBaseLoginApp.ViewModels.Login;
using Xamarin.Forms;

namespace FireBaseLoginApp.Views.Login
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(Navigation);
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AdminLogin());
        }
    }
}
