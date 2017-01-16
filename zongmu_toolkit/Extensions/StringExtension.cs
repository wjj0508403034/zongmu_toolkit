using System.IO;
using System.Text;

namespace zongmu_toolkit.Extensions
{
    public static class StringExtension
    {
        public static Stream ToStream(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }

            var stream = new MemoryStream();
            var writer = new StreamWriter(stream,Encoding.UTF8);
            writer.Write(str);
            writer.Flush();
            return stream;
        }
    }
}
