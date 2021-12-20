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
    public partial class CreateRenameForm : Form, ICreateRenameFormView
    {
        private FileInfo SelectedFileInfo;
        public FileInfo selectedFileInfo { get => SelectedFileInfo; }

        private MainForm MainForm;
        public MainForm mainForm { get => MainForm; }
        
        public bool isErrorLabelVisible { get => errorlabel.Visible; set => errorlabel.Visible = value; }
        public bool isOkButtonEnabled { get => okButton.Enabled; set => okButton.Enabled = value; }

        public EventHandler TextBox_TextChangedEvent { set => textBox.TextChanged += value; }
        public EventHandler OkButton_ClickEvent { set => okButton.Click += value; }
        public EventHandler ChannelButton_ClickEvent { set => channelButton.Click += value; }
        public EventHandler AfterShowEvent { set => Shown += value; }
        public FormClosedEventHandler FormClosedEvent { set => this.FormClosed += value; }

        public Control FormActiveControl { set => this.ActiveControl = value; }

        public Label ErrorLabel { get => errorlabel; }
        public Label Label { get => label2; }
        public TextBox TextBox { get => textBox; }
        public Button Button { get => okButton; }


        public CreateRenameForm(MainForm mainForm, ListViewItem selectedItem)
        {
            InitializeComponent();
            SelectedFileInfo = new FileInfo(selectedItem.SubItems[5].Text);
            MainForm = mainForm;
        }

    }
}
