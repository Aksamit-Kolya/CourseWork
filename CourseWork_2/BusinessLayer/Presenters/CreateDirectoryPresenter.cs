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
    class CreateDirectoryPresenter
    {
        ICreateRenameFormView Form;
        public CreateDirectoryPresenter(ICreateRenameFormView form)
        {
            Form = form;
            Form.Label.Text = "Name";
            Form.Button.Text = "Create";

            Form.TextBox_TextChangedEvent = textBox_TextChanged;
            Form.OkButton_ClickEvent = okButton_Click;
            Form.ChannelButton_ClickEvent = channelButton_Click;
            Form.FormClosedEvent = RenameForm_FormClosed;
            Form.AfterShowEvent = CreateForm_Shown;
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            Form.isErrorLabelVisible = false;
            Form.isOkButtonEnabled = true;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            //if (Form.TextBox.Text == Form.selectedFileInfo.Name) Form.Close();
            if (string.IsNullOrEmpty(Form.TextBox.Text))
            {
                Form.ErrorLabel.Text = "*The name musb be not null!";
                Form.isErrorLabelVisible = true;
                Form.isOkButtonEnabled = false;
                return;
            }

            foreach (FileInfo fileInfo in new DirectoryInfo(Form.selectedFileInfo.FullName).EnumerateFiles())
            {
                if (fileInfo.Name == Form.TextBox.Text)
                {
                    Form.ErrorLabel.Text = "*This name is already used!";
                    Form.ErrorLabel.Visible = true;
                    Form.isOkButtonEnabled = false;
                    return;
                }
            }

            foreach (DirectoryInfo dirInfo in new DirectoryInfo(Form.selectedFileInfo.FullName).EnumerateDirectories())
            {
                if (dirInfo.Name == Form.TextBox.Text)
                {
                    Form.ErrorLabel.Text = "*This name is already used!";
                    Form.ErrorLabel.Visible = true;
                    Form.isOkButtonEnabled = false;
                    return;
                }
            }
            string fileName = Form.selectedFileInfo.FullName + "\\" + Form.TextBox.Text;

            if (!ServiceLayer.Service.IsPathValidRootedLocal(fileName))
            {
                Form.ErrorLabel.Text = "*The name is incorrect!";
                Form.ErrorLabel.Visible = true;
                Form.isOkButtonEnabled = false;
                return;
            }

            Business.CreateDirectory(fileName);
            //Form.selectedFileInfo.Rename(Form.TextBox.Text);
            Form.Close();
        }

        private void channelButton_Click(object sender, EventArgs e)
        {
            Form.Close();
        }

        private void RenameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form.mainForm.Enabled = true;
            Form.mainForm.refresh();
        }

        private void CreateForm_Shown(object sender, EventArgs e)
        {
            Form.TextBox.Text = "Новая папка";
            Form.FormActiveControl = Form.TextBox;

            Form.TextBox.SelectAll();
        }
    }
}
