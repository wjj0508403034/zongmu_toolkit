using System;

namespace zongmu_toolkit.Core.FileSizes
{
    public class KB : AbstractFileSize
    {
        public KB(long byteLength)
            : base(byteLength)
        {
        }

        protected override int Unit
        {
            get { return 1024; }
        }

        protected override string UnitText
        {
            get { return "KB"; }
        }

        public static implicit operator KB(long byteLength)
        {
            return new KB(byteLength);
        }

        public static implicit operator long(KB kb)
        {
            if (kb == null)
            {
                throw new ArgumentNullException("kb");
            }
            return kb.ByteLength;
        }
    }
}
