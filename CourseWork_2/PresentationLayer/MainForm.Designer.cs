﻿
namespace CourseWork_2
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.fileExplorer.Location = new System.Drawing.Point(310, 109);
            this.fileExplorer.Name = "fileExplorer";
            this.fileExplorer.Size = new System.Drawing.Size(743, 467);
            this.fileExplorer.TabIndex = 0;
            this.fileExplorer.UseCompatibleStateImageBehavior = false;
            this.fileExplorer.View = System.Windows.Forms.View.Details;
            this.fileExplorer.DoubleClick += new System.EventHandler(this.fileExplorer_DoubleClick);
            this.fileExplorer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fileExplorer_MouseDown);
            this.fileExplorer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.fileExplorer_MouseUp);
            // 
            // nameColumn
            // 
            this.nameColumn.Tag = "";
            this.nameColumn.Text = "Name";
            this.nameColumn.Width = 416;
            // 
            // existsColumn
            // 
            this.existsColumn.Tag = "";
            this.existsColumn.Text = "Exists";
            this.existsColumn.Width = 65;
            // 
            // lengthColumn
            // 
            this.lengthColumn.Tag = "lengthColumn";
            this.lengthColumn.Text = "Length";
            this.lengthColumn.Width = 111;
            // 
            // dateColumn
            // 
            this.dateColumn.Tag = "dateColumn";
            this.dateColumn.Text = "Date";
            this.dateColumn.Width = 143;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.cutToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(121, 76);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.copyToolStripMenuItem.Text = "copy";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.deleteToolStripMenuItem.Text = "delete";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.cutToolStripMenuItem.Text = "cut";
            // 
            // treeViewFileExplorer
            // 
            this.treeViewFileExplorer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeViewFileExplorer.Location = new System.Drawing.Point(29, 81);
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
            this.treeViewFileExplorer.Size = new System.Drawing.Size(275, 495);
            this.treeViewFileExplorer.TabIndex = 2;
            this.treeViewFileExplorer.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFileExplorer_AfterExpand);
            this.treeViewFileExplorer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFileExplorer_AfterSelect);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(105, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(311, 81);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(742, 22);
            this.textBox1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 713);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeViewFileExplorer);
            this.Controls.Add(this.fileExplorer);
            this.Name = "Form1";
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

