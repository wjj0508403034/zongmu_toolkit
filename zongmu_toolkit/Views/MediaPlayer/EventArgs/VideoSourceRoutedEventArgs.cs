using System;
using System.Windows;

namespace zongmu_toolkit.Views.MediaPlayer.EventArgs
{
    public class VideoSourceRoutedEventArgs : RoutedEventArgs
    {
        public VideoInfo VideoInfo { get; private set; }
        public Uri OldSource { get; private set; }
        public Uri NewSource { get; private set; }

        public VideoSourceRoutedEventArgs(VideoInfo videoInfo, Uri oldSource, Uri newSource)
        {
            this.VideoInfo = videoInfo;
            this.OldSource = oldSource;
            this.NewSource = newSource;
        }
    }
}
