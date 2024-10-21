using System;
using System.IO;

namespace NeoSystems.FileUtils
{
    public class FileNameUtils
    {
        public static string AddDateTimeToFileName(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            string name = Path.GetFileNameWithoutExtension(fileName);

            return $"{name}-{DateTime.Now:yyyy-MM-dd-HH-mm-ss}{extension}";
        }
    }
}

