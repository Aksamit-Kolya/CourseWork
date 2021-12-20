﻿using CourseWork_2.BusinessLayer;
using CourseWork_2.BusinessLayer.Presenters;
using CourseWork_2.PresentationLayer;
using CourseWork_2.PresentationLayer.View;
using CourseWork_2.ServiceLayer;
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
    public partial class MainForm : Form
    {

        Business Business;
        Monitor Monitor = new Monitor();
        InsertRemovedDeviceMonitor DeviceMonitor;
        public MainForm(Business business)
        {

            Business = business;
            InitializeComponent();



            ShowLogicalDrives();
            //Monitor.CreateWatcher(@"C:\");


            refreshButton.ImageList = Business.GetImageForRefreshButton();
            refreshButton.ImageIndex = 0;

            ShowTreeViewFileExplorer();

            Action action = () =>
            {
                refresh();
            };
            DeviceMonitor = new InsertRemovedDeviceMonitor((o, e) => Invoke(action), (o, e) => Invoke(action));
            
        }
        public void ShowTreeViewFileExplorer()
        {
            List<string> expandedNodes = Service.collectExpandedNodes(treeViewFileExplorer.Nodes);

            treeViewFileExplorer.Nodes.Clear();
            
            ImageList images = new ImageList();
            images.Images.Add(Business.GetImageForDrivers().Images[0]);
            images.Images.Add(Business.GetImageForDirectory());
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

            foreach (string expandedNodeName in expandedNodes)
            {
                Service.expandNodePath(Service.FindNodeByName(treeViewFileExplorer.Nodes, expandedNodeName));
            }
        }

        public void ShowFiles(string directoryPath)
        {
            currentPathTextBox.Text = directoryPath + "\\*";

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

            currentPathTextBox.Clear();
            currentPathTextBox.Text = "computer\\*";
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
                    foreach(DirectoryInfo dirInfo in Business.GetDirectoriesInfo(Service.GetFullPathForNode(node)))
                    {
                        node.Nodes.Add(dirInfo.Name, dirInfo.Name, 1, 1);
                    }
                }
            }
            
            //MessageBox.Show(Service.GetFullPathForNode(e.Node));
            //treeViewFileExplorer.Nodes[0].Nodes.Add("test");
        }


        private void treeViewFileExplorer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeViewFileExplorer.SelectedNode.Parent == null) ShowFiles(Service.GetFullPathForNode(treeViewFileExplorer.SelectedNode) + "\\");
            else ShowFiles(Service.GetFullPathForNode(treeViewFileExplorer.SelectedNode));
        }


        private void fileExplorer_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && fileExplorer.SelectedItems.Count != 0)
            {
                if (fileExplorer.SelectedItems[0].SubItems.Count < 2 || fileExplorer.SelectedItems[0].SubItems[0].Text == "") return;
                if(fileExplorer.SelectedItems.Count > 2)
                {
                    contextMenuStrip1.Items[0].Enabled = false;
                    contextMenuStrip1.Items[1].Text = "Copy all";
                    contextMenuStrip1.Items[2].Text = "Delete all";
                    contextMenuStrip1.Items[3].Text = "Move all";
                }
                else
                {
                    contextMenuStrip1.Items[0].Enabled = true;
                    contextMenuStrip1.Items[1].Text = "Copy";
                    contextMenuStrip1.Items[2].Text = "Delete";
                    contextMenuStrip1.Items[3].Text = "Move";
                }
                contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
            }
        }

        

        private void renameButton_Click(object sender, EventArgs e)
        {
            if(fileExplorer.SelectedItems.Count > 1)
            {
                MessageBox.Show("More than one file selected");
                return;
            }
            if (fileExplorer.SelectedItems[0].SubItems.Count < 2 || fileExplorer.SelectedItems[0].SubItems[0].Text == "") return;
            CreateRenameForm renameForm = new CreateRenameForm(this, fileExplorer.SelectedItems[0]);
            new RenamePresenter(renameForm);
            renameForm.Show();
            this.Enabled = false;
        }
        
        private void copyButton_Click(object sender, EventArgs e)
        {
            if (fileExplorer.SelectedItems.Count == 0 || fileExplorer.SelectedItems[0].Text == "")
            {
                MessageBox.Show("Select file\\directory");
                return;
            }

            CopyMoveDeleteForm copyForm = new CopyMoveDeleteForm(this, fileExplorer.SelectedItems);
            CopyPresenter copyPresenter = new CopyPresenter(copyForm);
            copyForm.Show() ;
            copyForm.Visible = false;
            //this.Enabled = false;
        }

        private void moveButton_Click(object sender, EventArgs e)
        {
            if (fileExplorer.SelectedItems.Count == 0 || fileExplorer.SelectedItems[0].Text == "")
            {
                MessageBox.Show("Select file\\directory");
                return;
            }

            CopyMoveDeleteForm moveForm = new CopyMoveDeleteForm(this, fileExplorer.SelectedItems);
            MovePresenter movePresenter = new MovePresenter(moveForm);
            moveForm.Show();
            //this.Enabled = false;
            moveForm.Visible = false;
        }

        private void dleteButton_Click(object sender, EventArgs e)
        {
            if (fileExplorer.SelectedItems.Count == 0 || fileExplorer.SelectedItems[0].Text == "")
            {
                MessageBox.Show("Select file\\directory");
                return;
            }

            CopyMoveDeleteForm deleteForm = new CopyMoveDeleteForm(this, fileExplorer.SelectedItems);
            DeletePresenter deletePresenter = new DeletePresenter(deleteForm);
            deleteForm.Show();
            //this.Enabled = false;
            deleteForm.Visible = false;

        }


        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyButton_Click(sender, e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dleteButton_Click(sender, e);
        }

        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            moveButton_Click(sender, e);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            refresh();
        }

        public  void refresh()
        {
            if (currentPathTextBox.Text != "computer\\*")
            {
                ShowFiles(fileExplorer.Items[0].SubItems[4].Text);
            }
            else
            {
                ShowLogicalDrives();
            }
            ShowTreeViewFileExplorer();
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            renameButton_Click(sender, e);
        }

        public ListView GetFileExplirer()
        {
            return fileExplorer;
        }

        private void createDirectoryButton_Click(object sender, EventArgs e)
        {
            CreateRenameForm createForm = new CreateRenameForm(this, fileExplorer.Items[0]);
            new CreateDirectoryPresenter(createForm);
            createForm.Show();
            this.Enabled = false;
        }
    }


    
}
