using System;
using System.Net.Cache;
using System.Timers;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace zongmu_toolkit.Views.MediaPlayer
{
    /// <summary>
    /// Interaction logic for VideoPlayer.xaml
    /// </summary>
    public partial class VideoPlayer
    {
        private Timer timer;
        private long currentFrame;
        private Status status;
        private double currentTime;
        private Uri source;
        private VideoInfo videoInfo;
        private delegate void OnTimeChangeEventHandler();
        private readonly VideoProcessor processor = new VideoProcessor();

        public VideoPlayer()
        {
            InitializeComponent();

        }

        public VideoPlayer(Uri source)
            : this()
        {
            this.Source = source;
        }

        public Uri Source
        {
            get
            {
                return this.source;
            }
            set
            {
                this.OnSourceChanged(this.source, value);
                this.source = value;
            }
        }

        public double CurrentTime
        {
            get
            {
                return this.currentTime;
            }
        }

        public Status Status
        {
            get { return this.status; }
        }

        public long CurrentFrame
        {
            get { return this.currentFrame; }
        }

        public long TotalFrames
        {
            get { return this.videoInfo.TotalFrames; }
        }

        public double Duration
        {
            get { return this.videoInfo.Duration; }
        }

        public double VideoHeight
        {
            get { return this.videoInfo.Height; }
        }

        public double VideoWidth
        {
            get { return this.videoInfo.Width; }
        }

        public void Play()
        {
            this.currentFrame = 1;
            this.currentTime = 0;
            this.timer = new Timer(1000 / this.videoInfo.FPS);
            this.timer.Elapsed += OnTimerElapsed;
            this.timer.Start();
            this.status = Status.Playing;
        }

        public void Pause()
        {
            this.timer.Stop();
            this.status = Status.Pause;
        }

        public void Stop()
        {
            this.status = Status.End;
            this.StopPlayer();
        }

        private void StopPlayer()
        {
            this.timer.Stop();
            this.timer.Elapsed -= OnTimerElapsed;
            this.timer.Dispose();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (this.TotalFrames <= this.currentFrame)
            {
                this.Stop();
                return;
            }

            currentFrame++;
            this.Dispatcher.Invoke(DispatcherPriority.Background, new OnTimeChangeEventHandler(this.OnTimeChanged));
        }

        private void OnTimeChanged()
        {
            var uri = new Uri(string.Format(@"C:\demo\testaaa\test({0}).jpg", currentFrame));
            Console.WriteLine(uri);
            this.ImageControl.Source = new BitmapImage(uri, new RequestCachePolicy(RequestCacheLevel.CacheIfAvailable));
        }

        private void OnSourceChanged(Uri oldSource, Uri newSource)
        {
            this.videoInfo = this.processor.ReadVideoInfo();
            this.LoadVideoResource(newSource);
        }

        private void LoadVideoResource(Uri newSource)
        {
            
        }

    }
}
