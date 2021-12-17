using CourseWork_2.DataLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork_2.BusinessLayer
{
    public class Business
    {
        IDbManager dbManager;

        public Business(IDbManager dbManager)
        {
            this.dbManager = dbManager;
        }


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

        public ImageList GetImageForDrivers()
        {
            ImageList imageList = new ImageList();
            imageList.Images.Add(dbManager.GetImage("driveImage"));
            //imageList.Images.Add(Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\Без названия.png"));
            imageList.ImageSize = new Size(45, 45);
            return imageList;
        }
        public ImageList GetImageForRefreshButton()
        {
            ImageList imageList = new ImageList();
            imageList.Images.Add(dbManager.GetImage("refreshButtonImage2"));
            //imageList.Images.Add(Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\Без названия.png"));
            imageList.ImageSize = new Size(15, 15);
            return imageList;

        }
        public Image GetImageForDirectory()
        {
            return dbManager.GetImage("drictoryImage");
        }
        public List<ListViewItem> GetFileRecords(string directoryPath)
        {
            List<ListViewItem> items = new List<ListViewItem>();
            if (true/*directoryPath.Length > 3*/)
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

        public List<ListViewItem> GetLogicalDiskRecords()
        {
            List<ListViewItem> listViewItems = new List<ListViewItem>();

            foreach(string driveName in Directory.GetLogicalDrives())
            {
                DriveInfo driveInfo = new DriveInfo(driveName);
                ListViewItem listViewItem = new ListViewItem(driveInfo.Name);
                listViewItems.Add(listViewItem);
            }

            return listViewItems;
        }

        public string GetFullPathForNode(TreeNode node)
        {
            return node.FullPath[12] + ":" + node.FullPath.Substring(15);
        }


        private bool DeleteDirectory(string filePath)
        {
            try
            {
                Directory.Delete(filePath, true);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        private bool DeleteFile(string filePath)
        {
            try
            {
                File.Delete(filePath);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(string filePath)
        {
            if (File.GetAttributes(filePath).HasFlag(FileAttributes.Directory)) return DeleteDirectory(filePath);
            else return DeleteFile(filePath);
        }



        private bool MoveFile(string oldPath, string newPath)
        {
            try
            {
                File.Move(oldPath, newPath);
                return true;
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        private bool MoveDirectory(string oldPath, string newPath)
        {
            if (newPath.Contains(oldPath)) return false;
            else
            {
                Copy(oldPath, newPath);
                DeleteDirectory(oldPath);
                return true;
            }
        }

        public bool Move(string oldPath, string newPath)
        {
            if (newPath.Contains(oldPath)) return false;
            else
            {
                Copy(oldPath, newPath);
                Delete(oldPath);
                return true;
            }
            /* if (File.GetAttributes(oldPath).HasFlag(FileAttributes.Directory)) return MoveDirectory(oldPath, newPath);
             else return MoveFile(oldPath, newPath);*/
        }


        private static bool CopyFile(string filePath, string newFilePath)
        {
            try
            {
                new FileInfo(filePath).CopyTo(Path.Combine(newFilePath, new FileInfo(filePath).Name), true);
                //File.Copy(filePath, newFilePath);
                return true;
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
        public static bool Copy(string sourceDirectory, string targetDirectory)
        {
            try
            {
                if (!File.GetAttributes(sourceDirectory).HasFlag(FileAttributes.Directory)) return CopyFile(sourceDirectory, targetDirectory);

                DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
                Directory.CreateDirectory(targetDirectory + "\\" + diSource.Name);
                DirectoryInfo diTarget = new DirectoryInfo(targetDirectory + "\\" + diSource.Name);

                CopyAll(diSource, diTarget);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
        private static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                //Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
        public static void _CopyFilesRecursively(string sourcePath, string targetPath)
        {
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }
    }
}
