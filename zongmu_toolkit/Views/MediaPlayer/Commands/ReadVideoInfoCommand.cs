using System.Diagnostics;

namespace zongmu_toolkit.Views.MediaPlayer.Commands
{
    public class ReadVideoInfoCommand : AbstractCommand
    {
        private const string Args = "-loglevel error -show_streams {0} -print_format xml=x=1 -noprivate";
        

        protected override ProcessStartInfo GetProcessStartInfo()
        {
            return new ProcessStartInfo(this.FfmpegConfig.FfProbe, string.Format(Args,this.FilePath));
        }
    }
}
