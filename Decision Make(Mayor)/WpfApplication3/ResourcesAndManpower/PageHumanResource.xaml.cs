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
    /// Interaction logic for PageHumanResource.xaml
    /// </summary>
    public partial class PageHumanResource : Page
    {
        public PageHumanResource()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> viceList = new List<string>
            {
                "副局长 朱学军",
                "副局长 蔡赞石",
                "副局长 陈会润",
                "总规划师 刘伟"
            };
            listLeader.ItemsSource = viceList;


            List<string> departList = new List<string>
            {
                "办公室",
                "组织人事处",
                "规划管理处",
                "建筑规划管理处",
                "市政规划管理处",
                "综合监督管理处",
                "土地综合计划处"
            };
            listDepartment.ItemsSource = departList;


        }



        private void Depart_Click(object sender, RoutedEventArgs e)
        {
            string content = (sender as Button).Content.ToString();
            BriefIntro.Text = "简介测试" + content;
            Address.Text = "联系方式测试" + content;
        }

        private void JuZhang_Click(object sender, RoutedEventArgs e)
        {
            WindowHuman wh = new WindowHuman();
            wh.Show();
        }

        private void Leader_Click(object sender, RoutedEventArgs e)
        {
            string content = (sender as Button).Content.ToString();
            WindowHuman wh = new WindowHuman();
            wh.Show();
        }
    }
}
