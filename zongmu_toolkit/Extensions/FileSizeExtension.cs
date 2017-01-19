using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zongmu_toolkit.Core.FileSizes;

namespace zongmu_toolkit.Extensions
{
    public static class FileSizeExtension
    {

        public static MB MB(this int length)
        {
            return new MB(length);
        }

        public static MB MB(this long length)
        {
            return new MB(length);
        }

        public static GB GB(this int length)
        {
            return new GB(length);
        }
    }
}
