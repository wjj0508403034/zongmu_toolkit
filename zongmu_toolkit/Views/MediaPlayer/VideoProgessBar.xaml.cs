using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using zongmu_toolkit.Views.MediaPlayer.EventArgs;
using zongmu_toolkit.Views.MediaPlayer.EventHandlers;
using Duration = zongmu_toolkit.Core.Times.Duration;

namespace zongmu_toolkit.Views.MediaPlayer
{
    /// <summary>
    /// Interaction logic for VideoProgessBar.xaml
    /// </summary>
    public partial class VideoProgessBar
    {
        private VideoInfo VideoInfo;

        public VideoProgessBar()
        {
            InitializeComponent();
        }

        public double Maximum
        {
            get { return this.ProgressBar.Maximum; }
            set { this.ProgressBar.Maximum = value; }
        }

        public double Minimun
        {
            get { return this.ProgressBar.Minimum; }
            set { this.ProgressBar.Minimum = value; }
        }

        private VideoButtonClickEventHandler onVideoButtonClicked;

        [Category("Behavior")]
        public event VideoButtonClickEventHandler OnVideoButtonClicked
        {
            add
            {
                onVideoButtonClicked += value;
            }
            remove
            {
                onVideoButtonClicked -= value;
            }
        }

        public void SetVideoInfo(VideoInfo videoInfo)
        {
            this.VideoInfo = videoInfo;
            this.DurationTextBlock.Text = new Duration(this.VideoInfo.Duration).ToString();
            this.CurrentTimeTextBlock.Text = new Duration(0).ToString();
        }

        public void SetVideoTimeInfo()
        {
            
        }

        private void OnPlayButtonClicked(object sender, RoutedEventArgs e)
        {
            if (this.onVideoButtonClicked != null)
            {
                this.onVideoButtonClicked((Button)sender, new VideoButtonRoutedEventArgs(e, Action.Play));
            }
        }

        private void OnPauseButtonClicked(object sender, RoutedEventArgs e)
        {
            if (this.onVideoButtonClicked != null)
            {
                this.onVideoButtonClicked((Button)sender, new VideoButtonRoutedEventArgs(e, Action.Pause));
            }
        }

        private void OnFastFastForwardButtonClicked(object sender, RoutedEventArgs e)
        {
            if (this.onVideoButtonClicked != null)
            {
                this.onVideoButtonClicked((Button)sender, new VideoButtonRoutedEventArgs(e, Action.FastFastBackward));
            }
        }

        private void OnFastForwardButtonClicked(object sender, RoutedEventArgs e)
        {
            if (this.onVideoButtonClicked != null)
            {
                this.onVideoButtonClicked((Button)sender, new VideoButtonRoutedEventArgs(e, Action.FastForward));
            }
        }

        private void OnFastBackwardButtonClicked(object sender, RoutedEventArgs e)
        {
            if (this.onVideoButtonClicked != null)
            {
                this.onVideoButtonClicked((Button)sender, new VideoButtonRoutedEventArgs(e, Action.FastBackward));
            }
        }

        private void OnFastFastBackwardButtonClicked(object sender, RoutedEventArgs e)
        {
            if (this.onVideoButtonClicked != null)
            {
                this.onVideoButtonClicked((Button)sender, new VideoButtonRoutedEventArgs(e, Action.FastFastForward));
            }
        }

        private void OnPreviousFrameButtonClicked(object sender, RoutedEventArgs e)
        {
            if (this.onVideoButtonClicked != null)
            {
                this.onVideoButtonClicked((Button)sender, new VideoButtonRoutedEventArgs(e, Action.PreviousFrame));
            }
        }

        private void OnNextFrameButtonClicked(object sender, RoutedEventArgs e)
        {
            if (this.onVideoButtonClicked != null)
            {
                this.onVideoButtonClicked((Button)sender, new VideoButtonRoutedEventArgs(e, Action.NextFrame));
            }
        }
    }

    public enum Action
    {
        Play,
        Pause,
        FastFastForward,
        FastForward,
        FastBackward,
        FastFastBackward,
        PreviousFrame,
        NextFrame
    }



}
