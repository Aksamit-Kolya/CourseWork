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
    public class DbManager : IDbManager
    {
        public List<FileInfo> GetFiles(string directoryPath)
        {
            throw new NotImplementedException();
            
        }

        public ImageList GetImagesForFileExplorer(ListView fileExplorer)
        {
            ImageList imageList = new ImageList();

            int imageCount;
            if (fileExplorer.Items[0].Text == "")
            {
                imageList.Images.Add(Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\back.png"));
                imageCount = 1;
            }
            else
            {
                imageCount = 0;
            }
            for (; imageCount < fileExplorer.Items.Count; ++imageCount)
            {
                Image image = null;
                switch (fileExplorer.Items[imageCount].SubItems[1].Text)
                {
                    //Directory.GetParent(Directory.GetCurrentDirectory()).FullName + 
                    case "":
                        image = Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\Без названия (1).jpg");
                        break;
                    case ".exe":
                        image = ServiceLayer.Service.GetSmallFileIcon(fileExplorer.Items[imageCount].SubItems[4].Text).ToBitmap();
                        break;
                    default:
                        image = Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\icons8-file-24.png");
                        break;
                }
                imageList.Images.Add(image);

            }

            return imageList;
        }
    }
}
