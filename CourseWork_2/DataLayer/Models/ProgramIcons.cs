using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_2.DataLayer.Models
{
    public class ProgramIcons
    {
        private Dictionary<string, Image> Icons;

        
        public ProgramIcons()
        {
            Icons = new Dictionary<string, Image>();
        }
        public ProgramIcons(Dictionary<string, Image> images)
        {
            Icons = images;
        }
        
        public void AddIcons(string name, Image image)
        {
            Icons.Add(name, image);
        }
        public Image GetIconByName(string name)
        {
            return Icons[name];
        }
    }
}
