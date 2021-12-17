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
            

            Business business = new Business(dbManager);
            Application.Run(new MainForm(business));
        }
    }
}
