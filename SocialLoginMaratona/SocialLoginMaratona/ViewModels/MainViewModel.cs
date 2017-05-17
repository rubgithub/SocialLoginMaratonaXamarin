using SocialLoginMaratona.Helpers;

namespace SocialLoginMaratona.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        public string UserId { get; private set; }
        public string Token { get; private set; }

        public MainViewModel()
        {
            UserId = Settings.UserId;
            Token = Settings.AuthToken;
        }
    }
}
