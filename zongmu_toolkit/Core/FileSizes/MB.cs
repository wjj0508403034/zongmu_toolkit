using System;

namespace zongmu_toolkit.Core.FileSizes
{
    public class MB : AbstractFileSize
    {
        public MB(long byteLength)
            : base(byteLength)
        {
        }

        protected override int Unit
        {
            get { return 1024 * 1024; }
        }

        protected override string UnitText
        {
            get { return "MB"; }
        }


        public static implicit operator MB(long byteLength)
        {
            return new MB(byteLength);
        }

        public static implicit operator long(MB mb)
        {
            if (mb == null)
            {
                throw new ArgumentNullException("mb");
            }
            return mb.ByteLength;
        }
    }
}
