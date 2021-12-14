using CourseWork_2.BusinessLayer;
using CourseWork_2.DataLayer;
using System;
using System.Collections.Generic;
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

            IDbManager dbManager = new DbManager();
            Business business = new Business(dbManager);
            Application.Run(new Form1(business));
        }
    }
}
