using CourseWork_2.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        void AddImageToDb(string ImageKey, Image image);
        ProgramIcons GetImages();
        Image GetImage(string imageName);

    }
}
