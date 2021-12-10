using CourseWork_2.DataLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork_2.BusinessLayer
{
    class Business
    {
        IDbManager dbManager = new DbManager();
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

        public List<string> GetDirectories(string directoryPath)
        {
            var it = Directory.EnumerateDirectories(directoryPath).GetEnumerator();
            List<string> directoryNames = new List<string>();


            while (true)
            {
                try
                {
                    while (it.MoveNext())
                    {
                        DirectoryInfo fileInf = new DirectoryInfo(it.Current);

                        if (!fileInf.Attributes.HasFlag(FileAttributes.Hidden)
                            &&
                            !fileInf.Attributes.HasFlag(FileAttributes.System)) directoryNames.Add(it.Current);
                    }
                    break;

                }
                catch (System.UnauthorizedAccessException e)
                {

                }
            }

            return directoryNames;
        }

        public ImageList GetImagesForFileExplorer(ListView fileExplorer)
        {
            return dbManager.GetImagesForFileExplorer(fileExplorer);
        }

        public List<ListViewItem> GetFileRecords(string directoryPath)
        {
            List<ListViewItem> items = new List<ListViewItem>();
            if (directoryPath.Length > 3)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(directoryPath);

                ListViewItem item = new ListViewItem("");
                item.SubItems.Add("");
                item.SubItems.Add("<Directory>");
                item.SubItems.Add(dirInfo.CreationTime.ToString());
                item.SubItems.Add(dirInfo.FullName);
                items.Add(item);
            }
            foreach (DirectoryInfo dirInfo in GetDirectoriesInfo(directoryPath))
            {
                ListViewItem item = new ListViewItem(dirInfo.Name);
                item.SubItems.Add("");
                item.SubItems.Add("<Directory>");
                item.SubItems.Add(dirInfo.CreationTime.ToString());
                item.SubItems.Add(dirInfo.FullName);
                items.Add(item);
            }

            foreach (FileInfo fileInfo in GetFilesInfo(directoryPath))
            {
                ListViewItem item = new ListViewItem(fileInfo.Name);
                item.SubItems.Add(fileInfo.Extension);
                item.SubItems.Add(fileInfo.Length.ToString());
                item.SubItems.Add(fileInfo.CreationTime.ToString());
                item.SubItems.Add(fileInfo.FullName);
                items.Add(item);
            }

            return items;
        }

        public string GetFullPathForNode(TreeNode node)
        {
            return node.FullPath[12] + ":" + node.FullPath.Substring(15);
        }
    }
}
