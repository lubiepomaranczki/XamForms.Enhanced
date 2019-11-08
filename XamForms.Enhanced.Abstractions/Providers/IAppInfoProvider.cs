namespace XamForms.Enhanced.Providers
{
    public interface IAppInfoProvider
    {
        AppInfo AppInfo { get; }
        AppInfo GetAppInfo();
        string GetVersionNumber();
        string GetBuildNumber();
    }

    public struct AppInfo
    {
        public AppInfo(string versionNumber, string buildNumber)
        {
            VersionNumber = versionNumber;
            BuildNumber = buildNumber;
        }

        public string VersionNumber { get; }
        public string BuildNumber { get; }

        public override string ToString()
        {
            return $"{VersionNumber} ({BuildNumber})";
        }
    }
}
