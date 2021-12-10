using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_2.DataLayer
{
    interface IDbManager
    {
        List<FileInfo> GetFiles(string directoryPath);
    }
}
