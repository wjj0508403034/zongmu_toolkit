using System.Configuration;

namespace zongmu_toolkit.Configs
{
    public class AppConfig : ConfigurationSection
    {
        [ConfigurationProperty("externalFtp")]
        public FtpConfig ExternalFtpConfig
        {
            get { return (FtpConfig)this["externalFtp"]; }
        }

        [ConfigurationProperty("internalFtp")]
        public FtpConfig InternalFtpConfig
        {
            get { return (FtpConfig)this["internalFtp"]; }
        }

        [ConfigurationProperty("cache")]
        public CacheConfig CacheConfig
        {
            get { return (CacheConfig)this["cache"]; }
        }
    }
}
