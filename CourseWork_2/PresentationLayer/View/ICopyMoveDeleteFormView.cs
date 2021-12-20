using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace CourseWork_2.PresentationLayer.View
{
    public interface ICopyMoveDeleteFormView
    {
        void Close();

        event FormClosedEventHandler FormClosed;
        event EventHandler Shown;

        MainForm mainForm { get; }
        SelectedListViewItemCollection selectedItems { get; }
        ProgressBar ProgressBar { get; }
        string LabelText { get; set; }
        string FileNameTextBoxText { get; set; }
        bool Visible { get; set; }

    }
}
