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

namespace WpfApplication3.Development_performance
{
    /// <summary>
    /// Interaction logic for GreenCampus.xaml
    /// </summary>
    public partial class Society : Page
    {
        public Society()
        {
            InitializeComponent();
        }

        protected void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<TeaInformation> TeaInfo = new List<TeaInformation>
            {
                new TeaInformation
                {
                  title = "GDP（亿元）",
                  number = "54.73"
                },
                new TeaInformation
                {
                  title = "第一产业",
                  number = "924"
                },
                new TeaInformation
                {
                  title = "第二产业",
                  number = "17.57"
                },
                new TeaInformation
                {
                  title = "第三产业",
                  number = ""
                },
                new TeaInformation
                {
                  title = "财政收入（亿元）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "地方财政收入",
                  number = ""
                },
                new TeaInformation
                {
                  title = "地方财政支出（亿元）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "固定资产投资总额（亿元）",
                  number = ""
                },   new TeaInformation
                {
                  title = "房地产开发投资",
                  number = ""
                },
                new TeaInformation
                {
                  title = "城市基础设施投资",
                  number = ""
                },
                new TeaInformation
                {
                  title = "外商直接投资合同项目（项）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "外商直接投资合同金额（亿美元）",
                  number = ""
                },   new TeaInformation
                {
                  title = "期末内资企业注册数（个）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "研发机构数（个）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "申请专利数（项）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "授权专利数（项）",
                  number = ""
                },   new TeaInformation
                {
                  title = "商品销售总额（亿)",
                  number = ""
                },
                new TeaInformation
                {
                  title = "社会消费品零售总额（亿）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "外贸进出口总额（亿美元）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "出口总额（亿美元）",
                  number = ""
                },                      
                  new TeaInformation
                {
                  title = "进口总额（亿美元）",
                  number = ""
                }, 
            };

            Economic.DataContext = TeaInfo;
            Economic.SelectedIndex = 0;
        }







