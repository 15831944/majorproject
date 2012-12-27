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

namespace WpfApplication3.ResourcesAndManpower
{
    /// <summary>
    /// Interaction logic for PageSpatialResource.xaml
    /// </summary>
    public partial class PageSpatialResource : Page
    {

        public PageSpatialResource()
        {
            InitializeComponent();
        }

        private void Grid_Satellite_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string strPATH = di.Parent.Parent.FullName;
            GoogleMapHelper m_GoogleMapHelper = new GoogleMapHelper();
            m_GoogleMapHelper.setMap(0, "31.22924594193164", "121.48104309082031");
            webbrowserContent.Navigate(new Uri(strPATH + @"/html/GoogleMap.htm"));
            tblAnnotation.Text = "浦东新区总体规划体现了高起点、高标准，面向二十一世纪并使之建设成为现代化国际一流城市的战略目标。并以多视角地研究和探索浦东新区的功能定位、规划布局以及浦东浦协调发展等诸多问题。其目的是为了从城市发展的物质形态上保证浦东新区社会经济高速发展，从而带动上海以至整个长江三角洲地区的社会经济发展的总目标。(1)浦东新区是上海城市的一个有机整体，同时又是有相对独立性的新区。浦东的开发，要依托浦西的综合优势，浦东的开放又促进浦西产业结构和城市功能的调整，以加快开发浦东，振兴上海，服务全国，面向世界。(2)浦东新区是扩大对外开放的主要“窗口”，要大力发展外向型经济，加快把上海建设成为开放型、多功能的现代化国际大城市。(3)浦东新区是城乡发展的一个整体，要按城乡协调发展，综合规划，统筹安排，合理调整城镇体系，使城郊发展成为现代化农业和相应的现代化城镇。(4)开发浦东新区是一个跨世纪工程，要有高起点，新主意，以适应90年代以至21世纪国际大城市发展的需要。(5)浦东新区是长江流域经济地区，特别是长江三角洲地区的一个“龙头”，要从区域经济发展角度出发，服务全国。";
        }

        private void Grid_Map_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string strPATH = di.Parent.Parent.FullName;
            GoogleMapHelper m_GoogleMapHelper = new GoogleMapHelper();
            m_GoogleMapHelper.setMap(1, "31.22924594193164", "121.48104309082031");
            webbrowserContent1.Navigate(new Uri(strPATH + @"/html/GoogleMap.htm"));
        }

        private void Grid_Plan_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
			OverallPlan.IsChecked=true;
		}
        private void OverallPlan_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string strPATH = di.Parent.Parent.FullName;
            webbrowserContent2.Navigate(new Uri(strPATH + @"/Images/总体规划.jpg"));
            tblAnnotation.Text = "总体布局　浦东新区的经济社会发展，预测到2020年，浦东新区经济平均每年以15～20%左右的速度递增。第三产业比重将占65%左右，从而安排金融、贸易、商业服务用地约15平方公里；工业用地约30～40平方公里；科技教育、文化、卫生、体育、行政用地约7平方公里；居住用地约54平方公里；其余尚需大量绿化旷地。总体布局同时考虑了城市历史形成的三条发展轴：一条是以黄浦江、杨高路所夹地带为轴线，呈南北向组团式发展；一条是从陆家嘴金融中心开始，经花木行政中心以至川沙镇、长江口滨江的第二国际航空港，这是上海中心城东西向发展轴的延伸和强化；再一条是长江口右岸的滨江地带，自吴淞口滨江公园，经外高桥港区至第二国际航空港，这是将在21世纪逐步发展的长江口新的临水发展轴。总体布局还结合城市综合交通体系，使城市土地使用功能开发与城市交通密切结合起来，并使浦东新区与浦西地区连成整体，形成中心城的基本框架。浦东新区的龙东路、罗山路通过南浦大桥、杨浦大桥与浦西沟成48公里的内环线，内环内120平方公里是中心城的中心地区(其中浦东约30平方公里)。浦东部分的外环线沿长江口滨江发展，并在外高桥、孙小桥过黄浦江，分别与浦西部分的长江路、长桥外环线相连，外环线长约89公里，外环内占地面积约610平方公里，其中浦东新区部分约260平方公里。";
        }

        private void LandUsePlan_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string strPATH = di.Parent.Parent.FullName;
            webbrowserContent2.Navigate(new Uri(strPATH + @"/Images/土地使用规划.jpg"));
            tblAnnotation.Text = "在《浦东新区综合发展规划》中，提出了《浦东新区土地使用规划》。该规划的指导思想是：按照“控制增量，提高质量，集约利用”的土地使用方针，利用级差效益，盘活存量土地；搞好“三个集中”，实行集约利用；开发滩涂资源，增加土地后备资源。 该规划的主要内容包括规划超时限和范围、不同区位土地使用原则及土地等级的划分和有关土地的技术经济指标等。 该规划的特点是将土地使用规划作为浦东新区综合发展规划的一部分，从全局长远利益出发，对全区土地的开发、整治、利用和保护进行统筹安排，以实现土地资源的可持续利用；对浦东新区规划年（2020年）用地总量及主要用地的结构比例等重要指标进行了说明，对建设用地总量、生态林用地总量及城市发展备用地总量进行了分解。";
        }

        private void IndustrialLayout_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string strPATH = di.Parent.Parent.FullName;
            webbrowserContent2.Navigate(new Uri(strPATH + @"/Images/工业布局规划.jpg"));
            tblAnnotation.Text = "1111、、、、工业总产值工业总产值工业总产值工业总产值    从新区“十一五”经济发展的基本思路、发展方向和重点分析，并结合“十五”工业发展的走势和经验，预计到“十一五”期末，浦东新区的工业总产值为6500亿元左右，年均增长10%左右。 由于浦钢将从2006年起陆续迁出（预计减少产值近100亿元），高桥地区石化产业的调整，同时星火开发区的统计将从2006年起划归奉贤区（预计减少新区工业产值80亿元以上），因此，“十一五”期间工业总产值总体上增长有限，尤其是前2年，在没有大的新项目投产的情况下，增速将较低。 2222、、、、工业增加值工业增加值工业增加值工业增加值    预计到2010年实现工业增加值1660左右，年均增长9%左右；占浦东新区生产总值的比重为45%左右，比“十五”期末降低3个百分点左右。 3333、、、、工业增加值率工业增加值率工业增加值率工业增加值率    目标是经过5年的产业结构调整和产业升级，将工业增加值率从目前的24.5%提高到“十一五”期末的25.5%以上。 三、“十一五”工业发展重点产业及";
        }
		

    }

}
