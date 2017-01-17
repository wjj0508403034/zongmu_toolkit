using System.Configuration;

namespace zongmu_toolkit.Configs
{
    public class FtpConfig : ConfigurationElement
    {
        [ConfigurationProperty("url", IsRequired = true)]
        public string URL
        {
            get
            {
                return this["url"] as string;
            }
            set { this["url"] = value; }
        }

        [ConfigurationProperty("username", IsRequired = true)]
        public string UserName
        {
            get
            {
                return this["username"] as string;
            }
            set { this["username"] = value; }
        }

        [ConfigurationProperty("password", IsRequired = true)]
        public string Password
        {
            get
            {
                return this["password"] as string;
            }
            set { this["password"] = value; }
        }
    }
}
