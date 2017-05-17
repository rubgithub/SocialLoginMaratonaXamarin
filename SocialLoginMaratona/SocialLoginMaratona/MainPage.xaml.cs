using SocialLoginMaratona.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SocialLoginMaratona
{
    public partial class MainPage : ContentPage
    {
        readonly AzureService azureService = new AzureService();
        public MainPage()
        {
            InitializeComponent();

            LoginButton.Clicked += async (sender, args) =>
            {
                var user = await azureService.LoginAsync();
                InfoLabel.Text = (user != null) ? $"Bem vindo: {user.UserId}" :
                "Falha no login, tente novamente";
            };
        }
    }
}
