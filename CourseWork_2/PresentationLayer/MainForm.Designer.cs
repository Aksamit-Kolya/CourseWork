
namespace CourseWork_2
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("testFile");
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("abacaba");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("aba", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("test", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("abacaba");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("aba", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("aba");
            this.fileExplorer = new System.Windows.Forms.ListView();
            this.nameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.existsColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lengthColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeViewFileExplorer = new System.Windows.Forms.TreeView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.copyButton = new System.Windows.Forms.Button();
            this.currentPathTextBox = new System.Windows.Forms.TextBox();
            this.moveButton = new System.Windows.Forms.Button();
            this.dleteButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileExplorer
            // 
            this.fileExplorer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.existsColumn,
            this.lengthColumn,
            this.dateColumn});
            this.fileExplorer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileExplorer.FullRowSelect = true;
            this.fileExplorer.GridLines = true;
            this.fileExplorer.HideSelection = false;
            this.fileExplorer.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.fileExplorer.Location = new System.Drawing.Point(310, 64);
            this.fileExplorer.Name = "fileExplorer";
            this.fileExplorer.Size = new System.Drawing.Size(856, 536);
            this.fileExplorer.TabIndex = 0;
            this.fileExplorer.UseCompatibleStateImageBehavior = false;
            this.fileExplorer.View = System.Windows.Forms.View.Details;
            this.fileExplorer.DoubleClick += new System.EventHandler(this.fileExplorer_DoubleClick);
            this.fileExplorer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.fileExplorer_MouseClick);
            // 
            // nameColumn
            // 
            this.nameColumn.Tag = "";
            this.nameColumn.Text = "Name";
            this.nameColumn.Width = 481;
            // 
            // existsColumn
            // 
            this.existsColumn.Tag = "";
            this.existsColumn.Text = "Exists";
            this.existsColumn.Width = 87;
            // 
            // lengthColumn
            // 
            this.lengthColumn.Tag = "lengthColumn";
            this.lengthColumn.Text = "Length";
            this.lengthColumn.Width = 102;
            // 
            // dateColumn
            // 
            this.dateColumn.Tag = "dateColumn";
            this.dateColumn.Text = "Date";
            this.dateColumn.Width = 176;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.cutToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 76);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.cutToolStripMenuItem.Text = "Move";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.moveToolStripMenuItem_Click);
            // 
            // treeViewFileExplorer
            // 
            this.treeViewFileExplorer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeViewFileExplorer.Location = new System.Drawing.Point(29, 64);
            this.treeViewFileExplorer.Name = "treeViewFileExplorer";
            treeNode1.Name = "Node6";
            treeNode1.Text = "abacaba";
            treeNode2.Name = "Node4";
            treeNode2.Text = "aba";
            treeNode3.Name = "Node1";
            treeNode3.Text = "test";
            treeNode4.Name = "Node5";
            treeNode4.Text = "abacaba";
            treeNode5.Name = "Node2";
            treeNode5.Text = "aba";
            treeNode6.Name = "Node3";
            treeNode6.Text = "aba";
            this.treeViewFileExplorer.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode5,
            treeNode6});
            this.treeViewFileExplorer.Size = new System.Drawing.Size(249, 369);
            this.treeViewFileExplorer.TabIndex = 2;
            this.treeViewFileExplorer.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFileExplorer_AfterExpand);
            this.treeViewFileExplorer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFileExplorer_AfterSelect);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(29, 491);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(249, 31);
            this.copyButton.TabIndex = 3;
            this.copyButton.Text = "Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // currentPathTextBox
            // 
            this.currentPathTextBox.Location = new System.Drawing.Point(341, 36);
            this.currentPathTextBox.Name = "currentPathTextBox";
            this.currentPathTextBox.Size = new System.Drawing.Size(825, 22);
            this.currentPathTextBox.TabIndex = 4;
            // 
            // moveButton
            // 
            this.moveButton.Location = new System.Drawing.Point(29, 528);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(249, 31);
            this.moveButton.TabIndex = 5;
            this.moveButton.Text = "Move";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.moveButton_Click);
            // 
            // dleteButton
            // 
            this.dleteButton.Location = new System.Drawing.Point(29, 565);
            this.dleteButton.Name = "dleteButton";
            this.dleteButton.Size = new System.Drawing.Size(249, 35);
            this.dleteButton.TabIndex = 6;
            this.dleteButton.Text = "Delete";
            this.dleteButton.UseVisualStyleBackColor = true;
            this.dleteButton.Click += new System.EventHandler(this.dleteButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Image = global::CourseWork_2.Properties.Resources.back;
            this.refreshButton.Location = new System.Drawing.Point(310, 36);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(25, 22);
            this.refreshButton.TabIndex = 7;
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 634);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.dleteButton);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.currentPathTextBox);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.treeViewFileExplorer);
            this.Controls.Add(this.fileExplorer);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView fileExplorer;
        private System.Windows.Forms.ColumnHeader nameColumn;
        private System.Windows.Forms.ColumnHeader existsColumn;
        private System.Windows.Forms.ColumnHeader lengthColumn;
        private System.Windows.Forms.ColumnHeader dateColumn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.TreeView treeViewFileExplorer;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.TextBox currentPathTextBox;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.Button dleteButton;
        private System.Windows.Forms.Button refreshButton;
    }
}

