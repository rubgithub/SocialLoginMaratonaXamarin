using Microsoft.WindowsAzure.MobileServices;
using SocialLoginMaratona.Authentication;
using System.Threading.Tasks;
using Xamarin.Forms;

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
        }

        public async Task<MobileServiceUser> LoginAsync()
        {
            Initialize();
            var auth = DependencyService.Get<IAuthentication>();
            var user = await auth.Authenticate(Client, MobileServiceAuthenticationProvider.Facebook);

            if (user == null)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert("Erro", "Não foi possível efetuar login, tente novamente.", "OK");
                });
                return null;
            }
            return user;
        }
    }

}
