using Foundation;
using Xamarin.Forms;
using XamForms.Enhanced.iOS.Providers;
using XamForms.Enhanced.Providers;

[assembly: Dependency(typeof(AppInfoProvider))]
namespace XamForms.Enhanced.iOS.Providers
{
    public class AppInfoProvider : IAppInfoProvider
    {
        private string _bundleVersionKey = "CFBundleVersion";
        private string _bundleVersionShortKey = "CFBundleShortVersionString";

        public AppInfo AppInfo => GetAppInfo();

        public string GetVersionNumber()
        {
            return GetValueFromNsBundle(_bundleVersionShortKey);
        }

        public string GetBuildNumber()
        {
            return GetValueFromNsBundle(_bundleVersionKey);
        }

        public AppInfo GetAppInfo()
        {
            return new AppInfo(GetVersionNumber(), GetBuildNumber());
        }

        private string GetValueFromNsBundle(string key)
        {
            return NSBundle.MainBundle.ObjectForInfoDictionary(key).ToString();
        }
    }
}
