using CourseWork_2.DataLayer;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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
                    continue;
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
                        //fileInf.GetFiles();
                        if (!fileInf.Attributes.HasFlag(FileAttributes.Hidden)
                            &&
                            !fileInf.Attributes.HasFlag(FileAttributes.System)) directoryInfos.Add(fileInf);
                    }
                    break;

                }
                catch (System.UnauthorizedAccessException e)
                {
                    continue;
                }
            }

            return directoryInfos;
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
                item.SubItems.Add(dirInfo.CreationTime.ToString("MM-dd-yyyy HH:mm"));
                item.SubItems.Add(dirInfo.Attributes.ToString());
                item.SubItems.Add(dirInfo.FullName);
                items.Add(item);
            }
            foreach (DirectoryInfo dirInfo in GetDirectoriesInfo(directoryPath))
            {
                ListViewItem item = new ListViewItem(" " + dirInfo.Name);
                item.SubItems.Add("");
                item.SubItems.Add("<Directory>");
                item.SubItems.Add(dirInfo.CreationTime.ToString("MM-dd-yyyy HH:mm"));
                item.SubItems.Add(dirInfo.Attributes.ToString());
                item.SubItems.Add(dirInfo.FullName);
                items.Add(item);
            }

            foreach (FileInfo fileInfo in GetFilesInfo(directoryPath))
            {
                ListViewItem item = new ListViewItem(" " + fileInfo.Name);
                item.SubItems.Add(fileInfo.Extension.Substring(1));
                item.SubItems.Add(fileInfo.Length.ToString("N", CultureInfo.CreateSpecificCulture("fr-FR"))
                    .Substring(0, fileInfo.Length.ToString("N", CultureInfo.CreateSpecificCulture("fr-FR")).Length - 3));
                item.SubItems.Add(fileInfo.CreationTime.ToString("MM-dd-yyyy HH:mm"));
                item.SubItems.Add(fileInfo.Attributes.ToString());
                item.SubItems.Add(fileInfo.FullName);
                items.Add(item);
            }

            return items;
        }
        public static List<string> GetDirectories(string directoryPath)
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
                    continue;
                }
                catch (Exception e)
                {
                    continue;
                }
            }

            return directoryNames;
        }
        public List<ListViewItem> GetLogicalDiskRecords()
        {
            List<ListViewItem> listViewItems = new List<ListViewItem>();

            foreach(string driveName in Directory.GetLogicalDrives())
            {
                DriveInfo driveInfo = new DriveInfo(driveName);
                ListViewItem listViewItem = new ListViewItem(driveInfo.Name/*driveInfo.Name.Substring(0, driveInfo.Name.Length - 1)*/);
                listViewItems.Add(listViewItem);
            }

            return listViewItems;
        }


        public ImageList GetImagesForFileExplorer(ListView fileExplorer)
        {
            return dbManager.GetImagesForFileExplorer(fileExplorer);
        }
        public ImageList GetImageForDrivers()
        {
            ImageList imageList = new ImageList();
            imageList.Images.Add(dbManager.GetImage("newDriveImage"));
            //imageList.Images.Add(Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\Без названия.png"));
            imageList.ImageSize = new Size(50, 60);
            return imageList;
        }
        public ImageList GetTreeViewImageForDrivers()
        {
            ImageList imageList = new ImageList();
            imageList.Images.Add(dbManager.GetImage("driveImage"));
            //imageList.Images.Add(Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\Без названия.png"));
            imageList.ImageSize = new Size(60, 60);
            return imageList;
        }
        public ImageList GetImageForRefreshButton(Size buttonSize)
        {
            ImageList imageList = new ImageList();
            imageList.Images.Add(dbManager.GetImage("drictoryImage2"));
            //imageList.Images.Add(Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\Без названия.png"));
            imageList.ImageSize = buttonSize;
            return imageList;

        }
        public Image GetImageForDirectory()
        {
            return dbManager.GetImage("drictoryImage");
        }


        private static bool DeleteDirectory(string filePath)
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
        private static bool DeleteFile(string filePath)
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
        public static bool Delete(string filePath)
        {
            if (File.GetAttributes(filePath).HasFlag(FileAttributes.Directory)) return DeleteDirectory(filePath);
            else return DeleteFile(filePath);
        }
        public static void DeleteWithProgressBar(string Path)
        {
            if (ServiceLayer.Service.isDirectory(Path))
            {
                FileSystem.DeleteDirectory(Path, UIOption.AllDialogs, RecycleOption.SendToRecycleBin, UICancelOption.DoNothing);
            }
            else
            {
                FileSystem.DeleteFile(Path, UIOption.AllDialogs, RecycleOption.SendToRecycleBin, UICancelOption.DoNothing);
            }
        }


        private static bool MoveFile(string oldPath, string newPath)
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
        private static bool MoveDirectory(string oldPath, string newPath)
        {
            if (newPath.Contains(oldPath)) return false;
            else
            {
                Copy(oldPath, newPath);
                DeleteDirectory(oldPath);
                return true;
            }
        }
        public static bool Move(string oldPath, string newPath)
        {
            if (newPath.Contains(oldPath)) return false;
            else
            {
                if(!Copy(oldPath, newPath)) return false;
                Delete(oldPath);
                return true;
            }
            /* if (File.GetAttributes(oldPath).HasFlag(FileAttributes.Directory)) return MoveDirectory(oldPath, newPath);
             else return MoveFile(oldPath, newPath);*/
        }
        public static void MoveWithProgressBar(string oldPath, string newPath)
        {
            if (ServiceLayer.Service.isDirectory(oldPath))
            {
                FileSystem.MoveDirectory(oldPath, newPath + "\\" + new DirectoryInfo(oldPath).Name, UIOption.AllDialogs, UICancelOption.DoNothing);
            }
            else
            {
                FileSystem.MoveFile(oldPath, newPath + "\\" + new FileInfo(oldPath).Name, UIOption.AllDialogs, UICancelOption.DoNothing);
            }
        }


        private static bool CopyFile(string filePath, string newFilePath)
        {
            try
            {
                FileInfo copyedFileInfo = new FileInfo(filePath);
                DirectoryInfo dirInfo = new DirectoryInfo(newFilePath);
                foreach(FileInfo fileInfo in dirInfo.EnumerateFiles())
                {
                    if(fileInfo.Name == copyedFileInfo.Name)
                    {
                        copyedFileInfo.CopyTo(Path.Combine(newFilePath, "(copy)" + copyedFileInfo.Name), true);
                        return true;
                    }
                }

                copyedFileInfo.CopyTo(Path.Combine(newFilePath, new FileInfo(filePath).Name), true);
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

                DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);
                //DirectoryInfo diTarget = new DirectoryInfo(targetDirectory + "\\" + diSource.Name);

                string directoryName = diSource.Name;

                Foo:
                foreach (DirectoryInfo dirInfo in diTarget.GetDirectories())
                {
                    if (dirInfo.Name == directoryName)
                    {
                        directoryName = "copy-" + directoryName;
                        goto Foo;
                    }
                }
                
                //Directory.CreateDirectory(diTarget.FullName + "\\" + diSource.Name);
                CopyAll(diSource, Directory.CreateDirectory(diTarget.FullName + "\\" + directoryName));

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
        private static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
/*            foreach(DirectoryInfo dirInfo in target.GetDirectories())
            {
                if(dirInfo.Name == source.Name)
                {
                    Directory.CreateDirectory(target.FullName);

                }
            }*/
            //Directory.CreateDirectory(target.FullName);

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
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", System.IO.SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", System.IO.SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }
        public static void CopyWithProgressBar(string oldPath, string newPath)
        {
                
            if (ServiceLayer.Service.isDirectory(oldPath))
            {
                string NewName = new DirectoryInfo(oldPath).Name;
                while (true)
                {
                    List<string> Dirs = GetDirectories(newPath);
                    if (Dirs.Contains((newPath + "\\" + NewName).Replace("\\\\", "\\")))
                    {
                        NewName = "copy-" + NewName;
                    }
                    else break;
                }

                FileSystem.CreateDirectory(newPath + "\\" + NewName);
                //Directory.CreateDirectory(newPath + "\\" + new DirectoryInfo(oldPath).Name);
                FileSystem.CopyDirectory(oldPath, newPath + "\\" + NewName, UIOption.AllDialogs, UICancelOption.DoNothing);
            }
            else
            {
                FileSystem.CopyFile(oldPath, newPath.Trim("\\".ToCharArray()) + "\\" + new FileInfo(oldPath).Name, UIOption.AllDialogs, UICancelOption.DoNothing);
                
            }
        }

        public static void CreateDirectory(string name)
        {
            Directory.CreateDirectory(name);
        }
        public static bool HasAccessToDirectory(string directoryName)
        {
            return Directory.Exists(directoryName);
        }

    }
}
