using System;
using Android.Content.PM;
using Xamarin.Forms;
using XamForms.Enhanced.Droid.Providers;
using XamForms.Enhanced.Providers;

[assembly: Dependency(typeof(AppInfoProvider))]
namespace XamForms.Enhanced.Droid.Providers
{
    public class AppInfoProvider : IAppInfoProvider
    {
        private readonly PackageInfo _appInfo;

        public AppInfo AppInfo => GetAppInfo();

        public AppInfoProvider()
        {
            var context = Android.App.Application.Context;
            _appInfo = context.PackageManager.GetPackageInfo(context.PackageName, 0);
        }

        public string GetVersionNumber()
        {
            return _appInfo.VersionName;
        }

        public string GetBuildNumber()
        {
            return _appInfo.VersionCode.ToString();
        }

        public AppInfo GetAppInfo()
        {
            return new AppInfo(GetVersionNumber(), GetBuildNumber());
        }
    }
}