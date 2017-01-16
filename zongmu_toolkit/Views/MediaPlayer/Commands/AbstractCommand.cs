using System;
using System.Diagnostics;
using System.Text;
using log4net;

namespace zongmu_toolkit.Views.MediaPlayer.Commands
{
    public abstract class AbstractCommand : ICommand, IDisposable
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(AbstractCommand));

        private readonly Process process = new Process();

        public abstract ProcessStartInfo GetProcessStartInfo();

        public CommandResult Run()
        {
            return this.Run(this.GetProcessStartInfo());
        }

        private CommandResult Run(ProcessStartInfo info)
        {
            info.RedirectStandardInput = true;
            info.RedirectStandardOutput = true;
            info.RedirectStandardError = true;
            info.UseShellExecute = false;
            info.CreateNoWindow = true;
            info.StandardErrorEncoding = Encoding.UTF8;
            this.process.StartInfo = info;
            this.process.Start();
            this.process.StandardInput.Flush();
            this.process.StandardInput.Close();
            this.process.WaitForExit();

            var result = new CommandResult();
            result.Output = this.process.StandardOutput.ReadToEnd();
            Logger.Info(result.Output);
            result.ErrorOutput = this.process.StandardError.ReadToEnd();
            Logger.Error(result.ErrorOutput);
            return result;
        }

        public void Dispose()
        {
            this.process.Dispose();
        }
    }
}
