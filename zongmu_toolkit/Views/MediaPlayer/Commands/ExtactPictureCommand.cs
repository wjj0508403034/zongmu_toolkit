using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace zongmu_toolkit.Views.MediaPlayer.Commands
{
    public class ExtactPictureCommand : AbstractCommand
    {
        private string FilePath { get; set; }

        private int FPS { get; set; }

        private string PicName { get; set; }

        private int FrameIndex { get; set; }

        public ExtactPictureCommand(string filePath, int fps, string picName,int frameIndex)
        {
            this.FilePath = filePath;
            this.FPS = fps;
            this.PicName = picName;
            this.FrameIndex = frameIndex;
        }

        protected override ProcessStartInfo GetProcessStartInfo()
        {
            return new ProcessStartInfo(@"C:\tmp\ffmpeg\bin\ffmpeg.exe", string.Format("-i {0} -y -f image2 -ss {1} -vframes 1 {2}", this.FilePath, this.FrameIndex * 1.0 / this.FPS, this.PicName));
        }
    }
}
