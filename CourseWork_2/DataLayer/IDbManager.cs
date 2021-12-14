using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork_2.DataLayer
{
    public interface IDbManager
    {
        List<FileInfo> GetFiles(string directoryPath);
        ImageList GetImagesForFileExplorer(ListView fileExplorer);
    }
}
