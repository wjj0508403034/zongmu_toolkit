using System;

namespace zongmu_toolkit.Core.FileSizes
{
    public class GB : AbstractFileSize
    {
        public GB(long byteLength)
            : base(byteLength)
        {
        }

        protected override int Unit
        {
            get { return 1024 * 1024 * 1024; }
        }

        protected override string UnitText
        {
            get { return "GB"; }
        }

        public static implicit operator GB(long byteLength)
        {
            return new GB(byteLength);
        }

        public static implicit operator long(GB gb)
        {
            if (gb == null)
            {
                throw new ArgumentNullException("gb");
            }
            return gb.ByteLength;
        }
    }
}
