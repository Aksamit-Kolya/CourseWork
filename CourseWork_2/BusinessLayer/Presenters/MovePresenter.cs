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
    class MovePresenter
    {
        private ICopyMoveDeleteFormView Form;
        public MovePresenter(ICopyMoveDeleteFormView Form)
        {
            this.Form = Form;

            Form.LabelText = "Move";
            Form.TextLabel.Text = "Number of moved files:";
            Form.CountLabel.Text = "0/" + Form.selectedItems.Count;
            Form.FileNameTextBoxText = Form.selectedItems[0].SubItems[5].Text;
            Form.Shown += MoveForm_Shown;
            Form.FormClosed += MoveForm_FormClosed;

        }

        private void MoveForm_Shown(object sender, EventArgs e)
        {
            string path;
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    path = fbd.SelectedPath;

                    string showMessage = "";
                    if (Form.selectedItems.Count > 1)
                    {
                        showMessage = "Are you sure you want to move these files\\directories(" + Form.selectedItems.Count + "):";
                        foreach (ListViewItem item in Form.selectedItems)
                        {
                            showMessage += "\n" + item.SubItems[5].Text;
                        }
                    }
                    else
                    {
                        showMessage = "Are you sure you want to move the file\\directory:" + "\n" + Form.selectedItems[0].SubItems[5].Text;

                    }
                    showMessage += "\nin: " + path;

                    /*DialogResult MessageResult = MessageBox.Show(
                        showMessage,
                        "Message",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1*//*,
                        MessageBoxOptions.DefaultDesktopOnly*//*);

                    if (MessageResult != DialogResult.Yes) return;*/
                }
                else
                {
                    Form.Close();
                    return;
                }


                //MessageBox.Show("ABA");
                Form.ProgressBar.Maximum = Form.selectedItems.Count;

                foreach (ListViewItem item in Form.selectedItems)
                {
                    try
                    {
                        Form.FileNameTextBoxText = item.SubItems[5].Text;
                        Business.MoveWithProgressBar(item.SubItems[5].Text, path);
                        ++Form.ProgressBar.Value;
                        Form.PercentLabel.Text = ((int)(1.0 * Form.ProgressBar.Value / Form.ProgressBar.Maximum)).ToString() + "%";
                        Form.CountLabel.Text = Form.ProgressBar.Value + "/" + Form.ProgressBar.Maximum;
                        //if (!Business.Move(item.SubItems[5].Text, path)) MessageBox.Show("Can't move file: " + item.SubItems[5].Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }


                Form.Close();
            }
        }

        private void MoveForm_FormClosed(object sender, FormClosedEventArgs e)
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
