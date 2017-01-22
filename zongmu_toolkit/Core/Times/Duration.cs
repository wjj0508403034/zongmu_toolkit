namespace zongmu_toolkit.Core.Times
{
    public class Duration
    {
        private const int UNIT = 60;
        public double Value { get; private set; }
        public int Hours { get; private set; }
        public int Mintues { get; private set; }
        public double Seconds { get; private set; }

        public Duration(double value)
        {
            this.Value = value;
            this.Seconds = value % UNIT;
            this.Hours = (int)value / (UNIT * UNIT);
            this.Mintues = ((int)this.Value - this.Hours * UNIT * UNIT) / UNIT;
        }


        public new string ToString()
        {
            return string.Format("{0:00}:{1:00}:{2:00}", this.Hours, this.Mintues, this.Seconds);
        }
    }
}
