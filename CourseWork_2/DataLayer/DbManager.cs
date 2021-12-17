using CourseWork_2.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CourseWork_2.DataLayer
{
    public class DbManager : IDbManager
    {
        ProgramIcons ProgramIcons;
        XmlDocument xDoc;
        private string XmlDocumentPath = @"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\Properties\Images.xml";
        private static DbManager Instance;
        public static DbManager GetInstance()
        {
            if (Instance == null)
            {
                Instance = new DbManager();
            }
            return Instance;
        }

        private DbManager()
        {
            ProgramIcons = new ProgramIcons();
            
            xDoc = new XmlDocument();
            xDoc.Load(XmlDocumentPath);


            foreach(XmlNode Image in xDoc.DocumentElement.ChildNodes[0].ChildNodes)
            {
                string imageName = Image.Attributes.GetNamedItem("name").Value;
                ProgramIcons.AddIcons(imageName, GetImageFromDb(imageName));
            }
        }

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
                //imageList.Images.Add(Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\back.png"));
                imageList.Images.Add(ProgramIcons.GetIconByName("backImage"));
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
                        image = ProgramIcons.GetIconByName("drictoryImage");
                        //image = Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\Без названия (1).jpg");
                        break;
                    case ".exe":
                        image = ServiceLayer.Service.GetSmallFileIcon(fileExplorer.Items[imageCount].SubItems[4].Text).ToBitmap();
                        break;
                    default:
                        //image = Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\icons8-file-24.png");
                        image = ProgramIcons.GetIconByName("unknownFileImage");
                        break;
                }
                imageList.Images.Add(image);

            }

            return imageList;
        }

        public void AddImageToDb(string ImageKey, Image image)
        {
            byte[] bytes;

            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();

                formatter.Serialize(ms, image);
                bytes = ms.ToArray();
            }
            string str = "";
            for (int i = 0; i < bytes.Length; ++i)
            {
                str += (char)bytes[i];
            }

            XmlElement XmlImage = xDoc.CreateElement("Image");
            
            XmlAttribute XmlImageAttribute = xDoc.CreateAttribute("name");
            
            XmlImageAttribute.Value = ImageKey;
            XmlImage.Attributes.Append(XmlImageAttribute);
            
            XmlImage.InnerText = str;
            
            xDoc.DocumentElement.ChildNodes[0].AppendChild(XmlImage);
            
            xDoc.Save(XmlDocumentPath);
        }
        public ProgramIcons GetImages()
        {
            return ProgramIcons;
        }

        private Image GetImageFromDb(string imageName)
        {
            foreach (XmlNode Image in xDoc.DocumentElement.ChildNodes[0].ChildNodes)
            {
                if(Image.Attributes.GetNamedItem("name").Value == imageName)
                {
                    string bytesStr = Image.InnerText;
                    
                    byte[] bytes = new byte[bytesStr.Length];

                    for (int i = 0; i < bytes.Length; ++i)
                    {
                        bytes[i] = (byte)(int)bytesStr[i];
                    }

                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        BinaryFormatter formattter = new BinaryFormatter();
                        Image image = (Image)formattter.Deserialize(ms);
                        //ProgramIcons.AddIcons(imageName, image);

                        return image;
                    }
                }
            }
            throw new FileNotFoundException("Image with name: " + imageName + "is not in DB");
        }
        public Image GetImage(string imageName)
        {
            return ProgramIcons.GetIconByName(imageName);
        }
    }
}
