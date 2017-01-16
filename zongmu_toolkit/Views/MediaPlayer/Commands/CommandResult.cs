namespace zongmu_toolkit.Views.MediaPlayer.Commands
{
    public class CommandResult
    {
        public bool HasError { get { return !string.IsNullOrEmpty(this.ErrorOutput); } }
        public string Output { get; set; }
        public string ErrorOutput { get; set; }
    }
}
