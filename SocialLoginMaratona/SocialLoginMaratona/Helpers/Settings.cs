using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace SocialLoginMaratona.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        const string UserIdKey = "userId";
        private static readonly string UserIdDefault = string.Empty;

        const string AuthTokeyKey = "authtoken";
        static readonly string AuthTokeyDefault = string.Empty;

        public static string AuthToken
        {
            get { return AppSettings.GetValueOrDefault<string>(AuthTokeyKey, AuthTokeyDefault); }
            set { AppSettings.AddOrUpdateValue<string>(AuthTokeyKey, value); }
        }

        public static string UserId
        {
            get { return AppSettings.GetValueOrDefault<string>(UserIdKey, UserIdDefault); }
            set { AppSettings.AddOrUpdateValue<string>(UserIdKey, value); }
        }

        public static bool IsLoggedIn => !string.IsNullOrWhiteSpace(UserId);
    }
}