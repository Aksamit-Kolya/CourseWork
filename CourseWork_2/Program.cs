using CourseWork_2.BusinessLayer;
using CourseWork_2.DataLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork_2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IDbManager dbManager = DbManager.GetInstance();
            //dbManager.AddImageToDb("backImage", Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\back.png"));
            //dbManager.AddImageToDb("drictoryImage", Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\Без названия (1).jpg"));
            //dbManager.AddImageToDb("unknownFileImage", Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\icons8-file-24.png"));
            //dbManager.AddImageToDb("driveImage", Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\Drive-Local-icon.png"));
            //dbManager.AddImageToDb("refreshButtonImage2", Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\icons8-refresh-32 (1).png"));
            //dbManager.AddImageToDb("newDriveImage", Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\newImageForDrive.png"));
            //dbManager.AddImageToDb("drictoryImage2", Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\RefreshButton2.png"));


            /*dbManager.AddImageToDb("videoFileImage", 
                Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\movie-symbol-of-video-camera_icon-icons.com_72981.png"));
            dbManager.AddImageToDb("photoFileImage",
               Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\photo-camera-1_icon-icons.com_63898.png"));
            
            dbManager.AddImageToDb("musicFileImage",
                Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\3293588.png"));
            dbManager.AddImageToDb("textFileImage",
                Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\DocumentEdit_40924.png"));
            dbManager.AddImageToDb("pictureFileImage2",
               Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\picture_image_icon-icons.com_72393.png"));
            */
            //dbManager.AddImageToDb("computerImage", Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\Computer.jfif"));
            //return;
            


            Business business = new Business(dbManager);

        Foo:
            try
            {
                Application.Run(new MainForm(business));
            }
            catch (Exception e)
            {
                goto Foo;
            }
        }
    }
}
