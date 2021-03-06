using CourseWork_2.PresentationLayer.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork_2.BusinessLayer.Presenters
{
    class DeletePresenter
    {
        private ICopyMoveDeleteFormView Form;
        public DeletePresenter(ICopyMoveDeleteFormView Form)
        {
            this.Form = Form;

            Form.LabelText = "Delete";
            Form.TextLabel.Text = "Number of deleted files:";
            Form.CountLabel.Text = "0/" + Form.selectedItems.Count;
            Form.FileNameTextBoxText = Form.selectedItems[0].SubItems[5].Text;
            Form.Shown += DeleteForm_Shown;
            Form.FormClosed += DeleteForm_FormClosed;

        }

        private void DeleteForm_Shown(object sender, EventArgs e)
        {
            string showMessage = "";
            if (Form.selectedItems.Count > 1)
            {
                showMessage = "Are you sure you want to delete these files\\directories(" + Form.selectedItems.Count + "):";
                foreach (ListViewItem item in Form.selectedItems)
                {
                    showMessage += "\n" + item.SubItems[5].Text;
                }
            }
            else
            {
                showMessage = "Are you sure you want to delete the file\\directory:" + "\n" + Form.selectedItems[0].SubItems[5].Text;

            }
            Form.Visible = true;
/*            DialogResult result = MessageBox.Show(
                showMessage,
                "Message",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1*//*,
                MessageBoxOptions.DefaultDesktopOnly*//*);

            if (result != DialogResult.Yes) return;*/


            //MessageBox.Show("ABA");
            Form.ProgressBar.Maximum = Form.selectedItems.Count;

                foreach (ListViewItem item in Form.selectedItems)
                {
                    try
                    {
                        Form.FileNameTextBoxText = item.SubItems[5].Text;
                        Business.DeleteWithProgressBar(item.SubItems[5].Text);
                        ++Form.ProgressBar.Value;
                        Form.PercentLabel.Text = ((int)(1.0 * Form.ProgressBar.Value / Form.ProgressBar.Maximum)).ToString() + "%";
                        Form.CountLabel.Text = Form.ProgressBar.Value + "/" + Form.ProgressBar.Maximum;
                    //if (!Business.Delete(item.SubItems[5].Text)) MessageBox.Show("Can't delete file: " + item.SubItems[5].Text);
                }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }


                Form.Close();
            }

        private void DeleteForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form.mainForm.Enabled = true;
            string currentDirectory = Form.selectedItems[0].SubItems[5].Text;
            int i = currentDirectory.Length - 1;
            for (; currentDirectory[i] != '\\'; --i) { }
            if (i < 3) Form.mainForm.ShowFiles(currentDirectory.Substring(0, i) + "\\");
            else Form.mainForm.ShowFiles(currentDirectory.Substring(0, i));

            Form.mainForm.ShowTreeViewFileExplorer();
        }
    }
}
