using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork_2.PresentationLayer
{
    public class ListViewColumnSorter : IComparer
    {
        private int ColumnToSort;

        private SortOrder OrderOfSort;

        private IComparer ObjectCompare;

        public ListViewColumnSorter()
        {
            ColumnToSort = 0;

            OrderOfSort = SortOrder.None;

            ObjectCompare = new CaseInsensitiveComparer();
        }

        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            if (listviewX.SubItems.Count < 3) return 0;

            if (OrderOfSort == SortOrder.Ascending)
            {
                switch (ColumnToSort)
                {
                    case 0:
                    case 1:
                            compareResult = AscendingSortNameSorteByExtension(listviewX, listviewY);
                            break;
                    case 2:
                        compareResult = AscendingSorteByLength(listviewX, listviewY);
                        break;
                    case 3:
                        compareResult = AscendingSorteByDate(listviewX, listviewY);
                        break;
                    default:
                        compareResult = 0;
                        break;
                }
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                switch (ColumnToSort)
                {
                    case 0:
                    case 1:
                        compareResult = DescendingSortNameSorteByExtension(listviewX, listviewY);
                        break;
                    case 2:
                        compareResult = DescendingSorteByLength(listviewX, listviewY);
                        break;
                    case 3:
                        compareResult = DescendingSorteByDate(listviewX, listviewY);
                        break;
                    default:
                        compareResult = 0;
                        break;
                }
                return compareResult;
            }
            else
            {
                return 0;
            }
        }

        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }

        private int AscendingSortNameSorteByExtension(ListViewItem listviewX, ListViewItem listviewY)
        {
            if (listviewX.SubItems[0].Text == "") return -1;
            else if (listviewY.SubItems[0].Text == "") return 1;
            if (listviewX.SubItems[0].Text.Contains("⭐") ^ listviewY.SubItems[0].Text.Contains("⭐"))
            {
                if (listviewX.SubItems[0].Text.Contains("⭐")) return -1;
                else return 1;
            }
            else if (listviewX.SubItems[0].Text.Contains("⭐") && listviewY.SubItems[0].Text.Contains("⭐"))
            {
                return listviewX.SubItems[0].Text.IndexOf("▶").CompareTo(listviewY.SubItems[0].Text.IndexOf("▶"));
            }
            if (listviewX.SubItems[2].Text == "<Directory>" ^ listviewY.SubItems[2].Text == "<Directory>")
            {
                if (listviewX.SubItems[2].Text == "<Directory>") return -1;
                else return 1;
            }else
            {
                return ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
            }
        }
        private int DescendingSortNameSorteByExtension(ListViewItem listviewX, ListViewItem listviewY)
        {
            if (listviewX.SubItems[0].Text == "") return -1;
            else if (listviewY.SubItems[0].Text == "") return 1;
            if (listviewX.SubItems[0].Text.Contains("⭐") ^ listviewY.SubItems[0].Text.Contains("⭐"))
            {
                if (listviewX.SubItems[0].Text.Contains("⭐")) return -1;
                else return 1;
            }
            else if (listviewX.SubItems[0].Text.Contains("⭐") && listviewY.SubItems[0].Text.Contains("⭐"))
            {
                return listviewX.SubItems[0].Text.IndexOf("▶").CompareTo(listviewY.SubItems[0].Text.IndexOf("▶"));
            }
            if (listviewX.SubItems[2].Text == "<Directory>" ^ listviewY.SubItems[2].Text == "<Directory>")
            {
                if (listviewX.SubItems[2].Text == "<Directory>") return -1;
                else return 1;
            }
            else
            {
                return -ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
            }
        }

        private int AscendingSorteByDate(ListViewItem listviewX, ListViewItem listviewY)
        {
            if (listviewX.SubItems[0].Text == "") return -1;
            else if (listviewY.SubItems[0].Text == "") return 1;
            if (listviewX.SubItems[0].Text.Contains("⭐") ^ listviewY.SubItems[0].Text.Contains("⭐"))
            {
                if (listviewX.SubItems[0].Text.Contains("⭐")) return -1;
                else return 1;
            }
            else if (listviewX.SubItems[0].Text.Contains("⭐") && listviewY.SubItems[0].Text.Contains("⭐"))
            {
                return listviewX.SubItems[0].Text.IndexOf("▶").CompareTo(listviewY.SubItems[0].Text.IndexOf("▶"));
            }
            if (listviewX.SubItems[2].Text == "<Directory>" ^ listviewY.SubItems[2].Text == "<Directory>")
            {
                if (listviewX.SubItems[2].Text == "<Directory>") return -1;
                else return 1;
            }
            else
            {
                return DateTime.Compare(DateTime.ParseExact(listviewX.SubItems[3].Text, "MM-dd-yyyy HH:mm", null),
                    DateTime.ParseExact(listviewY.SubItems[3].Text, "MM-dd-yyyy HH:mm", null));
            }
        }
        private int DescendingSorteByDate(ListViewItem listviewX, ListViewItem listviewY)
        {
            if (listviewX.SubItems[0].Text == "") return -1;
            else if (listviewY.SubItems[0].Text == "") return 1;
            if (listviewX.SubItems[0].Text.Contains("⭐") ^ listviewY.SubItems[0].Text.Contains("⭐"))
            {
                if (listviewX.SubItems[0].Text.Contains("⭐")) return -1;
                else return 1;
            }
            else if (listviewX.SubItems[0].Text.Contains("⭐") && listviewY.SubItems[0].Text.Contains("⭐"))
            {
                return listviewX.SubItems[0].Text.IndexOf("▶").CompareTo(listviewY.SubItems[0].Text.IndexOf("▶"));
            }
            if (listviewX.SubItems[2].Text == "<Directory>" ^ listviewY.SubItems[2].Text == "<Directory>")
            {
                if (listviewX.SubItems[2].Text == "<Directory>") return -1;
                else return 1;
            }
            else
            {
                return -DateTime.Compare(DateTime.ParseExact(listviewX.SubItems[3].Text, "MM-dd-yyyy HH:mm", null), 
                    DateTime.ParseExact(listviewY.SubItems[3].Text, "MM-dd-yyyy HH:mm", null));
            }
        }

        private int AscendingSorteByLength(ListViewItem listviewX, ListViewItem listviewY)
        {
            if (listviewX.SubItems[0].Text == "") return -1;
            else if (listviewY.SubItems[0].Text == "") return 1;
            if (listviewX.SubItems[0].Text.Contains("⭐") ^ listviewY.SubItems[0].Text.Contains("⭐"))
            {
                if (listviewX.SubItems[0].Text.Contains("⭐")) return -1;
                else return 1;
            }
            else if (listviewX.SubItems[0].Text.Contains("⭐") && listviewY.SubItems[0].Text.Contains("⭐"))
            {
                return listviewX.SubItems[0].Text.IndexOf("▶").CompareTo(listviewY.SubItems[0].Text.IndexOf("▶"));
            }
            if (listviewX.SubItems[2].Text == "<Directory>" ^ listviewY.SubItems[2].Text == "<Directory>")
            {
                if (listviewX.SubItems[2].Text == "<Directory>") return -1;
                else return 1;
            }
            else
            {

                string str1 = listviewX.SubItems[ColumnToSort].Text.Replace(" ", "");
                string str2 = listviewY.SubItems[ColumnToSort].Text.Replace(" ", "");
                //MessageBox.Show(str1);
                if (Int64.TryParse(str1, out long a)
                && Int64.TryParse(str2, out long b))
                {
                    return a.CompareTo(b); 
                }
                else
                {
                    return 0;
                }
            }
        }
        private int DescendingSorteByLength(ListViewItem listviewX, ListViewItem listviewY)
        {
            if (listviewX.SubItems[0].Text == "") return -1;
            else if (listviewY.SubItems[0].Text == "") return 1;
            if (listviewX.SubItems[0].Text.Contains("⭐") ^ listviewY.SubItems[0].Text.Contains("⭐"))
            {
                if (listviewX.SubItems[0].Text.Contains("⭐")) return -1;
                else return 1;
            }else if(listviewX.SubItems[0].Text.Contains("⭐") && listviewY.SubItems[0].Text.Contains("⭐"))
            {
                return listviewX.SubItems[0].Text.IndexOf("▶").CompareTo(listviewY.SubItems[0].Text.IndexOf("▶"));
            }
            if (listviewX.SubItems[2].Text == "<Directory>" ^ listviewY.SubItems[2].Text == "<Directory>")
            {
                if (listviewX.SubItems[2].Text == "<Directory>") return -1;
                else return 1;
            }
            else
            {
                if (Int64.TryParse(listviewX.SubItems[ColumnToSort].Text.Replace(" ", ""), out long a)
                && Int64.TryParse(listviewY.SubItems[ColumnToSort].Text.Replace(" ", ""), out long b))
                {
                    return -a.CompareTo(b);
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
