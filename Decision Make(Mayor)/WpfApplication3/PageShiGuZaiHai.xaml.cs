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
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Data;
using WpfZhihui;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for PageShiGuZaiHai.xaml
    /// </summary>
    public partial class PageShiGuZaiHai : Page
    {
        int type = 0;
        public PageShiGuZaiHai(int typeseleted)
        {
            type = typeseleted;
            InitializeComponent();
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

        }
        public EmergencyBasic ds;
        [System.Runtime.InteropServices.ComVisibleAttribute(true)]//将该类设置为com可访问
        public class EmergencyBasic
        {
            public static int type;
            public static string name;
            public EmergencyBasic(int typeseleted)
            {
                type = typeseleted;
            }
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public void ClickEvent(string strlocation)//参数暂时没用
            {
                int ijudge = 0;
                switch (type)
                {
                    case 1:
                        ijudge = 3;
                        break;
                    case 2:
                        ijudge = 1;//暂时和突发事件一致
                        break;
                    case 3:
                        ijudge = 2;
                        break;
                    case 4:
                        ijudge = 4;
                        break;


                }
                DataTable dt = new DataTable();
                SQLHelper.getPointsByCategory(ijudge, out dt);
                List<Location> m_list = new List<Location>();

                for (int ix = 0; ix < dt.Rows.Count; ix++)
                {
                    Location new_Location = new Location();
                    new_Location.Name = dt.Rows[ix]["Name"].ToString();
                    new_Location.Description = dt.Rows[ix]["Description"].ToString();
                    new_Location.Tel = dt.Rows[ix]["Tel"].ToString();
                    new_Location.Longitude = (double)dt.Rows[ix]["ilng"];
                    new_Location.Latitude = (double)dt.Rows[ix]["ilat"];

                    m_list.Add(new_Location);
                }
                strlocation = ToJsJson(m_list);
                this.Name = strlocation;
            }

        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            switch (type)
            {
                case 1://自然灾害 
                    tbx_ShiJianShiShiGengXin.Text = "事件实时更新\r\n发生时间：2012年8月13日，13：56\r\n发生地点：邯郸路大白树立交路口\r\n事件情况：";
                    tbx_ShiJianQingKuang.Text = "（v1208131359）路面出现深达60米的塌陷。\r\n（v1208131403）围观群众越来越多，地区交通中断。\r\n（v1208131411）第一辆工程抢险车赶到现场，开始进行围观操作，围观群众情绪稳定，初步确定无伤亡。\r\n（v1208131417）第二辆工程抢险车赶到现场，继续围观\r\n（v1208131422）。。。";
                break;
                case 2://社会安全 
                    tbx_ShiJianShiShiGengXin.Text = "事件实时更新\r\n发生时间：2012年10月1日，10：00\r\n发生地点：东台路55号\r\n事件情况：";
                    tbx_ShiJianQingKuang.Text = "（v1210011000）有人持刀抢劫。\r\n（v1210011010）围观群众开始追捕。\r\n（v1210011016）作案人员被捕。\r\n（v1210011025）已被移交至公安机关。\r\n（v1208131422）";
                    break;
                case 3://事故灾害
                    tbx_ShiJianShiShiGengXin.Text = "事件实时更新\r\n发生时间：2012年12月12日，10：00\r\n发生地点：同济大学汽车馆\r\n事件情况：";
                    tbx_ShiJianQingKuang.Text = "（v1212121000）同济大学汽车馆发生爆炸\r\n（v1212121015）消防官兵赶到现场开始营救。\r\n（v1212121030）在场师生工人已基本安全撤离。\r\n（v1212121040）等待事故进一步调查。";
                    break;
                case 4://公共卫生
                    tbx_ShiJianShiShiGengXin.Text = "事件实时更新\r\n发生时间：2012年12月21日，13：00\r\n发生地点：邯郸路大白树立交路口\r\n事件情况：";
                    tbx_ShiJianQingKuang.Text = "（v1212211322）路面出现不明空气污染物。\r\n（v1212211400）多名围观群众开始呕吐失去意识。\r\n（v1212211430）受感染群众开始病变，袭击路人。\r\n（v1212211454）消防特警赶到现场开始隔离感染群众。\r\n（v1212211510）卫生研究所确定污染气体为丧尸病毒。";
                    break;
            }
            DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string pathEmergency = di.Parent.Parent.FullName;
            ds = new EmergencyBasic(type);
            webBrowser_ZiRanZaiHai.Navigate(new Uri(pathEmergency + @"/html/ZiRanZaiHai.htm", UriKind.RelativeOrAbsolute));//获取根目录的日历文件
            webBrowser_ZiRanZaiHai.ObjectForScripting = ds;//该对象可由显示在WebBrowser控件中的网页所包含的脚本代码访问
        }
		
        private void dengji1_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			lingdaoceng.IsChecked=true;
			yuanrenyuan.IsChecked=true;
			yuanjigou.IsChecked=true;
        }

        private void dengji2_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
			lingdaoceng.IsChecked=true;
			yuanrenyuan.IsChecked=true;
			yuanjigou.IsChecked=true;
        }

        private void dengji3_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
			lingdaoceng.IsChecked=false;
			yuanrenyuan.IsChecked=true;
			yuanjigou.IsChecked=true;
        }

        private void dengji4_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
			lingdaoceng.IsChecked=false;
			yuanrenyuan.IsChecked=false;
			yuanjigou.IsChecked=true;
        }

        private void Gridzzss_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            switch (type)
            {
                case 1://自然灾害 
                    label_YingJiYuAn_Title.Content = "自然灾害应急预案";
                    textBlockzzss.Text = "1、要迅速组织人员逃生，原则是“先救人，后救物”。\r\n2、参加人员：在消防车到来之前，在确保自身安全的情况下均有义务参加扑救。\r\n3、消防车到来之后，要配合消防专业人员扑救或做好辅助工作。\r\n4、使用器具：灭火器、水桶、消防水带等。";
                    break;
                case 2://社会安全 
                    label_YingJiYuAn_Title.Content = "社会安全应急预案";
                    textBlockzzss.Text = "1、要迅速组织人员逃生，原则是“先救人，后救物”。\r\n2、参加人员：在消防车到来之前，在确保自身安全的情况下均有义务参加扑救。\r\n3、消防车到来之后，要配合消防专业人员扑救或做好辅助工作。\r\n4、使用器具：灭火器、水桶、消防水带等。";
                    break;
                case 3://事故灾害
                    label_YingJiYuAn_Title.Content = "事故灾害应急预案";
                    textBlockzzss.Text = "1、要迅速组织人员逃生，原则是“先救人，后救物”。\r\n2、参加人员：在消防车到来之前，在确保自身安全的情况下均有义务参加扑救。\r\n3、消防车到来之后，要配合消防专业人员扑救或做好辅助工作。\r\n4、使用器具：灭火器、水桶、消防水带等。";
                    break;
                case 4://公共卫生
                    label_YingJiYuAn_Title.Content = "公共卫生灾害应急预案";
                    textBlockzzss.Text = "1、要迅速组织人员逃生，原则是“先救人，后救物”。\r\n2、参加人员：在消防车到来之前，在确保自身安全的情况下均有义务参加扑救。\r\n3、消防车到来之后，要配合消防专业人员扑救或做好辅助工作。\r\n4、使用器具：灭火器、水桶、消防水带等。";
                    break;
            }
        }

        private void Gridpjff_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            textBlockbjff.Text = "扑救方法内容";
        }

        private void Gridzysx_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            textBlockzysx.Text = "注意事项内容";
        }

        private void tabItem4_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        	// TODO: Add event handler implementation here.
        }
    }
}
