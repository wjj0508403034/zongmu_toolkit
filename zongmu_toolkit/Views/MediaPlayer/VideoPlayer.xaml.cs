using System;
using System.ComponentModel;
using System.Windows.Controls;
using zongmu_toolkit.Views.MediaPlayer.EventArgs;
using zongmu_toolkit.Views.MediaPlayer.EventHandlers;

namespace zongmu_toolkit.Views.MediaPlayer
{
    /// <summary>
    /// Interaction logic for VideoPlayer.xaml
    /// </summary>
    public partial class VideoPlayer
    {
        public VideoPlayer()
        {
            InitializeComponent();
        }


        private VideoProgressChangeEventHandler onVideoProgressChanged;

        [Category("Behavior")]
        public event VideoProgressChangeEventHandler OnVideoProgressChanged
        {
            add
            {
                onVideoProgressChanged += value;
            }
            remove
            {
                onVideoProgressChanged -= value;
            }
        }

        public Uri Source
        {
            get { return this.VideoScreen.Source; }
            set { this.VideoScreen.Source = value; }
        }


        public void Play()
        {
            this.VideoScreen.Play();
        }

        public void Pause()
        {
            this.VideoScreen.Pause();
        }

        private void OnVideoButtonClicked(Button button, VideoButtonRoutedEventArgs e)
        {
            if (e.Action == Action.Play)
            {
                this.Play();
                return;
            }

            if (e.Action == Action.Pause)
            {
                this.Pause();
            }
        }

        private void OnVideoSourceChanged(VideoSourceRoutedEventArgs routedEventArgs)
        {
            this.VideoProgressBar.SetVideoInfo(routedEventArgs.VideoInfo);
        }


    }
}
