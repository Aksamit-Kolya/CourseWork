using CourseWork_2.BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork_2
{
    public partial class Form1 : Form
    {

        BusinessLayer.Business Business = new BusinessLayer.Business();
        Monitor Monitor = new Monitor();
        public Form1()
        {
            InitializeComponent();
            //ShowFiles(@"C:\");


            ShowLogicalDrives();
            Monitor.CreateWatcher(@"C:\");

            treeViewFileExplorer.Nodes.Clear();

            //MessageBox.Show(Directory.GetCurrentDirectory());
            ImageList images = new ImageList();
            images.Images.Add(Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\Drive-Local-icon.png"));
            images.Images.Add(Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\Без названия (1).jpg"));
            treeViewFileExplorer.ImageList = images;

            foreach (string drives in Directory.GetLogicalDrives())
            {
                TreeNode node = new TreeNode("Local disk (" + drives.Substring(0, drives.Length - 1) + ")");
                node.ImageIndex = 0;

                foreach (DirectoryInfo dirInfo in Business.GetDirectoriesInfo(drives))
                {
                    node.Nodes.Add(dirInfo.Name, dirInfo.Name, 1, 1);
                }

                treeViewFileExplorer.Nodes.Add(node);
            }
            
        }
        private void ShowFiles(string directoryPath)
        {
            fileExplorer.Items.Clear();
            fileExplorer.View = View.Details;
            fileExplorer.Items.AddRange(Business.GetFileRecords(directoryPath).ToArray());
            ShowIcons();

        }

        private void ShowLogicalDrives()
        {
            fileExplorer.Items.Clear();
            fileExplorer.View = View.LargeIcon;
            fileExplorer.Items.AddRange(Business.GetLogicalDiskRecords().ToArray());


            fileExplorer.LargeImageList = Business.GetImageForDrivers();
            foreach(ListViewItem item in fileExplorer.Items)
            {
                item.ImageIndex = 0;
            }
        }

        private void ShowIcons()
        {
            fileExplorer.SmallImageList = Business.GetImagesForFileExplorer(fileExplorer);
            for (int i = 0; i < fileExplorer.Items.Count; ++i) fileExplorer.Items[i].ImageIndex = i;
        }

        private void fileExplorer_DoubleClick(object sender, EventArgs e)
        {
            
            if (fileExplorer.SelectedItems.Count == 0) return;

            if (fileExplorer.SelectedItems[0].Text == "")
            {
                if(new DirectoryInfo(fileExplorer.SelectedItems[0].SubItems[4].Text).Parent == null) ShowLogicalDrives();
                else ShowFiles(new DirectoryInfo(fileExplorer.SelectedItems[0].SubItems[4].Text).Parent.FullName);
            }
            else if (!(fileExplorer.View == View.LargeIcon) && File.GetAttributes(fileExplorer.SelectedItems[0].SubItems[4].Text).HasFlag(FileAttributes.Directory)) ShowFiles(fileExplorer.SelectedItems[0].SubItems[4].Text);
            else if (fileExplorer.View == View.LargeIcon) ShowFiles(fileExplorer.SelectedItems[0].SubItems[0].Text);
            else System.Diagnostics.Process.Start(fileExplorer.SelectedItems[0].SubItems[4].Text);
        }



        private Stopwatch st = new Stopwatch();
        private MouseButtons mb = MouseButtons.None;
        private void fileExplorer_MouseUp(object sender, MouseEventArgs e)
        {
            if (fileExplorer.SelectedItems.Count == 0) return;
            if (e.Button == mb)
            {
                if (st.ElapsedMilliseconds > 500 && e.Button == mb)
                {
                    st.Stop();
                    fileExplorer.SelectedItems[0].ForeColor = Color.Red;
                    fileExplorer.SelectedItems.Clear();
                    contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
                    //MessageBox.Show("1");
                }
                else
                {
                    if (fileExplorer.SelectedItems[0].ForeColor != Color.Red) fileExplorer.SelectedItems[0].ForeColor = Color.Red;
                    else fileExplorer.SelectedItems[0].ForeColor = Color.Black;

                    fileExplorer.SelectedItems.Clear();
                }

                mb = MouseButtons.None;
                st.Reset();
            }
        }

        private void fileExplorer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && !st.IsRunning)
            {
                mb = e.Button;
                st.Start();
            }
        }

        private void treeViewFileExplorer_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes[0].Nodes.Count == 0)
            {
                foreach(TreeNode node in e.Node.Nodes)
                {
                    foreach(DirectoryInfo dirInfo in Business.GetDirectoriesInfo(Business.GetFullPathForNode(node)))
                    {
                        node.Nodes.Add(dirInfo.Name, dirInfo.Name, 1, 1);
                    }
                }
            }
            
            //MessageBox.Show(Business.GetFullPathForNode(e.Node));
            //treeViewFileExplorer.Nodes[0].Nodes.Add("test");
        }


        private void treeViewFileExplorer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeViewFileExplorer.SelectedNode.Parent == null) ShowFiles(Business.GetFullPathForNode(treeViewFileExplorer.SelectedNode) + "\\");
            else ShowFiles(Business.GetFullPathForNode(treeViewFileExplorer.SelectedNode));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
        }
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
}

