using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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
}
