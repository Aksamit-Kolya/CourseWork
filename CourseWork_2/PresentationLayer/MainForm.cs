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
        public Form1()
        {
            InitializeComponent();
            ShowFiles(@"C:\");
            treeViewFileExplorer.Nodes.Clear();
            foreach(string drives in Directory.GetLogicalDrives())
            {
                TreeNode node = new TreeNode("Local disk (" + drives.Substring(0, drives.Length - 1) + ")");

                foreach (DirectoryInfo dirInfo in Business.GetDirectoriesInfo(drives))
                {
                    node.Nodes.Add(dirInfo.Name);
                }

                treeViewFileExplorer.Nodes.Add(node);
            }
            /*treeViewFileExplorer.Nodes.Add("Local disk (C:)");
            treeViewFileExplorer.Nodes[0].Nodes.Add("Child node");
            treeViewFileExplorer.Nodes[0].Nodes[0].Nodes.Add("Child2 node");
            treeViewFileExplorer.Nodes[0].ImageIndex = 0;
            treeViewFileExplorer.Nodes.Add("Local disk (D:)");
            treeViewFileExplorer.Nodes[1].ImageIndex = 0;
            treeViewFileExplorer.Nodes.Add("Local disk (E:)");
            treeViewFileExplorer.Nodes[2].ImageIndex = 0;
            ImageList images = new ImageList();
            images.Images.Add(Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\Drive-Local-icon.png"));
            treeViewFileExplorer.ImageList = images;*/
        }
        private void ShowFiles(string directoryPath)
        {
            fileExplorer.Items.Clear();
            fileExplorer.Items.AddRange(Business.GetFileRecords(directoryPath).ToArray());
            ShowIcons();

        }

        private void ShowIcons()
        {
            fileExplorer.SmallImageList = Business.GetImagesForFileExplorer(fileExplorer);
            for (int i = 0; i < fileExplorer.Items.Count; ++i) fileExplorer.Items[i].ImageIndex = i;
        }

        private void fileExplorer_DoubleClick(object sender, EventArgs e)
        {
            
            if (fileExplorer.SelectedItems.Count == 0) return;
            if (fileExplorer.SelectedItems[0].Text == "") ShowFiles(new DirectoryInfo(fileExplorer.SelectedItems[0].SubItems[4].Text).Parent.FullName);
            else if (File.GetAttributes(fileExplorer.SelectedItems[0].SubItems[4].Text).HasFlag(FileAttributes.Directory)) ShowFiles(fileExplorer.SelectedItems[0].SubItems[4].Text);
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
                        node.Nodes.Add(dirInfo.Name);
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

    }
}
