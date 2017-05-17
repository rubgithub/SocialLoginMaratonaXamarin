using SocialLoginMaratona.Service;
using SocialLoginMaratona.ViewModels;
using Xamarin.Forms;

namespace SocialLoginMaratona
{
    public partial class MainPage : ContentPage
    {
        //readonly AuthenticationService azureService = new AuthenticationService();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
            //LoginButton.Clicked += async (sender, args) =>
            //{
            //    var user = await azureService.LoginAsync();
            //    //InfoLabel.Text = (user != null) ? $"Bem vindo: {user.UserId}" :
            //    //"Falha no login, tente novamente";
            //};
        }
    }
}
