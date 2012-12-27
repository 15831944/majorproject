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

        private double[] jindutiao = { 0.911, 0.8, 0.7, 0.75, 0.5, 0.6, 0.3 , 0.8,  0.3 ,0.7, 0.75, 0.5, 0.6};

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

//            Yusuanbili.Source = new BitmapImage(new Uri("/Images/yusuan.png", UriKind.Relative));
//            Zhichubili.Source = new BitmapImage(new Uri("/Images/zhichu.png", UriKind.Relative));

            double[] upperWidth={rectangle0.ActualWidth,
			 rectangle2_Copy.ActualWidth,
		 rectangle3_Copy.ActualWidth,
			rectangle4_Copy.ActualWidth,
			rectangle5_Copy.ActualWidth,
			rectangle6_Copy.ActualWidth,
			rectangle7_Copy.ActualWidth,
			rectangle2_Copy1.ActualWidth,
		 rectangle3_Copy1.ActualWidth,
			rectangle4_Copy1.ActualWidth,
			rectangle5_Copy1.ActualWidth,
			rectangle6_Copy1.ActualWidth,
			rectangle7_Copy1.ActualWidth};
			
            rectangle0.Name = "rectangle0";
            rectangle1.Name = "rectangle1";
            rectangle2.Name = "rectangle2";
     
            rectangle3.Name = "rectangle3";
            rectangle4.Name = "rectangle4";
            rectangle5.Name = "rectangle5";
            rectangle6.Name = "rectangle6";
            rectangle7.Name = "rectangle7";
 			label1.Content=(jindutiao[1]*100)+"%";
 			label2.Content=(jindutiao[2]*100)+"%";
 			label3.Content=(jindutiao[3]*100)+"%";
 			label4.Content=(jindutiao[4]*100)+"%";
 			label5.Content=(jindutiao[5]*100)+"%";
 			label6.Content=(jindutiao[6]*100)+"%";
 			label1_Copy.Content=(jindutiao[7]*100)+"%";
 			label2_Copy.Content=(jindutiao[8]*100)+"%";
 			label3_Copy.Content=(jindutiao[9]*100)+"%";
 			label4_Copy.Content=(jindutiao[10]*100)+"%";
 			label5_Copy.Content=(jindutiao[11]*100)+"%";
 			label6_Copy.Content=(jindutiao[12]*100)+"%";
			

			
			for (int i = 0; i < 13; i++)
            {
                DoubleAnimation myDoubleAnimation = new DoubleAnimation();
                myDoubleAnimation.From = 0;
                myDoubleAnimation.To = jindutiao[i]*upperWidth[i];
                myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));

                Storyboard.SetTargetName(myDoubleAnimation, "rectangle" + (i+1));

                Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.WidthProperty));
                Storyboard myStoryboard = new Storyboard();
                myStoryboard.Children.Add(myDoubleAnimation);
                myStoryboard.AutoReverse = false;
                myStoryboard.Begin(this);
            }
		
              

        }
    }
}
