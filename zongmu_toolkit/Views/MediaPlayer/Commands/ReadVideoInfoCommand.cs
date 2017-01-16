using System.Diagnostics;

namespace zongmu_toolkit.Views.MediaPlayer.Commands
{
    public class ReadVideoInfoCommand : AbstractCommand
    {
        public override ProcessStartInfo GetProcessStartInfo()
        {
            return new ProcessStartInfo(@"C:\tmp\ffmpeg\bin\ffprobe.exe", @"-loglevel error -show_streams C:\demo\Highlander_Day_Sun_2016_4_14_2\Datalog\front.avi -print_format xml=x=1 -noprivate");
        }
    }
}
