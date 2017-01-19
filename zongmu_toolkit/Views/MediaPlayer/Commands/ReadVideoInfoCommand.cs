using System.Diagnostics;

namespace zongmu_toolkit.Views.MediaPlayer.Commands
{
    public class ReadVideoInfoCommand : AbstractCommand
    {
        private string FilePath { get; set; }

        public ReadVideoInfoCommand(string filePath)
        {
            this.FilePath = filePath;
        }

        public override ProcessStartInfo GetProcessStartInfo()
        {
            return new ProcessStartInfo(@"C:\tmp\ffmpeg\bin\ffprobe.exe", string.Format("-loglevel error -show_streams {0} -print_format xml=x=1 -noprivate", this.FilePath));
        }
    }
}
