using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication3.ResourcesAndManpower
{
    /// <summary>
    /// Interaction logic for PageOrgnization.xaml
    /// </summary>
    public partial class PageOrgnization : Page
    {
        public PageOrgnization()
        {
            InitializeComponent();
        }



        private void Street_Click(object sender, RoutedEventArgs e)
        {
            //object obj = listVice.ContainerFromElement((Button)sender);
            //int iCurrentItem = listVice.Items.IndexOf(((ListBoxItem)obj).Content);
            string content = (sender as Button).Content.ToString();
            MessageBox.Show(content);

        }

        private void Vice_Click(object sender, RoutedEventArgs e)
        {
            object obj = listVice.ContainerFromElement((Button)sender);
            int iCurrentItem = listVice.Items.IndexOf(((ListBoxItem)obj).Content);

        }

        private void Government_Click(object sender, RoutedEventArgs e)
        {
            List<string> viceList = new List<string>
            {
                "彭崧",
                "严旭",
                "朱嘉骏",
                "陆鸣",
                "陆民",
                "刘正义",
                "卫明",
                "谢毓敏"
            };
            listVice.ItemsSource = viceList;


            List<string> streetList = new List<string>
            {
                "陆家嘴街道",
                "花木街道",
                "上钢新村街道",
                "陆家嘴街道",
                "花木街道",
                "上钢新村街道",
                "陆家嘴街道",
                "花木街道",
                "上钢新村街道",
                "陆家嘴街道",
                "花木街道",
                "上钢新村街道",
                "陆家嘴街道",
                "花木街道",
                "上钢新村街道"
            };
            organList.ItemsSource = streetList;

            Type.Content = "街道、镇";

        }

        private void StreetManage_Click(object sender, RoutedEventArgs e)
        {
            List<string> viceList = new List<string>
            {
                "彭崧",
                "严旭",
                "朱嘉骏",
                "陆鸣",
                "陆民",
                "刘正义",
                "卫明",
                "谢毓敏"
            };
            listVice.ItemsSource = viceList;


            List<string> streetList = new List<string>
            {
                "政府办公室",
                "发改委",
                "经信委",
                "商务委",
                "教育局",
                "科委",
                "建交委",
                "民政局",
                "人保局",
                 "商务委",
                "教育局",
                "科委",
                "建交委",
                "民政局",
                "人保局"
            };
            organList.ItemsSource = streetList;

            Type.Content = "政府部门";
        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> viceList = new List<string>
            {
                "彭崧",
                "严旭",
                "朱嘉骏",
                "陆鸣",
                "陆民",
                "刘正义",
                "卫明",
                "谢毓敏"
            };
            listVice.ItemsSource = viceList;


            List<string> streetList = new List<string>
            {
                "陆家嘴街道",
                "花木街道",
                "上钢新村街道",
                "陆家嘴街道",
                "花木街道",
                "上钢新村街道",
                "陆家嘴街道",
                "花木街道",
                "上钢新村街道",
                "陆家嘴街道",
                "花木街道",
                "上钢新村街道",
                "陆家嘴街道",
                "花木街道",
                "上钢新村街道"
            };
            organList.ItemsSource = streetList;


        }
    }
}
