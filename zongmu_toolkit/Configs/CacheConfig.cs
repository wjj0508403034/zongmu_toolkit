using System.Configuration;

namespace zongmu_toolkit.Configs
{
    public class CacheConfig : ConfigurationElement
    {
        [ConfigurationProperty("path", IsRequired = true)]
        public string Dir
        {
            get
            {
                return this["path"] as string;
            }
        }
    }
}
