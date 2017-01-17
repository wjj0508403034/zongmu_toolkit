using System.Configuration;

namespace zongmu_toolkit.Configs
{
    public class FfmpegConfig : ConfigurationSection
    {
        [ConfigurationProperty("path", IsRequired = true)]
        public string Dir
        {
            get
            {
                return this["path"] as string;
            }
        }

        public string FfProbe
        {
            get { return string.Format(@"{0}\ffprobe.exe", this.Dir); }
        }

        public string Ffmpeg
        {
            get { return string.Format(@"{0}\ffmpeg.exe", this.Dir); }
        }
    }
}
