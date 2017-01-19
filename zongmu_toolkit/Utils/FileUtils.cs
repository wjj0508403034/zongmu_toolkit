using System;
using System.IO;
using System.Security.Cryptography;
using zongmu_toolkit.Core.FileSizes;
using zongmu_toolkit.Extensions;

namespace zongmu_toolkit.Utils
{
    public static class FileUtils
    {
        private const int MaxHashBytesLength = 1024 * 1024 * 10;
        public static string ComputeHash(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException("filePath");
            }

            var fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists)
            {
                throw new FileNotFoundException("File not found", filePath);
            }

            var bufferSize = fileInfo.Length;
            if ((MB)fileInfo.Length > 10.MB())
            {
                bufferSize = MaxHashBytesLength;
            }

            var buffer = new byte[bufferSize];
            using (var fs = new FileStream(filePath, FileMode.Open))
            {
                fs.Read(buffer, 0, MaxHashBytesLength);
            }

            var md5Provider = new MD5CryptoServiceProvider();
            return BitConverter.ToString(md5Provider.ComputeHash(buffer)).Replace("-", "");
        }

        public static void CreateIfNotExists(string dirPath)
        {
            if(string.IsNullOrEmpty(dirPath))
            {
                throw new ArgumentNullException("dirPath");
            }

            var dirInfo = new DirectoryInfo(dirPath);
            if(!dirInfo.Exists)
            {
                dirInfo.Create();
            }
        }

    }
}
