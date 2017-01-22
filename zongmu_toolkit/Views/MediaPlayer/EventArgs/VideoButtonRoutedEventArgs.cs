using System.Windows;

namespace zongmu_toolkit.Views.MediaPlayer.EventArgs
{
    public class VideoButtonRoutedEventArgs : RoutedEventArgs
    {
        public Action Action { get; set; }

        public VideoButtonRoutedEventArgs(RoutedEventArgs e, Action action)
            : base(e.RoutedEvent, e.Source)
        {
            this.Action = action;
        }
    }
}
