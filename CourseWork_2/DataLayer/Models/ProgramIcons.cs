using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        
        public void AddIcons(string bytes_str)
        {
            byte[] bytes = new byte[bytes_str.Length];

            for(int i = 0; i < bytes.Length; ++i)
            {
                bytes[i] = (byte)(int)bytes_str[i];
            }
            
        }
    }
}
