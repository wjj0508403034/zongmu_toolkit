using zongmu_toolkit.Views.MediaPlayer.Commands;
using zongmu_toolkit.Views.MediaPlayer.Exceptions;

namespace zongmu_toolkit.Views.MediaPlayer
{
    public class VideoProcessor
    {
        public VideoInfo ReadVideoInfo()
        {
            var command = new ReadVideoInfoCommand();
            var result = command.Run();
            if(!result.HasError && !string.IsNullOrEmpty(result.Output))
            {
                return VideoInfo.Parse(result.Output);
            }

            throw new ReadVideoInfoFailedException();
        }

        public void ExtactPicture(VideoInfo videoInfo)
        {
            
        }
    }
}
