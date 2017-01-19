using System;
using System.IO;
using System.Net.Cache;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using zongmu_toolkit.Utils;
using Timer = System.Timers.Timer;

namespace zongmu_toolkit.Views.MediaPlayer
{
    /// <summary>
    /// Interaction logic for VideoPlayer.xaml
    /// </summary>
    public partial class VideoPlayer
    {
        private Timer timer;
        private long currentFrame;
        private string hash;
        private Status status;
        private double currentTime;
        private Uri source;
        private VideoInfo videoInfo;
        private delegate void OnTimeChangeEventHandler();
        private readonly VideoProcessor processor = new VideoProcessor();
        private string Cache = @"c:/cache/";

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
            var filePath = string.Format(@"{0}\{1}\frame{2}.jpg", Cache, this.hash, currentFrame);
            while (!File.Exists(filePath))
            {
                Thread.Sleep(1000);
            }
            var uri = new Uri(filePath);
            Console.WriteLine(uri);
            this.ImageControl.Source = new BitmapImage(uri, new RequestCachePolicy(RequestCacheLevel.CacheIfAvailable));
        }

        private void OnSourceChanged(Uri oldSource, Uri newSource)
        {
            this.hash = FileUtils.ComputeHash(newSource.LocalPath);
            var dir = Cache + hash;
            FileUtils.CreateIfNotExists(dir);
            this.videoInfo = this.processor.ReadVideoInfo(newSource.LocalPath);
            Task.Factory.StartNew(() => this.processor.ExtactPicture(this.videoInfo, newSource.LocalPath, dir));
            //this.processor.ExtactPicture(this.videoInfo, newSource.LocalPath, dir);

            this.LoadVideoResource(newSource);
        }

        private void LoadVideoResource(Uri newSource)
        {


        }

    }
}
