using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork_2
{
    public partial class Form1 : Form
    {

        BusinessLayer.Business Business = new BusinessLayer.Business();
        ImageList imageList;
        public Form1()
        {
            InitializeComponent();
            imageList = new ImageList();
            //imageList.Images.Add(new Bitmap(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\Без названия (1).jpg"));
            //listView1.SmallImageList = imageList;
            ShowFiles(@"C:\");
        }
        private void ShowFiles(string directoryPath)
        {
            listView1.Items.Clear();
            if(directoryPath.Length > 3)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(directoryPath);

                ListViewItem item = new ListViewItem("");
                item.SubItems.Add("");
                item.SubItems.Add("<Directory>");
                item.SubItems.Add(dirInfo.CreationTime.ToString());
                item.SubItems.Add(dirInfo.FullName);
                listView1.Items.Add(item);
            }
            foreach(DirectoryInfo dirInfo in Business.GetDirectoriesInfo(directoryPath))
            {
                ListViewItem item = new ListViewItem(dirInfo.Name);
                item.SubItems.Add("");
                item.SubItems.Add("<Directory>");
                item.SubItems.Add(dirInfo.CreationTime.ToString());
                item.SubItems.Add(dirInfo.FullName);
                //item.ImageIndex = 0;
                listView1.Items.Add(item);
            }

            foreach(FileInfo fileInfo in Business.GetFilesInfo(directoryPath))
            {
                ListViewItem item = new ListViewItem(fileInfo.Name);
                item.SubItems.Add(fileInfo.Extension);
                item.SubItems.Add(fileInfo.Length.ToString());
                item.SubItems.Add(fileInfo.CreationTime.ToString());
                item.SubItems.Add(fileInfo.FullName);
                listView1.Items.Add(item);
            }
            ShowIcons();

        }

        private void ShowIcons()
        {
            imageList.Images.Clear();
            int imageCount;
            if (listView1.Items[0].Text == "")
            {
                imageList.Images.Add(Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\back.png"));
                imageCount = 1;
            }else
            {
                imageCount = 0;
            }
            for (; imageCount < listView1.Items.Count; ++imageCount)
            {
                Image image = null;
                switch (listView1.Items[imageCount].SubItems[1].Text)
                {
                    //Directory.GetParent(Directory.GetCurrentDirectory()).FullName + 
                    case "":
                        image = Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\Без названия (1).jpg");
                        break;
                    case ".exe":
                        image = ServiceLayer.Service.GetSmallFileIcon(listView1.Items[imageCount].SubItems[4].Text).ToBitmap();
                        break;
                    default:
                        image = Image.FromFile(@"C:\Users\Nikolai\source\repos\CourseWork_2\CourseWork_2\ServiceLayer\Images\icons8-file-24.png");
                        break;
                }
                imageList.Images.Add(image);

            }


            listView1.SmallImageList = imageList;
            
            for (int i = 0; i < listView1.Items.Count; ++i) listView1.Items[i].ImageIndex = i;
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems[0].Text == "") ShowFiles(new DirectoryInfo(listView1.SelectedItems[0].SubItems[4].Text).Parent.FullName);
            else if (File.GetAttributes(listView1.SelectedItems[0].SubItems[4].Text).HasFlag(FileAttributes.Directory)) ShowFiles(listView1.SelectedItems[0].SubItems[4].Text);
            else System.Diagnostics.Process.Start(listView1.SelectedItems[0].SubItems[4].Text);
        }
    }
}
