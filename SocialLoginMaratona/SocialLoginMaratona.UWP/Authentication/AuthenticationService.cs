using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using SocialLoginMaratona.Authentication;
using SocialLoginMaratona.Helpers;
using SocialLoginMaratona.UWP.Authentication;

[assembly: Xamarin.Forms.Dependency(typeof(AuthenticationService))]
namespace SocialLoginMaratona.UWP.Authentication
{
    public class AuthenticationService : IAuthentication
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client, MobileServiceAuthenticationProvider provider, IDictionary<string, string> parameters = null)
        {
            try
            {
                var user = await client.LoginAsync(provider);

                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;

                return user;
            }
            catch (Exception)
            {
                //TODO: LogError
                throw;
            }
        }
    }
}