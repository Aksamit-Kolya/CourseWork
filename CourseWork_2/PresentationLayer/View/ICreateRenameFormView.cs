using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork_2.PresentationLayer.View
{
    interface ICreateRenameFormView
    {
        EventHandler TextBox_TextChangedEvent { set; }
        EventHandler OkButton_ClickEvent { set; }
        EventHandler ChannelButton_ClickEvent { set; }
        EventHandler AfterShowEvent { set; }
        FormClosedEventHandler FormClosedEvent { set; }

        Control FormActiveControl { set; }

        FileInfo selectedFileInfo { get; }
        MainForm mainForm { get; }
        bool isErrorLabelVisible { get; set; }
        bool isOkButtonEnabled { get; set; }


        Label ErrorLabel { get; }
        Label Label { get; }
        TextBox TextBox { get; }
        Button Button { get; }
        void Close();
    }
}
