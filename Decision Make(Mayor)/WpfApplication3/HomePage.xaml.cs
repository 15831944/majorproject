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
using System.IO;
using System.Data;
using WpfZhihui;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Net;
using System.Diagnostics;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        string strPATH;
        public HomePage()
        {
            InitializeComponent();
            //
            runWeather.Content = WpfApplication3.Language.Language.HomePage_runWeather;
            tblCalendar.Content = WpfApplication3.Language.Language.HomePage_tblCalendar;
            tblPM.Content = WpfApplication3.Language.Language.HomePage_tblPM;
            tblTemperature.Content = WpfApplication3.Language.Language.HomePage_tblTemperature;
            tblEmergency.Content = WpfApplication3.Language.Language.HomePage_tblEmergency;
            tblTransportation.Content = WpfApplication3.Language.Language.HomePage_tblTransportation;
            //
            DirectoryInfo di;
            di = new DirectoryInfo(System.Environment.CurrentDirectory);
            strPATH = di.Parent.Parent.FullName;
            ///导入RSS推送信息
            // Insert code required on object creation below this point.

            string pathTraffic = di.Parent.Parent.FullName;
            wbTraffic.Navigate(new Uri(pathTraffic + @"/html/Traffic.htm", UriKind.RelativeOrAbsolute));
            //wbTraffic.Document.documentElement.style.overflow = "hidden"; //隐藏浏览器的滚动条
            string pathEmergency = di.Parent.Parent.FullName;
            ds = new EmergencyBasic(this);
            wbEmergency.Navigate(new Uri(pathEmergency + @"/html/Emergency.htm", UriKind.RelativeOrAbsolute));//获取根目录的日历文件
            wbEmergency.ObjectForScripting = ds;//该对象可由显示在WebBrowser控件中的网页所包含的脚本代码访问
            //wb_weibo.Navigate(new Uri(pathEmergency + @"/html/weibo.htm"));
            wbenvironment.Navigate(new Uri(pathEmergency + @"/html/PM25.htm", UriKind.RelativeOrAbsolute));
            /*string pathEnvironment = di.Parent.Parent.FullName;
            ds1 = new EnvironmentBasic();
            wbenvironment.Navigate(new Uri(pathEnvironment + @"/html/Environment.htm", UriKind.RelativeOrAbsolute));//获取根目录的日历文件
            wbenvironment.ObjectForScripting = ds1;//该对象可由显示在WebBrowser控件中的网页所包含的脚本代码访问*/
            //LoadRss();
            loadWeather();
        }

        public void loadWeather()
        {
            try
            {
                WeatherWebService.WeatherWebServiceSoapClient ws = new WeatherWebService.WeatherWebServiceSoapClient();
                string[] strWeather = ws.getWeatherbyCityName("上海");
                BitmapImage image = new BitmapImage(new Uri(strPATH + @"/weatherlogo/a_" + strWeather[8], UriKind.RelativeOrAbsolute));
                w_image1.Source = image;
                w_label1.Content = (strWeather[6].Split(' '))[1];
                w_label0.Content = (strWeather[6].Split(' '))[0];
                string str = (strWeather[10].Split('；'))[0];
                w_label2.Content = (str.Split('：'))[2];
                w_label3.Content = "上次监测：" + (strWeather[4].Split(' '))[1];
                w_label4.Content = (strWeather[10].Split('；'))[2];
                w_label5.Content = (strWeather[10].Split('；'))[1];
                w_label6.Content = (strWeather[10].Split('；'))[3];
                w_label7.Content = (strWeather[10].Split('；'))[4];

                w_label8.Content = (strWeather[6].Split(' '))[0];
                w_label9.Content = (strWeather[13].Split(' '))[0];
                w_label10.Content = (strWeather[18].Split(' '))[0];
                image = new BitmapImage(new Uri(strPATH + @"/weatherlogo/b_" + strWeather[8], UriKind.RelativeOrAbsolute));
                w_image2.Source = image;
                image = new BitmapImage(new Uri(strPATH + @"/weatherlogo/b_" + strWeather[15], UriKind.RelativeOrAbsolute));
                w_image3.Source = image;
                image = new BitmapImage(new Uri(strPATH + @"/weatherlogo/b_" + strWeather[20], UriKind.RelativeOrAbsolute));
                w_image4.Source = image;
                w_label11.Content = strWeather[5];
                w_label12.Content = strWeather[12];
                w_label13.Content = strWeather[17];
            }
            catch (Exception)
            {
                MessageBox.Show("天气预报真在维护");
            }

            System.Net.WebClient wc = new System.Net.WebClient();

            DateTime nowtime = DateTime.Now;
            string timeStr = nowtime.ToString("yyyyMMddHHmm");
            string minute = DateTime.Now.Minute.ToString();
            int minuteInt = Convert.ToInt32(minute);
            int model = minuteInt - minuteInt % 6 + 2;
            string modelstr = model.ToString("D2");
            timeStr = timeStr.Substring(0, 10) + modelstr;
            string imgPath = @"http://www.soweather.com/PicFiles/wd" + timeStr + @".png";

            while (!RemoteFileExists(imgPath))
            {
                nowtime = nowtime.AddMinutes(-6);
                timeStr = nowtime.ToString("yyyyMMddHHmm");
                minute = nowtime.Minute.ToString();
                minuteInt = Convert.ToInt32(minute);
                model = minuteInt - minuteInt % 6 + 2;
                modelstr = model.ToString("D2");
                timeStr = timeStr.Substring(0, 10) + modelstr;
                imgPath = @"http://www.soweather.com/PicFiles/wd" + timeStr + @".png";
            }
            /*
            wc.DownloadFile(new Uri(imgPath), timeStr + @".png");
            FileInfo fileInfo = new FileInfo(timeStr + @".png");

            DirectoryInfo diDebug = new DirectoryInfo(System.Environment.CurrentDirectory);
            string strPATH = diDebug.FullName;
            image1.Source = new BitmapImage(new Uri(diDebug+@"\"+timeStr+@".png", UriKind.RelativeOrAbsolute));
            */

            Uri uri = new Uri(imgPath, UriKind.Absolute);
            BitmapImage bmp = new BitmapImage(uri);
            w_imageWeather.Source = bmp;
            w_webBrowser1.Source = new Uri("http://flash.weather.com.cn/sk2/shikuang.swf?id=101020100");

        }
        private bool RemoteFileExists(string fileUri)
        {
            bool result = false;//下载结果

            WebResponse response = null;
            try
            {
                WebRequest req = WebRequest.Create(fileUri);

                response = req.GetResponse();

                result = response == null ? false : true;

            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }

            return result;
        }

        public static string ToJsJson(object item)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(item.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, item);
                StringBuilder sb = new StringBuilder();
                sb.Append(Encoding.UTF8.GetString(ms.ToArray()));
                return sb.ToString();
            }
        }
        /// <summary>
        /// 数据格式，定义好数据的序列化细节
        /// </summary>
        [DataContract]
        public class Location
        {
            [DataMember(Order = 1)]
            public double Longitude { get; set; }
            [DataMember(Order = 2)]
            public double Latitude { get; set; }
            [DataMember(Order = 3)]
            public string Name { get; set; }
            [DataMember(Order = 4)]
            public string Description { get; set; }
            [DataMember(Order = 5)]
            public string Tel { get; set; }
            [DataMember(Order = 6)]
            public int icategory { get; set; }

        }
        public EmergencyBasic ds;
        [System.Runtime.InteropServices.ComVisibleAttribute(true)]//将该类设置为com可访问
        public class EmergencyBasic
        {
           public EmergencyBasic(HomePage hp)//调用navigateservice
           {
               php = hp;
           }
           private HomePage php; 
            public static string name;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public void LinkTo(int icategory)
            {
                PageShiGuZaiHai m_PageShiGuZaiHai =null;
                switch (icategory)
                {
                    case 1:
                        m_PageShiGuZaiHai = new PageShiGuZaiHai(2);//社会安全   
                        break;
                    case 2:
                         m_PageShiGuZaiHai = new PageShiGuZaiHai(3);//社会安全   
                        break;
                    case 3:  
                        m_PageShiGuZaiHai = new PageShiGuZaiHai(1);//自然灾害
                        break;
                    case 4:
                        m_PageShiGuZaiHai = new PageShiGuZaiHai(4);//公共卫生
                        break;
                }
                if (m_PageShiGuZaiHai!=null)
                {
                    php.NavigationService.Navigate(m_PageShiGuZaiHai);
                }
            }
            public void ClickEvent(string strlocation)
            {
                DataTable dt = new DataTable();
                //SQLHelper.getPointsByCategory(ijudge, out dt);
                SQLHelper.getAllPoints(out dt);
                List<Location> m_list = new List<Location>();

                for (int ix = 0; ix < dt.Rows.Count; ix++)
                {
                    Location new_Location = new Location();
                    new_Location.Name = dt.Rows[ix]["Name"].ToString();
                    new_Location.Description = dt.Rows[ix]["Description"].ToString();
                    new_Location.Tel = dt.Rows[ix]["Tel"].ToString();
                    new_Location.Longitude = (double)dt.Rows[ix]["ilng"];
                    new_Location.Latitude = (double)dt.Rows[ix]["ilat"];
                    new_Location.icategory = (int)dt.Rows[ix]["icategory"];
                    m_list.Add(new_Location);
                }
                strlocation = ToJsJson(m_list);
                this.Name = strlocation;
            }

        }
        
        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;

        }

        private void calendar1_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            textBox_Calendar.Clear();
            string str = ((DateTime)calendar1.SelectedDate).ToShortDateString();
            DataSetCalendarTableAdapters.T_CalendarTableAdapter adapter = new DataSetCalendarTableAdapters.T_CalendarTableAdapter();
            DataSetCalendar.T_CalendarDataTable dt = adapter.GetDataByDate(str);
            if (dt.Rows.Count != 0)
            {
                textBox_Calendar.Text = dt[0].calendar_tbx;
            }
        }

        private void btnWeatherRefresh_Click(object sender, RoutedEventArgs e)
        {
            if (w_webBrowser1.Document != null)
                w_webBrowser1.Refresh();
        }

        private void btnTrafficRefresh_Click(object sender, RoutedEventArgs e)
        {
            if (wbTraffic.Document != null)
                wbTraffic.Refresh();
        }

        private void btnEmergencyRefresh_Click(object sender, RoutedEventArgs e)
        {
            if (wbEmergency.Document != null)
                wbEmergency.Refresh();
        }

        private void btnEnvironmentRefresh_Click(object sender, RoutedEventArgs e)
        {
            if (wbenvironment.Document != null)
                wbenvironment.Refresh();
        }

        private void btn_typhoon_Click(object sender, RoutedEventArgs e)
        {
            wbEmergency.Source = new Uri("http://typhoon.zjwater.gov.cn/");
        }

        private void btn_maxweather_Click(object sender, RoutedEventArgs e)
        {
            PageMaxWeather page = new PageMaxWeather();
            this.NavigationService.Navigate(page);
        }

        private void btn_maxtraffic_Click(object sender, RoutedEventArgs e)
        {
            PageMaxTraffic page = new PageMaxTraffic();
            this.NavigationService.Navigate(page);
        }

        private void btn_maxenvironment_Click(object sender, RoutedEventArgs e)
        {
            PageMaxEnvironment page = new PageMaxEnvironment();
            this.NavigationService.Navigate(page);
        }

        private void btn_maxemergency_Click(object sender, RoutedEventArgs e)
        {
            PageMaxEmergency page = new PageMaxEmergency();
            this.NavigationService.Navigate(page);
        }

        private void btn_emergency_Click(object sender, RoutedEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string pathEmergency = di.Parent.Parent.FullName;
            ds = new EmergencyBasic(this);
            wbEmergency.Navigate(new Uri(pathEmergency + @"/html/Emergency.htm", UriKind.RelativeOrAbsolute));//获取根目录的日历文件
            wbEmergency.ObjectForScripting = ds;//该对象可由显示在WebBrowser控件中的网页所包含的脚本代码访问
        }

    }
}
