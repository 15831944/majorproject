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
using System.Windows.Media.Animation;

namespace WpfApplication3.ResourcesAndManpower
{
    /// <summary>
    /// Interaction logic for PageFinacialReource.xaml
    /// </summary>
    public partial class PageFinacialReource : Page
    {
        public PageFinacialReource()
        {
            InitializeComponent();
        }
        private double caizhengyusuan = 0.8;
        private double caizhengzhichu = 0.7;

        private double jileiyusuan = 0.8;
        private double jileizhichu = 0.7;

        private double gonggongyusuan = 0.75;
        private double gongongzhichu = 0.5;

        private double zhuanyiyusuan = 0.6;
        private double zhuanyizhichu = 0.3;

        private double[] jindutiao = { 0.8, 0.7, 0.8, 0.7, 0.75, 0.5, 0.6, 0.3 };

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            Yusuanbili.Source = new BitmapImage(new Uri("/Images/yusuan.png", UriKind.Relative));
            Zhichubili.Source = new BitmapImage(new Uri("/Images/zhichu.png", UriKind.Relative));

            double upperWidth = Xueshubumen.ActualWidth;
            double downWidth = Qizhong.ActualWidth * 0.7;


            rectangle0.Name = "rectangle0";
            rectangle1.Name = "rectangle1";
            rectangle2.Name = "rectangle2";
     
            rectangle3.Name = "rectangle3";
            rectangle4.Name = "rectangle4";
            rectangle5.Name = "rectangle5";
            rectangle6.Name = "rectangle6";
            rectangle7.Name = "rectangle7";
 

            for (int i = 0; i < 8; i++)
            {
                DoubleAnimation myDoubleAnimation = new DoubleAnimation();
                myDoubleAnimation.From = 0;
                if(i<=1)
                    myDoubleAnimation.To = jindutiao[i]*upperWidth;
                else
                    myDoubleAnimation.To = jindutiao[i] * downWidth;
                myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));

                Storyboard.SetTargetName(myDoubleAnimation, "rectangle" + i);

                Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.WidthProperty));
                Storyboard myStoryboard = new Storyboard();
                myStoryboard.Children.Add(myDoubleAnimation);
                myStoryboard.AutoReverse = false;
                myStoryboard.Begin(this);
            }

              

        }
    }
}
