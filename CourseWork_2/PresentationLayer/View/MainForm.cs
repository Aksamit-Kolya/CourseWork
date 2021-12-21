using CourseWork_2.BusinessLayer;
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
        ListViewColumnSorter LVColumnSorter;
        public MainForm(Business business)
        {

            Business = business;
            InitializeComponent();



            ShowLogicalDrives();
            ShowTreeViewFileExplorer();
            //Monitor.CreateWatcher(@"C:\");


            //refreshButton.ImageList = Business.GetImageForRefreshButton(refreshButton.Size);
            //refreshButton.ImageIndex = 0;


            Action action = () =>
            {
                refresh();
            };
            DeviceMonitor = new InsertRemovedDeviceMonitor((o, e) => Invoke(action), (o, e) => Invoke(action));

            LVColumnSorter = new ListViewColumnSorter();
            fileExplorer.ListViewItemSorter = LVColumnSorter;
            LVColumnSorter.Order = SortOrder.Ascending;

            searchRichTextBox.AppendText("🔎", Color.Black);
            searchRichTextBox.AppendText(" Enter a search query", Color.Gainsboro);
            
            searchRichTextBox.GotFocus += (o, e) =>
            {
                if (searchRichTextBox.Text.Replace("🔎", "").Replace("Enter a search query", "").Trim() != "") return;
                searchRichTextBox.Clear();
                searchRichTextBox.AppendText("🔎 ", Color.Black);
                searchRichTextBox.ForeColor = Color.Black;
                
            };
            searchRichTextBox.LostFocus += (o, e) =>
            {
                if (string.IsNullOrWhiteSpace(searchRichTextBox.Text) || searchRichTextBox.Text == "🔎 ")
                {
                    searchRichTextBox.Clear();
                    searchRichTextBox.AppendText("🔎", Color.Black);
                    searchRichTextBox.AppendText(" Enter a search query", Color.Gainsboro);
                }
            };
        }

        public void ShowTreeViewFileExplorer()
        {
            List<string> expandedNodes = Service.collectExpandedNodes(treeViewFileExplorer.Nodes);

            treeViewFileExplorer.Nodes.Clear();
            
            ImageList images = new ImageList();
            images.Images.Add(Business.GetTreeViewImageForDrivers().Images[0]);
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
            try
            {



                List<ListViewItem> items = Business.GetFileRecords(directoryPath);
                fileExplorer.View = View.Details;
                fileExplorer.Items.Clear();
                fileExplorer.Items.AddRange(items.ToArray());
                if(directoryPath.Length < 4) currentPathTextBox.Text = directoryPath + "*";
                else currentPathTextBox.Text = directoryPath + "\\*";
                ShowIcons();
            }
/*            catch(FileNotFoundException e)
            {
                MessageBox.Show(e.Message);
            }*/
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                //MessageBox.Show("You don't have access to this directory!");
                return;
            }
            if (!searchRichTextBox.Focused)
            {
                searchRichTextBox.Clear();
                searchRichTextBox.AppendText("🔎", Color.Black);
                searchRichTextBox.AppendText(" Enter a search query", Color.Gainsboro);
            }
        }
        public void ShowCurrentFiles()
        {
            try
            {
                ShowFiles(fileExplorer.Items[0].SubItems[5].Text);
            }catch(Exception e)
            {

            }
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
            currentPathTextBox.Text = "Computer\\*";
        }

        private void ShowIcons()
        {
            fileExplorer.SmallImageList = Business.GetImagesForFileExplorer(fileExplorer);
            for (int i = 0; i < fileExplorer.Items.Count; ++i) fileExplorer.Items[i].ImageIndex = i;
        }

        private void fileExplorer_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (fileExplorer.SelectedItems.Count == 0) return;

                if (fileExplorer.SelectedItems[0].Text == "")
                {
                    if(new DirectoryInfo(fileExplorer.SelectedItems[0].SubItems[5].Text).Parent == null) ShowLogicalDrives();
                    else ShowFiles(new DirectoryInfo(fileExplorer.SelectedItems[0].SubItems[5].Text).Parent.FullName);
                }
                else if (!(fileExplorer.View == View.LargeIcon) && File.GetAttributes(fileExplorer.SelectedItems[0].SubItems[5].Text).HasFlag(FileAttributes.Directory)) ShowFiles(fileExplorer.SelectedItems[0].SubItems[5].Text);
                else if (fileExplorer.View == View.LargeIcon) ShowFiles(fileExplorer.SelectedItems[0].SubItems[0].Text);
                else System.Diagnostics.Process.Start(fileExplorer.SelectedItems[0].SubItems[5].Text);
            }catch(Exception ex)
            {
                MessageBox.Show("You don't have access to this!");
                return;
            }
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
                    /*                    foreach(DirectoryInfo dirInfo in Business.GetDirectoriesInfo(Service.GetFullPathForNode(node)))
                                        {
                                            node.Nodes.Add(dirInfo.Name, dirInfo.Name, 1, 1);
                                        }*/
                    try
                    {
                        List<string> Directoryes = Business.GetDirectories(Service.GetFullPathForNode(node));
                    
                        foreach(string dirName in Directoryes)
                        {
                            DirectoryInfo directoryInfo = new DirectoryInfo(dirName);
                            node.Nodes.Add(directoryInfo.Name, directoryInfo.Name, 1, 1);
                        }
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }

                }
            }
            
            //MessageBox.Show(Service.GetFullPathForNode(e.Node));
            //treeViewFileExplorer.Nodes[0].Nodes.Add("test");
        }


        private void treeViewFileExplorer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectedDirectoryPath = null;
            try
            {
                if (treeViewFileExplorer.SelectedNode.Parent == null) selectedDirectoryPath = Service.GetFullPathForNode(treeViewFileExplorer.SelectedNode) + "\\";
                else selectedDirectoryPath = Service.GetFullPathForNode(treeViewFileExplorer.SelectedNode);
                ShowFiles(selectedDirectoryPath);

            }catch(Exception ex)
            {
                MessageBox.Show("You don't have accef for it");
                ShowFiles(Directory.GetParent(selectedDirectoryPath).FullName);
            }
        }


        private void fileExplorer_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && fileExplorer.SelectedItems.Count != 0)
            {
                if (fileExplorer.SelectedItems[0].SubItems.Count < 2 || fileExplorer.SelectedItems[0].SubItems[0].Text == "") return;
                if(fileExplorer.SelectedItems.Count > 1)
                {
                    contextMenuStrip1.Items[0].Enabled = false;
                    contextMenuStrip1.Items[1].Enabled = false;
                    contextMenuStrip1.Items[2].Text = "Copy all";
                    contextMenuStrip1.Items[3].Text = "Move all";
                    contextMenuStrip1.Items[4].Text = "Delete all";
                }
                else
                {
                    contextMenuStrip1.Items[0].Enabled = true;
                    contextMenuStrip1.Items[1].Enabled = true;
                    contextMenuStrip1.Items[2].Text = "Copy";
                    contextMenuStrip1.Items[3].Text = "Move";
                    contextMenuStrip1.Items[4].Text = "Delete";
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
            renameForm.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2); 
            this.Enabled = false;
        }
        private void copyButton_Click(object sender, EventArgs e)
        {
            if (fileExplorer.SelectedItems.Count == 0 
                || fileExplorer.SelectedItems[0].Text == ""
                || fileExplorer.SelectedItems[0].SubItems.Count < 3)
            {
                MessageBox.Show("Select file\\directory");
                return;
            }
            if (fileExplorer.SelectedItems.Count > 1)
            {
            
                CopyMoveDeleteForm copyForm = new CopyMoveDeleteForm(this, fileExplorer.SelectedItems);
                CopyPresenter copyPresenter = new CopyPresenter(copyForm);
                copyForm.Show();
                copyForm.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
                //moveForm.Visible = false;
                this.Enabled = false;
            }
            else
            {
                string path = GetPathFromFileDialog();

                if (path != null) Business.CopyWithProgressBar(fileExplorer.SelectedItems[0].SubItems[5].Text, path);
            }
        }
        private void moveButton_Click(object sender, EventArgs e)
        {
            if (fileExplorer.SelectedItems.Count == 0 
                || fileExplorer.SelectedItems[0].Text == ""
                || fileExplorer.SelectedItems[0].SubItems.Count < 3)
            {
                MessageBox.Show("Select file\\directory");
                return;
            }
            if(fileExplorer.SelectedItems.Count > 1)
            {
                CopyMoveDeleteForm moveForm = new CopyMoveDeleteForm(this, fileExplorer.SelectedItems);
                MovePresenter movePresenter = new MovePresenter(moveForm);
                moveForm.Show();
                moveForm.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
                //moveForm.Visible = false;
                this.Enabled = false;
            }
            else
            {
                string path = GetPathFromFileDialog();

                if(path != null) Business.MoveWithProgressBar(fileExplorer.SelectedItems[0].SubItems[5].Text, path);
                refresh();
            }


        }
        private void dleteButton_Click(object sender, EventArgs e)
        {
            if (fileExplorer.SelectedItems.Count == 0 
                || fileExplorer.SelectedItems[0].Text == "" 
                || fileExplorer.SelectedItems[0].SubItems.Count < 3)
            {
                MessageBox.Show("Select file\\directory");
                return;
            }
            string showMessage = "";
            if (fileExplorer.SelectedItems.Count > 1)
            {

                showMessage = "Are you sure you want to delete these files\\directories(" + fileExplorer.SelectedItems.Count + "):";
                foreach (ListViewItem item in fileExplorer.SelectedItems)
                {
                    showMessage += "\n" + item.SubItems[5].Text;
                }

                DialogResult result = MessageBox.Show(
                    showMessage,
                    "Message",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1/*,
                    MessageBoxOptions.DefaultDesktopOnly*/);

                if (result != DialogResult.Yes) return;

                CopyMoveDeleteForm deleteForm = new CopyMoveDeleteForm(this, fileExplorer.SelectedItems);
                DeletePresenter deletePresenter = new DeletePresenter(deleteForm);
                deleteForm.Show();
                deleteForm.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
                //moveForm.Visible = false;
                this.Enabled = false;
            }
            else
            {
                showMessage = "Are you sure you want to delete the file\\directory:" + "\n" + fileExplorer.SelectedItems[0].SubItems[5].Text;
                DialogResult result = MessageBox.Show(
                    showMessage,
                    "Message",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1/*,
                    MessageBoxOptions.DefaultDesktopOnly*/);

                if (result != DialogResult.Yes) return;

                Business.DeleteWithProgressBar(fileExplorer.SelectedItems[0].SubItems[5].Text);
                refresh();
            }
        }
        private void createDirectoryButton_Click(object sender, EventArgs e)
        {
            if(fileExplorer.Items[0].SubItems.Count < 3)
            {
                MessageBox.Show("It is not possible to create a directory here");
                return;
            }
            CreateRenameForm createForm = new CreateRenameForm(this, fileExplorer.Items[0]);
            new CreateDirectoryPresenter(createForm);
            createForm.Show();
            createForm.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            this.Enabled = false;
        }
        
        private string GetPathFromFileDialog()
        {
            string path;
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    path = fbd.SelectedPath;

                    string showMessage = "";
                    showMessage = "Are you sure you want to move the file\\directory:" + "\n" + fileExplorer.SelectedItems[0].SubItems[5].Text;
                    showMessage += "\nin: " + path;

                    DialogResult MessageResult = MessageBox.Show(
                        showMessage,
                        "Message",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1/*,
                        MessageBoxOptions.DefaultDesktopOnly*/);

                    if (MessageResult != DialogResult.Yes) return null;
                }
                else
                {
                    return null;
                }
                return path;
            }
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
            if (currentPathTextBox.Text != "Computer\\*")
            {
                ShowFiles(fileExplorer.Items[0].SubItems[5].Text);
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

        private void fileExplorer_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //LVColumnSorter.SortColumn = e.Column;
            if (e.Column == 4) return;
            if (fileExplorer.Columns[e.Column].Text.Contains("🡅"))
            {
                fileExplorer.Columns[e.Column].Text = fileExplorer.Columns[e.Column].Text.Replace("🡅", "🡇");
                LVColumnSorter.Order = SortOrder.Descending;
                //fileExplorer.Sorting = SortOrder.Descending;
                
                fileExplorer.Sort();
                return;
            }
            else if (fileExplorer.Columns[e.Column].Text.Contains("🡇"))
            {
                fileExplorer.Columns[e.Column].Text = fileExplorer.Columns[e.Column].Text.Replace("🡇", "🡅");
                LVColumnSorter.Order = SortOrder.Ascending;
                //fileExplorer.Sorting = SortOrder.Ascending;
                fileExplorer.Sort();
                return;
            }
            else
            {
                fileExplorer.Columns[LVColumnSorter.SortColumn].Text = 
                    fileExplorer.Columns[LVColumnSorter.SortColumn].Text.Replace("🡅", "").Replace("🡇", "");

                fileExplorer.Columns[e.Column].Text = "🡅" + fileExplorer.Columns[e.Column].Text;
                LVColumnSorter.SortColumn = e.Column;
                LVColumnSorter.Order = SortOrder.Ascending;
                fileExplorer.Sort();
                return;
            }
        }

        private void searchRichTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            String searchWord = searchRichTextBox.Text;
            //if (searchWord.IndexOf("🔎") == -1) searchWord.Trim();
            if (searchWord.IndexOf("🔎 ") == -1) 
            {
                searchRichTextBox.Text = "🔎 ";
                searchRichTextBox.Select(3, 0);
                return;
            }
            if (searchWord.IndexOf("🔎") == 0) searchWord = searchWord.Substring(2).Trim();

            if (string.IsNullOrWhiteSpace(searchWord))
            {
                ShowCurrentFiles();
                return;
            }
            foreach(ListViewItem item in fileExplorer.Items)
            {
                item.SubItems[0].Text = item.SubItems[0].Text.Replace("▶", "").Replace("◀", "").Replace("⭐", "");
                if (item.SubItems[0].Text.IndexOf(searchWord, StringComparison.OrdinalIgnoreCase) < 0) continue;
                item.SubItems[0].Text = "⭐" + item.SubItems[0].Text.Substring(0, item.SubItems[0].Text.IndexOf(searchWord, StringComparison.OrdinalIgnoreCase))
                            + "▶" + item.SubItems[0].Text.Substring(item.SubItems[0].Text.IndexOf(searchWord, StringComparison.OrdinalIgnoreCase), searchWord.Length) + "◀"
                            + item.SubItems[0].Text.Substring(item.SubItems[0].Text.IndexOf(searchWord, StringComparison.OrdinalIgnoreCase) + searchWord.Length);
            }
            fileExplorer.Sort();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileExplorer_DoubleClick(sender, e);
        }

        private void searchRichTextBox_TextChanged(object sender, EventArgs e)
        {
            if (searchRichTextBox.Text.IndexOf("🔎 ") == -1)
            {
                searchRichTextBox.Text = "🔎 ";
                searchRichTextBox.Select(3, 0);
                return;
            }
        }
    }


    
}

