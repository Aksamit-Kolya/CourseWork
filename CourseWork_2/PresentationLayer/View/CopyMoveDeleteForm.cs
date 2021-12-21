using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork_2.PresentationLayer.View
{
    public partial class CopyMoveDeleteForm : Form, ICopyMoveDeleteFormView
    {
        private MainForm MainForm;
        public MainForm mainForm { get => MainForm;}

        private ListView.SelectedListViewItemCollection SelectedItems;
        public ListView.SelectedListViewItemCollection selectedItems { get => SelectedItems;}

        public Label CountLabel { get => coutnLabel; }
        public Label PercentLabel { get => percentLabel; }
        public Label TextLabel { get => textLabel; }
        public ProgressBar ProgressBar { get => progressBar;}
        public string LabelText { get => Label.Text; set => Label.Text = value; }
        public string FileNameTextBoxText { get => fileNameTextBox.Text; set => fileNameTextBox.Text = value; }

        
        public CopyMoveDeleteForm(MainForm mainForm, ListView.SelectedListViewItemCollection selectedItems)
        {
            InitializeComponent();
            this.MainForm = mainForm;
            this.SelectedItems = selectedItems;
        }

    }
}
