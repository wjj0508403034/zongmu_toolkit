using System.Windows;

namespace zongmu_toolkit.Views.MediaPlayer.EventArgs
{
    public class VideoProgressRoutedEventArgs : RoutedEventArgs
    {
        public double Duration { get; private set; }
    }
}