        private void Button_Click(object sender, RoutedEventArgs e)
        {
            shiyu.Visibility = System.Windows.Visibility.Visible;
            xiaqu.Visibility = System.Windows.Visibility.Collapsed;
            sanwei.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            shiyu.Visibility = System.Windows.Visibility.Collapsed;
            xiaqu.Visibility = System.Windows.Visibility.Visible;
            sanwei.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            shiyu.Visibility = System.Windows.Visibility.Collapsed;
            xiaqu.Visibility = System.Windows.Visibility.Collapsed;
            sanwei.Visibility = System.Windows.Visibility.Visible;
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (slider.Value == 0)
            {
                Lable.Text = "GDP:5645 \r\n 财政收入:1243";

                List<TeaInformation> TeaInfo = new List<TeaInformation>
            {
                 new TeaInformation
                {
                  title = "GDP（亿元）",
                  number = "54.73"
                },
                new TeaInformation
                {
                  title = "第一产业",
                  number = "924"
                },
                new TeaInformation
                {
                  title = "第二产业",
                  number = "17.57"
                },
                new TeaInformation
                {
                  title = "第三产业",
                  number = ""
                },
                new TeaInformation
                {
                  title = "财政收入（亿元）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "地方财政收入",
                  number = ""
                },
                new TeaInformation
                {
                  title = "地方财政支出（亿元）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "固定资产投资总额（亿元）",
                  number = ""
                },   new TeaInformation
                {
                  title = "房地产开发投资",
                  number = ""
                },
                new TeaInformation
                {
                  title = "城市基础设施投资",
                  number = ""
                },
                new TeaInformation
                {
                  title = "外商直接投资合同项目（项）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "外商直接投资合同金额（亿美元）",
                  number = ""
                },   new TeaInformation
                {
                  title = "期末内资企业注册数（个）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "研发机构数（个）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "申请专利数（项）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "授权专利数（项）",
                  number = ""
                },   new TeaInformation
                {
                  title = "商品销售总额（亿)",
                  number = ""
                },
                new TeaInformation
                {
                  title = "社会消费品零售总额（亿）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "外贸进出口总额（亿美元）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "出口总额（亿美元）",
                  number = ""
                },                      
                  new TeaInformation
                {
                  title = "进口总额（亿美元）",
                  number = ""
                }, 
            };

                Economic.DataContext = TeaInfo;
                Economic.SelectedIndex = 0;
            }
            if (slider.Value == 1)
            {
                Lable.Text = "GDP:7856 \r\n 财政收入:2243";
                List<TeaInformation> TeaInfo = new List<TeaInformation>
            {
                new TeaInformation
                {
                  title = "GDP（亿元）",
                  number = "54.51"
                },
                new TeaInformation
                {
                  title = "第一产业",
                  number = "693"
                },
                new TeaInformation
                {
                  title = "第二产业",
                  number = "232"
                },
                new TeaInformation
                {
                  title = "第三产业",
                  number = ""
                },
                new TeaInformation
                {
                  title = "财政收入（亿元）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "地方财政收入",
                  number = ""
                },
                new TeaInformation
                {
                  title = "地方财政支出（亿元）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "固定资产投资总额（亿元）",
                  number = ""
                },   new TeaInformation
                {
                  title = "房地产开发投资",
                  number = ""
                },
                new TeaInformation
                {
                  title = "城市基础设施投资",
                  number = ""
                },
                new TeaInformation
                {
                  title = "外商直接投资合同项目（项）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "外商直接投资合同金额（亿美元）",
                  number = ""
                },   new TeaInformation
                {
                  title = "期末内资企业注册数（个）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "研发机构数（个）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "申请专利数（项）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "授权专利数（项）",
                  number = ""
                },   new TeaInformation
                {
                  title = "商品销售总额（亿)",
                  number = ""
                },
                new TeaInformation
                {
                  title = "社会消费品零售总额（亿）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "外贸进出口总额（亿美元）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "出口总额（亿美元）",
                  number = ""
                },                      
                  new TeaInformation
                {
                  title = "进口总额（亿美元）",
                  number = ""
                }, 
            };

                Economic.DataContext = TeaInfo;
                Economic.SelectedIndex = 0;
            }
            if (slider.Value == 2)
            {
              
                List<TeaInformation> TeaInfo = new List<TeaInformation>
            {
                new TeaInformation
                {
                  title = "GDP（亿元）",
                  number = "64.3"
                },
                new TeaInformation
                {
                  title = "第一产业",
                  number = "56.2"
                },
                new TeaInformation
                {
                  title = "第二产业",
                  number = "78.5"
                },
                new TeaInformation
                {
                  title = "第三产业",
                  number = ""
                },
                new TeaInformation
                {
                  title = "财政收入（亿元）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "地方财政收入",
                  number = ""
                },
                new TeaInformation
                {
                  title = "地方财政支出（亿元）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "固定资产投资总额（亿元）",
                  number = ""
                },   new TeaInformation
                {
                  title = "房地产开发投资",
                  number = ""
                },
                new TeaInformation
                {
                  title = "城市基础设施投资",
                  number = ""
                },
                new TeaInformation
                {
                  title = "外商直接投资合同项目（项）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "外商直接投资合同金额（亿美元）",
                  number = ""
                },   new TeaInformation
                {
                  title = "期末内资企业注册数（个）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "研发机构数（个）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "申请专利数（项）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "授权专利数（项）",
                  number = ""
                },   new TeaInformation
                {
                  title = "商品销售总额（亿)",
                  number = ""
                },
                new TeaInformation
                {
                  title = "社会消费品零售总额（亿）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "外贸进出口总额（亿美元）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "出口总额（亿美元）",
                  number = ""
                },                      
                  new TeaInformation
                {
                  title = "进口总额（亿美元）",
                  number = ""
                }, 
            };

               
            }
            if (slider.Value == 3)
            {
                Lable.Text = "GDP:7944 \r\n 财政收入:3965";
                List<TeaInformation> TeaInfo = new List<TeaInformation>
            {
                new TeaInformation
                {
                  title = "GDP（亿元）",
                  number = "56.2"
                },
                new TeaInformation
                {
                  title = "第一产业",
                  number = "78.23"
                },
                new TeaInformation
                {
                  title = "第二产业",
                  number = "33.26"
                },
                new TeaInformation
                {
                  title = "第三产业",
                  number = ""
                },
                new TeaInformation
                {
                  title = "财政收入（亿元）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "地方财政收入",
                  number = ""
                },
                new TeaInformation
                {
                  title = "地方财政支出（亿元）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "固定资产投资总额（亿元）",
                  number = ""
                },   new TeaInformation
                {
                  title = "房地产开发投资",
                  number = ""
                },
                new TeaInformation
                {
                  title = "城市基础设施投资",
                  number = ""
                },
                new TeaInformation
                {
                  title = "外商直接投资合同项目（项）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "外商直接投资合同金额（亿美元）",
                  number = ""
                },   new TeaInformation
                {
                  title = "期末内资企业注册数（个）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "研发机构数（个）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "申请专利数（项）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "授权专利数（项）",
                  number = ""
                },   new TeaInformation
                {
                  title = "商品销售总额（亿)",
                  number = ""
                },
                new TeaInformation
                {
                  title = "社会消费品零售总额（亿）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "外贸进出口总额（亿美元）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "出口总额（亿美元）",
                  number = ""
                },                      
                  new TeaInformation
                {
                  title = "进口总额（亿美元）",
                  number = ""
                }, 
            };

                Economic.DataContext = TeaInfo;
                Economic.SelectedIndex = 0;
            }
            if (slider.Value == 4)
            {
                Lable.Text = "GDP:9877 \r\n 财政收入:4023";
                List<TeaInformation> TeaInfo = new List<TeaInformation>
            {
                new TeaInformation
                {
                  title = "GDP（亿元）",
                  number = "456"
                },
                new TeaInformation
                {
                  title = "第一产业",
                  number = "32.2"
                },
                new TeaInformation
                {
                  title = "第二产业",
                  number = "45.25"
                },
                new TeaInformation
                {
                  title = "第三产业",
                  number = "56.2"
                },
                new TeaInformation
                {
                  title = "财政收入（亿元）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "地方财政收入",
                  number = ""
                },
                new TeaInformation
                {
                  title = "地方财政支出（亿元）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "固定资产投资总额（亿元）",
                  number = ""
                },   new TeaInformation
                {
                  title = "房地产开发投资",
                  number = ""
                },
                new TeaInformation
                {
                  title = "城市基础设施投资",
                  number = ""
                },
                new TeaInformation
                {
                  title = "外商直接投资合同项目（项）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "外商直接投资合同金额（亿美元）",
                  number = ""
                },   new TeaInformation
                {
                  title = "期末内资企业注册数（个）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "研发机构数（个）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "申请专利数（项）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "授权专利数（项）",
                  number = ""
                },   new TeaInformation
                {
                  title = "商品销售总额（亿)",
                  number = ""
                },
                new TeaInformation
                {
                  title = "社会消费品零售总额（亿）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "外贸进出口总额（亿美元）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "出口总额（亿美元）",
                  number = ""
                },                      
                  new TeaInformation
                {
                  title = "进口总额（亿美元）",
                  number = ""
                }, 
            };

                Economic.DataContext = TeaInfo;
                Economic.SelectedIndex = 0;
            }
        }
        public class TeaInformation
        {
            public string title { get; set; }
            public string number { get; set; }

        }

    }
}
