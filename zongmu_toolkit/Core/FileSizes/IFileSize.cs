using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zongmu_toolkit.Core.FileSizes
{
    public interface IFileSize
    {
        long ByteLength { get; }
        bool LargeThan(IFileSize fileSize);

        bool Equal(IFileSize fileSize);

        bool SmallThan(IFileSize fileSize);
    }
}
