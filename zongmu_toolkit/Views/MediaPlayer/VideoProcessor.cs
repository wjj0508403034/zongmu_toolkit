using System.IO;
using zongmu_toolkit.Views.MediaPlayer.Commands;
using zongmu_toolkit.Views.MediaPlayer.Exceptions;

namespace zongmu_toolkit.Views.MediaPlayer
{
    public class VideoProcessor
    {
        public VideoInfo ReadVideoInfo(string videoPath)
        {
            var command = new ReadVideoInfoCommand(videoPath);
            var result = command.Run();
            if (!result.HasError && !string.IsNullOrEmpty(result.Output))
            {
                return VideoInfo.Parse(result.Output);
            }

            throw new ReadVideoInfoFailedException();
        }

        public void ExtactPicture(VideoInfo videoInfo, string videoPath, string dir)
        {
            for (int frameIndex = 0; frameIndex < videoInfo.TotalFrames; frameIndex++)
            {
                string picName = dir + "\\frame" + frameIndex + ".jpg";
                if (!File.Exists(picName))
                {
                    var command = new ExtactPictureCommand(videoPath, videoInfo.FPS, picName, frameIndex);
                    command.Run();
                }
               
            }
        }
    }
}
