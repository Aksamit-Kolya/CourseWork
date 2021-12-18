using CourseWork_2.BusinessLayer;
using CourseWork_2.PresentationLayer.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace CourseWork_2.PresentationLayer
{
    public partial class CopyForm : Form
    {
        private MainForm MainForm;
        private Business Business;
        private List<ListViewItem> SelectedItems;
        private string CopyPath;

        public string LabelText { get => label1.Text; set => label1.Text = value; }

        public CopyForm(MainForm mainForm, Business business, SelectedListViewItemCollection selectedItems, string copyPath)
        {
            InitializeComponent();
            MainForm = mainForm;
            Business = business;
            SelectedItems = new List<ListViewItem>();

            foreach (ListViewItem item in selectedItems)
            {
                SelectedItems.Add(item);
            }
            //mainForm.Enabled = false;
            CopyPath = copyPath;
        }

        private void CopyForm_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("ABA");
            progressBar1.Maximum = SelectedItems.Count;

            foreach (ListViewItem item in SelectedItems)
            {
                try
                {
                    deletedFileTextBox.Text = item.SubItems[4].Text;
                    if (!Business.Copy(item.SubItems[4].Text, CopyPath)) MessageBox.Show("Can't copy file: " + item.SubItems[4].Text);
                    ++progressBar1.Value;
                    //System.Threading.Thread.Sleep(500);
                    //MessageBox.Show(item.SubItems[4].Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


            this.Close();
        }

        private void CopyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.Enabled = true;
            string currentDirectory = SelectedItems[0].SubItems[4].Text;
            int i = currentDirectory.Length - 1;
            for (; currentDirectory[i] != '\\'; --i) { }
            MainForm.ShowFiles(currentDirectory.Substring(0, i));
        }
    }
}
