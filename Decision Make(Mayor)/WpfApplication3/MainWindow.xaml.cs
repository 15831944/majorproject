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
using System.Windows.Shapes;
using System.IO;
using System.Windows.Threading;
using System.Diagnostics;
using System.Xml;
using WpfZhihui;
using WpfApplication3.Language;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string strPATH;
        private List<NewsItem> items = new List<NewsItem>();
        //-------------------------------------------------------------
        public MainWindow()
        {
            InitializeComponent();

            //
            menutitle1.Content = WpfApplication3.Language.Language.MainWindow_menutitle1;
            menutitle2.Content = WpfApplication3.Language.Language.MainWindow_menutitle2;
            menutitle3.Content = WpfApplication3.Language.Language.MainWindow_menutitle3;
            menutitle4.Content = WpfApplication3.Language.Language.MainWindow_menutitle4;
            menutitle5.Content = WpfApplication3.Language.Language.MainWindow_menutitle5;
            menutitle6.Content = WpfApplication3.Language.Language.MainWindow_menutitle6;
            menutitle7.Content = WpfApplication3.Language.Language.MainWindow_menutitle7;
            menutitle8.Content = WpfApplication3.Language.Language.MainWindow_menutitle8;
            menu1_1.Content = WpfApplication3.Language.Language.MainWindow_menu1_1;
            menu1_2.Content = WpfApplication3.Language.Language.MainWindow_menu1_2;
            menu1_3.Content = WpfApplication3.Language.Language.MainWindow_menu1_3;
            menu2_1.Content = WpfApplication3.Language.Language.MainWindow_menu2_1;
            menu2_2.Content = WpfApplication3.Language.Language.MainWindow_menu2_2;
            menu2_4.Content = WpfApplication3.Language.Language.MainWindow_menu2_4;
            menu3_1.Content = WpfApplication3.Language.Language.MainWindow_menu3_1;
            menu3_2.Content = WpfApplication3.Language.Language.MainWindow_menu3_2;
            menu4_1.Content = WpfApplication3.Language.Language.MainWindow_menu4_1;
            menu4_2.Content = WpfApplication3.Language.Language.MainWindow_menu4_2;
            menu4_3.Content = WpfApplication3.Language.Language.MainWindow_menu4_3;
            menu5_1.Content = WpfApplication3.Language.Language.MainWindow_menu5_1;
            menu5_2.Content = WpfApplication3.Language.Language.MainWindow_menu5_2;
            menu5_3.Content = WpfApplication3.Language.Language.MainWindow_menu5_3;
            menu6_1.Content = WpfApplication3.Language.Language.MainWindow_menu6_1;
            menu6_2.Content = WpfApplication3.Language.Language.MainWindow_menu6_2;
            menu6_3.Content = WpfApplication3.Language.Language.MainWindow_menu6_3;
            menu6_4.Content = WpfApplication3.Language.Language.MainWindow_menu6_4;
            menu7_1.Content = WpfApplication3.Language.Language.MainWindow_menu7_1;
            menu7_2.Content = WpfApplication3.Language.Language.MainWindow_menu7_2;
            menu7_3.Content = WpfApplication3.Language.Language.MainWindow_menu7_3;
            menu8_1.Content = WpfApplication3.Language.Language.MainWindow_menu8_1;
            menu8_2.Content = WpfApplication3.Language.Language.MainWindow_menu8_2;
            menu8_3.Content = WpfApplication3.Language.Language.MainWindow_menu8_3;
            lblMedia.Content = WpfApplication3.Language.Language.MainWindow_lblMedia;
            lblMicroblog.Content = WpfApplication3.Language.Language.MainWindow_lblMicroblog;
            //
            DirectoryInfo di;
            di = new DirectoryInfo(System.Environment.CurrentDirectory);
            strPATH = di.Parent.Parent.FullName;
            wb_weibo.Navigate(new Uri(strPATH + @"/html/weibo.htm"));
            LoadRss();
            DispatcherTimer timer = new DispatcherTimer();
            //设置间隔1秒
            timer.Interval = new TimeSpan(0, 0, 1);
            //创建事件处理
            timer.Tick += new EventHandler(timer_Tick);
            //开始计时
            timer.Start();


            Home_Click(new object(), new RoutedEventArgs());
        }
        void timer_Tick(object sender, EventArgs e)
        {
            DateHelper datehelper = new DateHelper();
            labe_time.Content = datehelper.getTime();
            label_day.Content = datehelper.getDay();
            label_dayofweek.Content = datehelper.getDayofWeek();
            label_month.Content = datehelper.getMonth();
            label_dayofweek_zh.Content = datehelper.getDayofWeekzh();
            label_month.Content = datehelper.getMonth();
            label_month_zh.Content = datehelper.getMonthzh();
        }

        private void imageTVCover_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Dongfangweishi.IsSelected = true;
        }
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string ix = (e.AddedItems[0].ToString().Split(' '))[1];
            if (ix == "东方卫视")
            {
                imageTVCover.Visibility = Visibility.Hidden;
                WebBrowserTV.Visibility = Visibility.Visible;
                WebBrowserTV.Navigate(new Uri(strPATH + @"/html/zhiboDongfangweishi.htm", UriKind.RelativeOrAbsolute));

            }
            else if (ix == "CCTV新闻")
            {
                imageTVCover.Visibility = Visibility.Hidden;
                WebBrowserTV.Visibility = Visibility.Visible;

                DirectoryInfo di;
                di = new DirectoryInfo(System.Environment.CurrentDirectory);
                string strpath = di.Parent.Parent.FullName;
                WebBrowserTV.Navigate(new Uri(strpath + @"/html/zhiboCCTV13.htm", UriKind.RelativeOrAbsolute));
            }
            else if (ix == "CCTV体育")
            {
                imageTVCover.Visibility = Visibility.Hidden;
                WebBrowserTV.Visibility = Visibility.Visible;
                WebBrowserTV.Navigate(new Uri(strPATH + @"/html/zhiboCCTV5.htm", UriKind.RelativeOrAbsolute));
            }
            else if (ix == "五星体育")
            {
                imageTVCover.Visibility = Visibility.Hidden;
                WebBrowserTV.Visibility = Visibility.Visible;
                WebBrowserTV.Navigate(new Uri(strPATH + @"/html/zhiboWuxingtiyu.htm", UriKind.RelativeOrAbsolute));
            }

        }

        public void LoadRss()
        {
            string[] rsspath ={ "http://news.163.com/special/00011K6L/rss_newstop.xml",
                                   //"http://www.xinhuanet.com/politics/news_politics.xml",
                                   "http://news.baidu.com/n?cmd=1&class=civilnews&tn=rss&sub=0",
                                   "http://news.online.sh.cn/news/gb/special/news.xml"
                                   ,"http://rss.sina.com.cn/news/china/focus15.xml"
                              };//RSS地址
            string[] channeltitle ={"网易头条",
                                   //"新华时政",
                                   "百度国内焦点",
                                   "上海新闻热线"
                                   ,"新浪新闻"
                                   };
            string[] channellink ={"http://news.163.com/",
                                   //"http://www.xinhuanet.com/politics/xw.htm",
                                   "http://news.baidu.com",
                                   "http://news.online.sh.cn/news/gb/node/news_default.htm"
                                   ,"http://news.sina.com.cn"
                                  };
            string[] logopath = {
                                "/Images/网易2.png",
                                //"/Images/新华1.jpg",
                                "/Images/百度.png",
                                "/Images/上海热线.jpg"
                                ,"/Images/sina.png"
                                };
            for (int cid = 0; cid < 4; cid++)
            {
                XmlDocument doc = new XmlDocument();//创建文档对象
                try
                {
                    doc.Load(rsspath[cid]);//加载XML 包括HTTP：// 和本地
                    XmlNodeList list = doc.GetElementsByTagName("item"); //获得项   
                    XmlNode node = list.Item(0);//
                    NewsItem item = new NewsItem();
                    item = getItem((XmlElement)node);
                    item.ChannelLink = channellink[cid];
                    item.ChannelTitle = channeltitle[cid];
                    item.LogoPath = logopath[cid];
                    //加入list
                    items.Add(item);
                }
                catch (Exception)
                {
                    //异常处理
                }
                //初始化Rss 
                
            }

            //添加绑定操作
            this.Rsslist.ItemsSource = items;
        }
        private NewsItem getItem(XmlElement ele)
        {
            NewsItem item = new NewsItem();
            item.Title = ele.GetElementsByTagName("title")[0].InnerText;//获得标题
            item.Link = ele.GetElementsByTagName("link")[0].InnerText;//获得联接
            string des = ele.GetElementsByTagName("description")[0].InnerText;//获得简介
            if (des.Length > 80)
            {
                des = des.Substring(0, 80) + "……";
            }
            item.Description = des;
            //item.PubDate = ele.GetElementsByTagName("pubDate")[0].InnerText;//获得发布日期
            return item;
        }

        private void weibo_topic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string topic = weibo_topic.Text;
                WeiboHelper weibohelper = new WeiboHelper();
                weibohelper.settopic(topic);
                wb_weibo.Navigate(new Uri(strPATH + @"/bin/Debug/weibo.htm"));
            }
        }
        private void weibo_topic_GotMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // TODO: Add event handler implementation here.
            weibo_topic.Text = "";
        }
        private void weibo_search_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            string topic = weibo_topic.Text;
            WeiboHelper weibohelper = new WeiboHelper();
            weibohelper.settopic(topic);
            wb_weibo.Navigate(new Uri(strPATH + @"/bin/Debug/weibo.htm"));
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;

        }

        private void Home_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
			HideMenu();
			UnselectMenus();
			VisibleMenuTitle();
            HomePage m_HomePage = new HomePage();
            FrameMiddleContent.Navigate(m_HomePage);
        }
		
        private void Btn_Schedule_Click(object sender, RoutedEventArgs e)
        {
            DailyManagement.Schedule m_Schedule = new DailyManagement.Schedule();
            FrameMiddleContent.Navigate(m_Schedule);
        }

		private void HideMenu()
		{
                menu1.Visibility = System.Windows.Visibility.Collapsed;
                menu2.Visibility = System.Windows.Visibility.Collapsed;
                menu3.Visibility = System.Windows.Visibility.Collapsed;
                menu4.Visibility = System.Windows.Visibility.Collapsed;
                menu6.Visibility = System.Windows.Visibility.Collapsed;
                menu7.Visibility = System.Windows.Visibility.Collapsed;
                menu5.Visibility = System.Windows.Visibility.Collapsed;
				menu8.Visibility = System.Windows.Visibility.Collapsed;    
		}
		private void VisibleMenuTitle()
		{
			    menutitle1.Visibility = System.Windows.Visibility.Visible;
                menutitle2.Visibility = System.Windows.Visibility.Visible;
                menutitle3.Visibility = System.Windows.Visibility.Visible;
                menutitle4.Visibility = System.Windows.Visibility.Visible;
                menutitle6.Visibility = System.Windows.Visibility.Visible;
                menutitle7.Visibility = System.Windows.Visibility.Visible;
                menutitle5.Visibility = System.Windows.Visibility.Visible;
				menutitle8.Visibility = System.Windows.Visibility.Visible;    

		}
		
		private void HideMenuTitle()
		{
			    menutitle1.Visibility = System.Windows.Visibility.Collapsed;
                menutitle2.Visibility = System.Windows.Visibility.Collapsed;
                menutitle3.Visibility = System.Windows.Visibility.Collapsed;
                menutitle4.Visibility = System.Windows.Visibility.Collapsed;
                menutitle6.Visibility = System.Windows.Visibility.Collapsed;
                menutitle7.Visibility = System.Windows.Visibility.Collapsed;
                menutitle5.Visibility = System.Windows.Visibility.Collapsed;
				menutitle8.Visibility = System.Windows.Visibility.Collapsed;    

		}
		private void UnselectMenus()
		{
			menutitle1.IsSelected=false;
			menutitle2.IsSelected=false;
			menutitle3.IsSelected=false;
			menutitle4.IsSelected=false;
			menutitle5.IsSelected=false;
			menutitle6.IsSelected=false;
			menutitle7.IsSelected=false;
			menutitle8.IsSelected=false;			
		}
		        
        private void menutitle1_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (menu1.Visibility == System.Windows.Visibility.Visible)
            {
                HideMenu();
                UnselectMenus();
                VisibleMenuTitle();
            }
            else
            {
                HideMenu();
                HideMenuTitle();
                menu1.Visibility = System.Windows.Visibility.Visible;
                menutitle1.Visibility = System.Windows.Visibility.Visible;
            }
        }
		
		private void menutitle2_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (menu2.Visibility == System.Windows.Visibility.Visible)
            {
                HideMenu();
                UnselectMenus();
                VisibleMenuTitle();
            }
            else
            {
                HideMenu();
                HideMenuTitle();
                menu2.Visibility = System.Windows.Visibility.Visible;
                menutitle2.Visibility = System.Windows.Visibility.Visible;
            }
        }
		
		private void menutitle3_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (menu3.Visibility == System.Windows.Visibility.Visible)
            {
                HideMenu();
                UnselectMenus();
                VisibleMenuTitle();
            }
            else
            {
                HideMenu();
                HideMenuTitle();
                menu3.Visibility = System.Windows.Visibility.Visible;
                menutitle3.Visibility = System.Windows.Visibility.Visible;
            }
        }
		
		private void menutitle4_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (menu4.Visibility == System.Windows.Visibility.Visible)
            {
                HideMenu();
                UnselectMenus();
                VisibleMenuTitle();
            }
            else
            {
                HideMenu();
                HideMenuTitle();
                menu4.Visibility = System.Windows.Visibility.Visible;
                menutitle4.Visibility = System.Windows.Visibility.Visible;
            }
        }
		
		private void menutitle5_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (menu5.Visibility == System.Windows.Visibility.Visible)
            {
                HideMenu();
                UnselectMenus();
                VisibleMenuTitle();
            }
            else
            {
                HideMenu();
                HideMenuTitle();
                menu5.Visibility = System.Windows.Visibility.Visible;
                menutitle5.Visibility = System.Windows.Visibility.Visible;
            }
        }
		
		private void menutitle6_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (menu6.Visibility == System.Windows.Visibility.Visible)
            {
                HideMenu();
                UnselectMenus();
                VisibleMenuTitle();
            }
            else
            {
                HideMenu();
                HideMenuTitle();
                menu6.Visibility = System.Windows.Visibility.Visible;
                menutitle6.Visibility = System.Windows.Visibility.Visible;
            }
        }
		
		private void menutitle7_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (menu7.Visibility == System.Windows.Visibility.Visible)
            {
                HideMenu();
                UnselectMenus();
                VisibleMenuTitle();
            }
            else
            {
                HideMenu();
                HideMenuTitle();
                menu7.Visibility = System.Windows.Visibility.Visible;
                menutitle7.Visibility = System.Windows.Visibility.Visible;
            }
        }
		
		private void menutitle8_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (menu8.Visibility == System.Windows.Visibility.Visible)
            {
                HideMenu();
                UnselectMenus();
                VisibleMenuTitle();
            }
            else
            {
                HideMenu();
                HideMenuTitle();
                menu8.Visibility = System.Windows.Visibility.Visible;
                menutitle8.Visibility = System.Windows.Visibility.Visible;
            }
        }
		
        private void TalentC(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            Development_performance.Economic  TalentC = new  Development_performance.Economic();
            FrameMiddleContent.Navigate(TalentC);

        }
           private void ScientificR(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            Development_performance.Society  ScientificR = new  Development_performance.Society();
            FrameMiddleContent.Navigate(ScientificR);

        }
           private void ComprehensiveR(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            Development_performance.Environment  ComprehensiveR = new  Development_performance.Environment();
            FrameMiddleContent.Navigate(ComprehensiveR);

        }
      

        public void menu6_1_Selected(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			PageShiGuZaiHai m_PageShiGuZaiHai = new PageShiGuZaiHai(1);//自然灾害
            FrameMiddleContent.Navigate(m_PageShiGuZaiHai);

		}
        private void menu6_2_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            PageShiGuZaiHai m_PageShiGuZaiHai = new PageShiGuZaiHai(2);//社会安全
            FrameMiddleContent.Navigate(m_PageShiGuZaiHai);

        }
        private void menu6_3_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            PageShiGuZaiHai m_PageShiGuZaiHai = new PageShiGuZaiHai(3);//事故灾害
            FrameMiddleContent.Navigate(m_PageShiGuZaiHai);

        }
        private void menu6_4_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            PageShiGuZaiHai m_PageShiGuZaiHai = new PageShiGuZaiHai(4);//
            FrameMiddleContent.Navigate(m_PageShiGuZaiHai);

        }

		private void menu7_1_Selected(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			FeedBack.PageTeacherStudentFeedback m_PageTeacherStudentFeedback = new FeedBack.PageTeacherStudentFeedback(1);
            FrameMiddleContent.Navigate(m_PageTeacherStudentFeedback);
			
			
		}

		private void menu4_2_Selected(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			Communicate.PageDocIssue m_PageDocIssue = new Communicate.PageDocIssue();
            FrameMiddleContent.Navigate(m_PageDocIssue);
		}

		private void menu8_1_Selected(object sender, System.Windows.RoutedEventArgs e)//重大项目
		{
			// TODO: Add event handler implementation here.
			LargeProject.PageProject m_PageProject = new LargeProject.PageProject(1);
            FrameMiddleContent.Navigate(m_PageProject);

		}
        private void menu8_2_Selected(object sender, RoutedEventArgs e)
        {
            LargeProject.PageProject m_PageProject = new LargeProject.PageProject(2);
            FrameMiddleContent.Navigate(m_PageProject);
        }

        private void menu8_3_Selected(object sender, RoutedEventArgs e)
        {
            LargeProject.PageProject m_PageProject = new LargeProject.PageProject(3);
            FrameMiddleContent.Navigate(m_PageProject);
        }
		
		private void menu5_1_Selected(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			
            Case.PageCase m_PageCase = new Case.PageCase(1);
            FrameMiddleContent.Navigate(m_PageCase);
		}

		private void menu4_3_Selected(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
            DailyManagement.VideoConferencing m_VideoConferencing = new DailyManagement.VideoConferencing();
            FrameMiddleContent.Navigate(m_VideoConferencing);
		}

		private void menu4_1_Selected(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			DailyManagement.Schedule m_Schedule = new DailyManagement.Schedule();
            FrameMiddleContent.Navigate(m_Schedule);

		}

		private void menutitle_Selected(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
		}

        private void menu2_2_Selected(object sender, RoutedEventArgs e)
        {
            //ResourcesAndManpower.PageOrganizationStructure m_OrganizationStructure = new ResourcesAndManpower.PageOrganizationStructure();
            //FrameMiddleContent.Navigate(m_OrganizationStructure);
            ResourcesAndManpower.PageOrgnization m_OrganizationStructure = new ResourcesAndManpower.PageOrgnization();
            FrameMiddleContent.Navigate(m_OrganizationStructure);
        }

        private void menu2_1_Selected(object sender, RoutedEventArgs e)
        {
            ResourcesAndManpower.PageSpatialResource m_Page = new ResourcesAndManpower.PageSpatialResource();
            FrameMiddleContent.Navigate(m_Page);
        }

        private void menu2_3_Selected(object sender, RoutedEventArgs e)
        {
            
        }

        private void menu2_4_Selected(object sender, RoutedEventArgs e)
        {
            ResourcesAndManpower.PageFinacialReource m_Page = new ResourcesAndManpower.PageFinacialReource();
            FrameMiddleContent.Navigate(m_Page);
        }

        private void menu5_2_Selected(object sender, RoutedEventArgs e)
        {
            Case.PageCase m_PageCase = new Case.PageCase(2);
            FrameMiddleContent.Navigate(m_PageCase);
        }

        private void menu5_3_Selected(object sender, RoutedEventArgs e)
        {
            Case.PageCase m_PageCase = new Case.PageCase(3);
            FrameMiddleContent.Navigate(m_PageCase);
        }

        private void menu7_2_Selected(object sender, RoutedEventArgs e)
        {
            FeedBack.PageTeacherStudentFeedback m_PageTeacherStudentFeedback = new FeedBack.PageTeacherStudentFeedback(2);
            FrameMiddleContent.Navigate(m_PageTeacherStudentFeedback);
        }

        private void menu7_3_Selected(object sender, RoutedEventArgs e)
        {
            FeedBack.PageTeacherStudentFeedback m_PageTeacherStudentFeedback = new FeedBack.PageTeacherStudentFeedback(3);
            FrameMiddleContent.Navigate(m_PageTeacherStudentFeedback);
        }

        private void FrameMiddleContent_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }


    }
}
