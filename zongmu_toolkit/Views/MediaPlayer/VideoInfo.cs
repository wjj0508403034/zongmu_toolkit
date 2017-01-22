using System.Xml.Linq;
using zongmu_toolkit.Views.MediaPlayer.Exceptions;

namespace zongmu_toolkit.Views.MediaPlayer
{
    public class VideoInfo
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public int FPS { get; set; }
        public long BitRate { get; set; }
        public double Duration { get; set; }
        public long TotalFrames { get; set; }

        public static VideoInfo Parse(string xml)
        {
            var xDoc = XDocument.Parse(xml);
            if (xDoc.Root != null)
            {
                var streamsNode = xDoc.Root.Element("streams");
                if (streamsNode != null)
                {
                    var streamNode = streamsNode.Element("stream");
                    if (streamNode != null)
                    {
                        var video = new VideoInfo();
                        video.Height = (double)streamNode.Attribute("height");
                        video.Width = (double)streamNode.Attribute("width");
                        video.Duration = (double)streamNode.Attribute("duration");
                        video.BitRate = (long)streamNode.Attribute("bit_rate");
                        video.TotalFrames = (long)streamNode.Attribute("nb_frames");
                        var fps = (string)streamNode.Attribute("r_frame_rate");
                        if (fps.Contains("/"))
                        {
                            video.FPS = int.Parse(fps.Split('/')[0]);
                        }
                        return video;
                    }

                }
            }

            throw new ReadVideoInfoFailedException();
        }
    }
}
