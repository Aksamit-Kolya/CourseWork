using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork_2.PresentationLayer.View
{
    public partial class RenameForm : Form
    {
        private FileInfo selectedFileInfo;
        private MainForm MainForm;
        public RenameForm(MainForm mainForm, ListViewItem selectedItem)
        {
            InitializeComponent();
            selectedFileInfo = new FileInfo(selectedItem.SubItems[4].Text);
            MainForm = mainForm;
            textBox.Text = selectedFileInfo.Name;
            this.ActiveControl = textBox;
            
            int i = textBox.Text.Length - 1;
            for (; textBox.Text[i] != '.' && i > 0; --i) ;
            if (i == 0) textBox.SelectAll();
            else textBox.Select(0, i - 1);
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            errorlabel.Visible = false;
            okButton.Enabled = true;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (textBox.Text == selectedFileInfo.Name) Close();
            if (string.IsNullOrEmpty(textBox.Text)) 
            {
                errorlabel.Text = "*The name musb be not null!";
                errorlabel.Visible = true;
                okButton.Enabled = false;
                return;
            }
            foreach(FileInfo fileInfo in new DirectoryInfo(selectedFileInfo.Directory.FullName).EnumerateFiles())
            {
                if(fileInfo.Name == textBox.Text)
                {
                    errorlabel.Text = "*This name is already used!";
                    errorlabel.Visible = true;
                    okButton.Enabled = false;
                    return;
                }
            }

            foreach (DirectoryInfo dirInfo in new DirectoryInfo(selectedFileInfo.Directory.FullName).EnumerateDirectories())
            {
                if (dirInfo.Name == textBox.Text)
                {
                    errorlabel.Text = "*This name is already used!";
                    errorlabel.Visible = true;
                    okButton.Enabled = false;
                    return;
                }
            }

            if (!ServiceLayer.Service.IsPathValidRootedLocal("C:\\" + textBox.Name))
            {
                errorlabel.Text = "*The name is incorrect!";
                errorlabel.Visible = true;
                okButton.Enabled = false;
                return;
            }

            selectedFileInfo.Rename(textBox.Text);
            this.Close();
        }

        private void channelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RenameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.Enabled = true;
            MainForm.refresh();
        }
    }
}
