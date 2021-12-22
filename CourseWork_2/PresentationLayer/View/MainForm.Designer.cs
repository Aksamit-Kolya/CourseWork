
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.fileExplorer = new System.Windows.Forms.ListView();
            this.nameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.existsColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lengthColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.athrebutColomn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeViewFileExplorer = new System.Windows.Forms.TreeView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.copyButton = new System.Windows.Forms.Button();
            this.currentPathTextBox = new System.Windows.Forms.TextBox();
            this.moveButton = new System.Windows.Forms.Button();
            this.dleteButton = new System.Windows.Forms.Button();
            this.renameButton = new System.Windows.Forms.Button();
            this.createDirectoryButton = new System.Windows.Forms.Button();
            this.searchRichTextBox = new System.Windows.Forms.RichTextBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileExplorer
            // 
            this.fileExplorer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.existsColumn,
            this.lengthColumn,
            this.dateColumn,
            this.athrebutColomn});
            this.fileExplorer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileExplorer.FullRowSelect = true;
            this.fileExplorer.GridLines = true;
            this.fileExplorer.HideSelection = false;
            this.fileExplorer.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.fileExplorer.Location = new System.Drawing.Point(298, 53);
            this.fileExplorer.Name = "fileExplorer";
            this.fileExplorer.Size = new System.Drawing.Size(856, 574);
            this.fileExplorer.TabIndex = 0;
            this.fileExplorer.UseCompatibleStateImageBehavior = false;
            this.fileExplorer.View = System.Windows.Forms.View.Details;
            this.fileExplorer.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.fileExplorer_ColumnClick);
            this.fileExplorer.DoubleClick += new System.EventHandler(this.fileExplorer_DoubleClick);
            this.fileExplorer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.fileExplorer_MouseClick);
            // 
            // nameColumn
            // 
            this.nameColumn.Tag = "";
            this.nameColumn.Text = "🡅Name";
            this.nameColumn.Width = 450;
            // 
            // existsColumn
            // 
            this.existsColumn.Tag = "";
            this.existsColumn.Text = "FEX";
            this.existsColumn.Width = 44;
            // 
            // lengthColumn
            // 
            this.lengthColumn.Tag = "lengthColumn";
            this.lengthColumn.Text = "Length";
            this.lengthColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.lengthColumn.Width = 101;
            // 
            // dateColumn
            // 
            this.dateColumn.Tag = "dateColumn";
            this.dateColumn.Text = "Date";
            this.dateColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateColumn.Width = 145;
            // 
            // athrebutColomn
            // 
            this.athrebutColomn.Text = "Athrebut";
            this.athrebutColomn.Width = 88;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.copyToolStripMenuItem1,
            this.copyToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(133, 148);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(132, 24);
            this.copyToolStripMenuItem1.Text = "Copy";
            this.copyToolStripMenuItem1.Click += new System.EventHandler(this.copyToolStripMenuItem1_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.copyToolStripMenuItem.Text = "Copy in";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.cutToolStripMenuItem.Text = "Move in";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.moveToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // treeViewFileExplorer
            // 
            this.treeViewFileExplorer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeViewFileExplorer.Location = new System.Drawing.Point(-1, 33);
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
            this.treeViewFileExplorer.Size = new System.Drawing.Size(250, 259);
            this.treeViewFileExplorer.TabIndex = 2;
            this.treeViewFileExplorer.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFileExplorer_AfterExpand);
            this.treeViewFileExplorer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFileExplorer_AfterSelect);
            this.treeViewFileExplorer.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewFileExplorer_NodeMouseClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(21, 80);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(205, 31);
            this.copyButton.TabIndex = 3;
            this.copyButton.Text = "Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // currentPathTextBox
            // 
            this.currentPathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentPathTextBox.Location = new System.Drawing.Point(331, 19);
            this.currentPathTextBox.Name = "currentPathTextBox";
            this.currentPathTextBox.ReadOnly = true;
            this.currentPathTextBox.Size = new System.Drawing.Size(565, 28);
            this.currentPathTextBox.TabIndex = 4;
            // 
            // moveButton
            // 
            this.moveButton.Location = new System.Drawing.Point(21, 122);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(205, 31);
            this.moveButton.TabIndex = 5;
            this.moveButton.Text = "Move";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.moveButton_Click);
            // 
            // dleteButton
            // 
            this.dleteButton.Location = new System.Drawing.Point(21, 166);
            this.dleteButton.Name = "dleteButton";
            this.dleteButton.Size = new System.Drawing.Size(205, 31);
            this.dleteButton.TabIndex = 6;
            this.dleteButton.Text = "Delete";
            this.dleteButton.UseVisualStyleBackColor = true;
            this.dleteButton.Click += new System.EventHandler(this.dleteButton_Click);
            // 
            // renameButton
            // 
            this.renameButton.Location = new System.Drawing.Point(21, 37);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(205, 33);
            this.renameButton.TabIndex = 8;
            this.renameButton.Text = "Rename";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // createDirectoryButton
            // 
            this.createDirectoryButton.Location = new System.Drawing.Point(21, 225);
            this.createDirectoryButton.Name = "createDirectoryButton";
            this.createDirectoryButton.Size = new System.Drawing.Size(205, 31);
            this.createDirectoryButton.TabIndex = 9;
            this.createDirectoryButton.Text = "Create Directory";
            this.createDirectoryButton.UseVisualStyleBackColor = true;
            this.createDirectoryButton.Click += new System.EventHandler(this.createDirectoryButton_Click);
            // 
            // searchRichTextBox
            // 
            this.searchRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchRichTextBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.searchRichTextBox.Location = new System.Drawing.Point(909, 19);
            this.searchRichTextBox.Name = "searchRichTextBox";
            this.searchRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.searchRichTextBox.Size = new System.Drawing.Size(245, 26);
            this.searchRichTextBox.TabIndex = 12;
            this.searchRichTextBox.Text = "";
            this.searchRichTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.searchRichTextBox_KeyUp);
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.refreshButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.refreshButton.FlatAppearance.BorderSize = 0;
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.refreshButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.refreshButton.Image = global::CourseWork_2.Properties.Resources.RefreshButton2;
            this.refreshButton.Location = new System.Drawing.Point(298, 19);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(27, 24);
            this.refreshButton.TabIndex = 7;
            this.refreshButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.treeViewFileExplorer);
            this.panel1.Location = new System.Drawing.Point(21, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 293);
            this.panel1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Folder Tree:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dleteButton);
            this.panel2.Controls.Add(this.createDirectoryButton);
            this.panel2.Controls.Add(this.renameButton);
            this.panel2.Controls.Add(this.copyButton);
            this.panel2.Controls.Add(this.moveButton);
            this.panel2.Location = new System.Drawing.Point(21, 345);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 282);
            this.panel2.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 336);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Operations";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pastToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(105, 28);
            // 
            // pastToolStripMenuItem
            // 
            this.pastToolStripMenuItem.Name = "pastToolStripMenuItem";
            this.pastToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.pastToolStripMenuItem.Text = "Past";
            this.pastToolStripMenuItem.Click += new System.EventHandler(this.pastToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 660);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.searchRichTextBox);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.currentPathTextBox);
            this.Controls.Add(this.fileExplorer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "File Manager";
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.Button createDirectoryButton;
        private System.Windows.Forms.ColumnHeader athrebutColomn;
        private System.Windows.Forms.RichTextBox searchRichTextBox;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem pastToolStripMenuItem;
    }
}

