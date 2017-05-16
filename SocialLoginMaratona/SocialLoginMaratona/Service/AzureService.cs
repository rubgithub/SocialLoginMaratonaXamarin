using Microsoft.WindowsAzure.MobileServices;
using SocialLoginMaratona.Authentication;
using Xamarin.Forms;

namespace SocialLoginMaratona.Service
{
    public class AzureService
    {
        //TODO: refatorar de acordo cm PDFs
        static readonly string AppUrl = "https://urlparabackend.zurewebsite.net";
        public MobileServiceClient Client { get; set; } = null;

        public void Initialize()
        {
            Client = new MobileServiceClient(AppUrl);
        }

        //public async Task<MobileServiceUser> LoginAsync()
        //{
        //    Initialize();
        //    var auth = DependencyService.Get<IAuthentication>();
        //    var user = await auth.LoginAsync
        //}
    }
}
