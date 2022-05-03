using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home13
{
    public static class FileHelper
    {
        public static void GetAllFiles(string rootDirectory, string fileExtension, List<string> files)
        {
            string[] directories = Directory.GetDirectories(rootDirectory);
            files.AddRange(Directory.GetFiles(rootDirectory, fileExtension));

            foreach (string path in directories)
                GetAllFiles(path, fileExtension, files);
        }
    }
}
