using CourseWork_2.BusinessLayer;
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
    public partial class DeleteForm : Form
    {
        private MainForm MainForm;
        private Business Business;
        private List<ListViewItem> SelectedItems;
        public DeleteForm(MainForm mainForm, Business business, SelectedListViewItemCollection selectedItems)
        {
            InitializeComponent();
            MainForm = mainForm;
            Business = business;
            SelectedItems = new List<ListViewItem>();

            foreach(ListViewItem item in selectedItems)
            {
                SelectedItems.Add(item);
            }
            //mainForm.Enabled = false;
        }

        private void DeleteForm_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("ABA");
            progressBar1.Maximum = SelectedItems.Count;

            foreach(ListViewItem item in SelectedItems)
            {
                try
                {
                    deletedFileTextBox.Text = item.SubItems[4].Text;
                    if (!Business.Delete(item.SubItems[4].Text)) MessageBox.Show("Can't delete file: " + item.SubItems[4].Text);
                    ++progressBar1.Value;
                    //System.Threading.Thread.Sleep(500);
                    //MessageBox.Show(item.SubItems[4].Text);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            this.Close();
        }

        private void DeleteForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            string currentDirectory = SelectedItems[0].SubItems[4].Text;
            int i = currentDirectory.Length - 1;
            for (; currentDirectory[i] != '\\'; --i) { }
            MainForm.ShowFiles(currentDirectory.Substring(0, i));
            MainForm.Enabled = true;
            //MainForm.Show();
        }
    }
}
