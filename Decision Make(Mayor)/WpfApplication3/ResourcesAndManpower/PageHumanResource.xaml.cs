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
				"局长：许健",
                "副局长：朱学军",
                "副局长：蔡赞石",
                "副局长：陈会润",
                "总规划师：刘伟"
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
            switch (content)
            {
                case "办公室":
                    BriefIntro.Text = "简介：办公室\r\n下设政策研究室、外事办，主要负责土地规划局的日常运转，同时，研究上级政策，部署本地工作，并且负责对外交流。";
                    Address.Text = "联系方式：北京西路99号　|　邮政编码：200003 | 联系电话：021- 6319 3188 转 01";
                    break;
                case "组织人事处":
                    BriefIntro.Text = "简介：组织人事处\r\n负责日常组织工作 人事事务。";
                    Address.Text = "联系方式：北京西路99号　|　邮政编码：200003 | 联系电话：021- 6319 3188 转 02";
                    break;
                case "规划管理处":
                    BriefIntro.Text = "简介：规划管理处\r\n负责土地规划，周边配套规划等。";
                    Address.Text = "联系方式：北京西路99号　|　邮政编码：200003 | 联系电话：021- 6319 3188 转 03";
                    break;
                case "建筑规划管理处":
                    BriefIntro.Text = "简介：建筑规划管理处\r\n负责土地内的建筑的设计审核，规划。";
                    Address.Text = "联系方式：北京西路99号　|　邮政编码：200003 | 联系电话：021- 6319 3188 转 04";
                    break;
                case "市政规划管理处":
                    BriefIntro.Text = "简介：市政规划管理处\r\n负责地块内的市政规划。";
                    Address.Text = "联系方式：北京西路99号　|　邮政编码：200003 | 联系电话：021- 6319 3188 转 05";
                    break;
                case "综合监督管理处":
                    BriefIntro.Text = "简介：综合监督管理处\r\n负责对政策落实及违法情况的监督，管理。";
                    Address.Text = "联系方式：北京西路99号　|　邮政编码：200003 | 联系电话：021- 6319 3188 转 06";
                    break;
                case "土地综合计划处":
                    BriefIntro.Text = "简介：土地综合计划处\r\n负责对土地的评估等。";
                    Address.Text = "联系方式：北京西路99号　|　邮政编码：200003 | 联系电话：021- 6319 3188 转 07";
                    break;
            }
        }

        private void Leader_Click(object sender, RoutedEventArgs e)
        {
            string content = (sender as Button).Content.ToString();
            lb_name.Content = content;
            img_leader.Source = new BitmapImage(new Uri("/Images/photos/" + content + ".jpg", UriKind.Relative));
            switch (content)
            {
                case "局长：许健":
                    lb_email.Content = "E-mail: xujian@governmentpudong.gov";
                    break;
                case "副局长：朱学军":
                    lb_email.Content = "E-mail: zhuxuejun@governmentpudong.gov";
                    break;
                case "副局长：蔡赞石":
                    lb_email.Content = "E-mail: caizanshi@governmentpudong.gov";
                    break;
                case "副局长：陈会润":
                    lb_email.Content = "E-mail: chenhuirun@governmentpudong.gov";
                    break;
                case "总规划师：刘伟":
                    lb_email.Content = "E-mail: liuwei@governmentpudong.gov";
                    break;
            }
        }

        //private void button1_Click(object sender, RoutedEventArgs e)
        //{//返回键
        //    ResourcesAndManpower.PageOrgnization m_Page = new ResourcesAndManpower.PageOrgnization();
        //    this.NavigationService.Navigate(m_Page);
        //}

        private void txb_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //单击区长 返回
            ResourcesAndManpower.PageOrgnization m_Page = new ResourcesAndManpower.PageOrgnization();
            this.NavigationService.Navigate(m_Page);
        }
    }
}
