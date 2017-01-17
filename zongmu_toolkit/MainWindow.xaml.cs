using System;
using System.Windows;
using System.Windows.Threading;
using Limilabs.FTP.Client;
using zongmu_toolkit.Configs;
using zongmu_toolkit.Views.MediaPlayer.Commands;

namespace zongmu_toolkit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var ss = Configuration.GetSection<AppConfig>("app");
            //var command = new ReadVideoInfoCommand();
            //command.Run();
            //this.xx.Source = new Uri(@"C:\demo\Highlander_Day_Sun_2016_4_14_2\Datalog\front.avi");
            //this.xx.Play();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
//            this.ProgressBar.Value = 50;
//            using (var ftp = new Ftp())
//            {
//                ftp.Connect("localhost");
//                ftp.Login("sa", "123456");
//                ftp.Progress += ftp_Progress;
//                ftp.CreateFolder("TestXX");
//                var ftpResponse = ftp.Upload(@"TestXX\front.avi", @"C:\demo\Highlander_Day_Sun_2016_4_14_2\Datalog\front.avi");
//                if (ftpResponse.Code == 226)
//                {
//                    Console.WriteLine("Success");
//                }
//                else
//                {
//                    Console.WriteLine("Failed");
//                }
//                ftp.Close();
//            }

        }

        private void ftp_Progress(object sender, ProgressEventArgs e)
        {
            Console.WriteLine(e.Percentage);
            this.Dispatcher.Invoke(DispatcherPriority.Background, new OnProgressChangedEventHandler(this.OnProgressChanged), e.Percentage);

        }

        private void OnProgressChanged(double percentage)
        {
            //this.ProgressBar.Value = percentage;
        }

        private delegate void OnProgressChangedEventHandler(double percentage);
    }
}
