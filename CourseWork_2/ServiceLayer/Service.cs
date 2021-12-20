using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork_2.ServiceLayer
{
    static class Service
    {
        private const uint SHGFI_ICON = 0x100;
        private const uint SHGFI_LARGEICON = 0x0;
        private const uint SHGFI_SMALLICON = 0x1;
        private const uint SHGFI_DISPLAYNAME = 0x00000200;
        private const uint SHGFI_TYPENAME = 0x400;

        public static Icon GetSmallFileIcon(this FileInfo file)
        {
            if (file.Exists)
            {
                SHFILEINFO shFileInfo = new SHFILEINFO();
                SHGetFileInfo(file.FullName, 0, ref shFileInfo, (uint)Marshal.SizeOf(shFileInfo), SHGFI_ICON | SHGFI_SMALLICON);

                return Icon.FromHandle(shFileInfo.hIcon);
            }
            else return SystemIcons.WinLogo;
        }

        public static Icon GetSmallFileIcon(string fileName)
        {
            return GetSmallFileIcon(new FileInfo(fileName));
        }

        public static Icon GetLargeFileIcon(this FileInfo file)
        {
            if (file.Exists)
            {
                SHFILEINFO shFileInfo = new SHFILEINFO();
                SHGetFileInfo(file.FullName, 0, ref shFileInfo, (uint)System.Runtime.InteropServices.Marshal.SizeOf(shFileInfo), SHGFI_ICON | SHGFI_LARGEICON);

                return Icon.FromHandle(shFileInfo.hIcon);
            }
            else return SystemIcons.WinLogo;
        }

        public static Icon GetLargeFileIcon(string fileName)
        {
            return GetLargeFileIcon(new FileInfo(fileName));
        }

        public static string GetFullPathForNode(TreeNode node)
        {
            return node.FullPath[12] + ":" + node.FullPath.Substring(15);
        }

        public static List<string> collectExpandedNodes(TreeNodeCollection Nodes)
        {
            List<string> _lst = new List<string>();
            foreach (TreeNode checknode in Nodes)
            {
                if (checknode.IsExpanded)
                    _lst.Add(checknode.Name);
                if (checknode.Nodes.Count > 0)
                    _lst.AddRange(collectExpandedNodes(checknode.Nodes));
            }
            return _lst;
        }
        public static TreeNode FindNodeByName(TreeNodeCollection NodesCollection, string Name)
        {
            TreeNode returnNode = null; // Default value to return
            foreach (TreeNode checkNode in NodesCollection)
            {
                if (checkNode.Name == Name)  //checks if this node name is correct
                    returnNode = checkNode;
                else if (checkNode.Nodes.Count > 0) //node has child
                {
                    returnNode = FindNodeByName(checkNode.Nodes, Name);
                }

                if (returnNode != null) //check if founded do not continue and break
                {
                    return returnNode;
                }

            }
            //not found
            return returnNode;
        }
        public static void expandNodePath(TreeNode node)
        {
            if (node == null)
                return;
            if (node.Level != 0) //check if it is not root
            {
                node.Expand();
                expandNodePath(node.Parent);
            }
            else
            {
                node.Expand(); // this is root 
            }

        }


        public static bool IsPathValidRootedLocal(String pathString)
        {
            Uri pathUri;
            Boolean isValidUri = Uri.TryCreate(pathString, UriKind.Absolute, out pathUri);
            return isValidUri && pathUri != null && pathUri.IsLoopback;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public SHFILEINFO(bool b)
            {
                hIcon = IntPtr.Zero; iIcon = IntPtr.Zero; dwAttributes = 0; szDisplayName = ""; szTypeName = "";
            }

            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };


        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

    }
    class Monitor
    {
        private List<string> _filePaths;
        public void CreateWatcher(string path)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();

            watcher.Filter = "*.*";

            watcher.Created += new
            FileSystemEventHandler(watcher_FileCreated);

            watcher.Path = path;
            watcher.IncludeSubdirectories = true;

            watcher.EnableRaisingEvents = true;
        }

        void watcher_FileCreated(object sender, FileSystemEventArgs e)
        {
            //_filePaths.Add(e.FullPath);
            MessageBox.Show("Files have been created or moved! ---> " + e.FullPath);
        }

    }

    public class InsertRemovedDeviceMonitor
    {
        private void DeviceInsertedEvent(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            foreach (var property in instance.Properties)
            {
                Console.WriteLine(property.Name + " = " + property.Value);
            }
        }

        private void DeviceRemovedEvent(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            foreach (var property in instance.Properties)
            {
                Console.WriteLine(property.Name + " = " + property.Value);
            }
        }

        public InsertRemovedDeviceMonitor(EventArrivedEventHandler InsertEvent, EventArrivedEventHandler RemovedEvent)
        {
            WqlEventQuery insertQuery = new WqlEventQuery("SELECT * FROM __InstanceCreationEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_USBHub'");

            ManagementEventWatcher insertWatcher = new ManagementEventWatcher(insertQuery);
            insertWatcher.EventArrived += InsertEvent;
            insertWatcher.Start();

            WqlEventQuery removeQuery = new WqlEventQuery("SELECT * FROM __InstanceDeletionEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_USBHub'");
            ManagementEventWatcher removeWatcher = new ManagementEventWatcher(removeQuery);
            removeWatcher.EventArrived += RemovedEvent;
            removeWatcher.Start();

            // Do something while waiting for events
            //System.Threading.Thread.Sleep(20000000);
        }
    }
}
    namespace System.IO
    {
        public static class FileInfoExtensions
        {
            public static void Rename(this FileInfo fileInfo, string newName)
            {
                fileInfo.MoveTo(Path.Combine(fileInfo.Directory.FullName, newName));
            }
        }
    }

