using Microsoft.WindowsAzure.MobileServices;
using SocialLoginMaratona.Authentication;
using SocialLoginMaratona.Helpers;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(SocialLoginMaratona.Service.AzureService))]
namespace SocialLoginMaratona.Service
{
    public class AzureService
    {
        //TODO: refatorar de acordo cm PDFs
        static readonly string AppUrl = "http://rub-maratona-xamarin-intermediario.azurewebsites.net";
        public MobileServiceClient Client { get; set; } = null;

        public void Initialize()
        {
            Client = new MobileServiceClient(AppUrl);

            if(!string.IsNullOrWhiteSpace(Settings.AuthToken) && !string.IsNullOrWhiteSpace(Settings.UserId))
            {
                Client.CurrentUser = new MobileServiceUser(Settings.UserId)
                {
                    MobileServiceAuthenticationToken = Settings.AuthToken
                };
            }
        }

        public async Task<bool> LoginAsync()
        {
            Initialize();

            var auth = DependencyService.Get<IAuthentication>();
            var user = await auth.Authenticate(Client, MobileServiceAuthenticationProvider.Facebook);

            if (user == null)
            {
                Settings.AuthToken = string.Empty;
                Settings.UserId = string.Empty;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert("Erro", "Não foi possível efetuar login, tente novamente.", "OK");
                });
                return false;
            }
            else
            {
                Settings.AuthToken = user.MobileServiceAuthenticationToken;
                Settings.UserId = user.UserId;
            }
            return true;
        }

        //public async Task<MobileServiceUser> LoginAsync()
        //{
        //    Initialize();

        //    var auth = DependencyService.Get<IAuthentication>();
        //    var user = await auth.Authenticate(Client, MobileServiceAuthenticationProvider.Facebook);

        //    if (user == null)
        //    {
        //        Settings.AuthToken = string.Empty;
        //        Settings.UserId = string.Empty;

        //        Device.BeginInvokeOnMainThread(async () =>
        //        {
        //            await Application.Current.MainPage.DisplayAlert("Erro", "Não foi possível efetuar login, tente novamente.", "OK");
        //        });
        //        return null;
        //    }
        //    return user;
        //}
    }

}
