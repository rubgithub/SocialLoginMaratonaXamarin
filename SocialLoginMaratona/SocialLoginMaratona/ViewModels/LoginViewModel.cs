using SocialLoginMaratona.Helpers;
using SocialLoginMaratona.Service;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SocialLoginMaratona.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly AzureService _azureService;

        private bool _isBusy;

        public Command LoginCommand { get; }

        public string Title { get; private set; }
        

        public LoginViewModel()
        {
            //não utilizar toker armazenado
            Settings.AuthToken = string.Empty;
            Settings.UserId = string.Empty;

            //_navigation = navigation;
            _azureService = DependencyService.Get<AzureService>();

            LoginCommand = new Command(async () => await ExecuteLoginCommandAsync());
            Title = "Social Login Demo";
        }

        private async Task ExecuteLoginCommandAsync()
        {
            if (_isBusy || !(await LoginAsync()))
            {
                return;
            }
            else
            {
                //var mainPage = new MainPage();
                //await _navigation.PushAsync(mainPage);
                await PushAsync<MainViewModel>();

                //RemovePageFromStack();
            }
            _isBusy = false;
        }

        //private void RemovePageFromStack()
        //{
        //    var existingPages = _navigation.NavigationStack;
        //    foreach (var page in existingPages)
        //    {
        //        _navigation.RemovePage(page);
        //    }
        //}

        private Task<bool> LoginAsync()
        {
            _isBusy = true;
            if (Settings.IsLoggedIn)
                return Task.FromResult(true);

            return _azureService.LoginAsync();
        }
    }    
}
