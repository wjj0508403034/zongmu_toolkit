using System;

namespace zongmu_toolkit.Core.FileSizes
{
    public abstract class AbstractFileSize : IFileSize
    {

        protected abstract int Unit { get; }
        protected abstract string UnitText { get; }

        private double value
        {
            get
            {
                return this.ByteLength * 1.0 / this.Unit;
            }
        }


        public AbstractFileSize(long byteLength)
        {
            this.ByteLength = byteLength;
        }

        public long ByteLength { get; private set; }

        public bool LargeThan(IFileSize fileSize)
        {
            return this.ByteLength > fileSize.ByteLength;
        }

        public bool Equal(IFileSize fileSize)
        {
            return this.ByteLength == fileSize.ByteLength;
        }

        public bool SmallThan(IFileSize fileSize)
        {
            return this.ByteLength < fileSize.ByteLength;
        }

        public new string ToString()
        {
            return string.Format("{0:N}{1}", this.value, this.UnitText);
        }
    }
}
