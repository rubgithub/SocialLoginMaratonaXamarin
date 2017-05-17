using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialLoginMaratona.Authentication
{
    public interface IAuthentication
    {
        Task<MobileServiceUser> Authenticate(MobileServiceClient client, MobileServiceAuthenticationProvider provider,
            IDictionary<string, string> parameters = null);
    }
}
