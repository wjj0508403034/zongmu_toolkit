using System.Configuration;

namespace zongmu_toolkit.Configs
{
    public static class Configuration
    {
        public static T GetSection<T>(string section)
        {
            return (T)ConfigurationManager.GetSection(section);
        }

        public static AppConfig AppConfig()
        {
            return GetSection<AppConfig>("app");
        }

        public static CacheConfig CacheConfig()
        {
            return AppConfig().CacheConfig;
        }
    }
}
