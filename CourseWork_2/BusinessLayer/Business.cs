using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_2.BusinessLayer
{
    class Business
    {
        public List<FileInfo> GetFilesInfo(string directoryPath)
        {
            var it = Directory.EnumerateFiles(directoryPath).GetEnumerator();
            List<FileInfo> fileInfos = new List<FileInfo>();


            while (true)
            {
                try
                {
                    while (it.MoveNext())
                    {
                        FileInfo fileInf = new FileInfo(it.Current);
                        
                        if (!fileInf.Attributes.HasFlag(FileAttributes.Hidden)
                            &&
                            !fileInf.Attributes.HasFlag(FileAttributes.System)) fileInfos.Add(fileInf);
                    }
                    break;

                }
                catch (System.UnauthorizedAccessException e)
                {

                }
            }

            return fileInfos;
        }

        public List<DirectoryInfo> GetDirectoriesInfo(string directoryPath)
        {
            var it = Directory.EnumerateDirectories(directoryPath).GetEnumerator();
            List<DirectoryInfo> directoryInfos = new List<DirectoryInfo>();


            while (true)
            {
                try
                {
                    while (it.MoveNext())
                    {
                        DirectoryInfo fileInf = new DirectoryInfo(it.Current);

                        if (!fileInf.Attributes.HasFlag(FileAttributes.Hidden)
                            &&
                            !fileInf.Attributes.HasFlag(FileAttributes.System)) directoryInfos.Add(fileInf);
                    }
                    break;

                }
                catch (System.UnauthorizedAccessException e)
                {

                }
            }

            return directoryInfos;
        }
    }
}
