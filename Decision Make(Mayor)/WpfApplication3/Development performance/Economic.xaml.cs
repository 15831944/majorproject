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
    public partial class Economic : Page
    {
        public Economic()
        {
            InitializeComponent();
        }

        protected void Page_Loaded(object sender, RoutedEventArgs e)
        {
            llable.Text = "GDP:6145 \r\n财政收入:3247";
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
                  number = "453"
                },
                new TeaInformation
                {
                  title = "财政收入（亿元）",
                  number = "5435"
                },
                new TeaInformation
                {
                  title = "地方财政收入",
                  number = "654"
                },
                new TeaInformation
                {
                  title = "地方财政支出（亿元）",
                  number = "9823"
                },
                new TeaInformation
                {
                  title = "固定资产投资总额（亿元）",
                  number = "324"
                },   new TeaInformation
                {
                  title = "房地产开发投资",
                  number = "6464"
                },
                new TeaInformation
                {
                  title = "城市基础设施投资",
                  number = "423"
                },
                new TeaInformation
                {
                  title = "外商直接投资合同项目（项）",
                  number = "43634"
                },
                new TeaInformation
                {
                  title = "外商直接投资合同金额（亿美元）",
                  number = "8677"
                },   new TeaInformation
                {
                  title = "期末内资企业注册数（个）",
                  number = "2234"
                },
                new TeaInformation
                {
                  title = "研发机构数（个）",
                  number = "876"
                },
                new TeaInformation
                {
                  title = "申请专利数（项）",
                  number = "4556"
                },
                new TeaInformation
                {
                  title = "授权专利数（项）",
                  number = "1333"
                },   new TeaInformation
                {
                  title = "商品销售总额（亿)",
                  number = "45445"
                },
                new TeaInformation
                {
                  title = "社会消费品零售总额（亿）",
                  number = "656"
                },
                new TeaInformation
                {
                  title = "外贸进出口总额（亿美元）",
                  number = "56"
                },
                new TeaInformation
                {
                  title = "出口总额（亿美元）",
                  number = "655"
                },                      
                  new TeaInformation
                {
                  title = "进口总额（亿美元）",
                  number = "3434"
                }, 
            };

            economic.DataContext = TeaInfo;
            economic.SelectedIndex = 0;
        }
        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (slider.Value == 0) 
            {
                llable.Text = "GDP:5645 \r\n财政收入:1243";

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
                  number = "5465"
                },
                new TeaInformation
                {
                  title = "财政收入（亿元）",
                  number = "767"
                },
                new TeaInformation
                {
                  title = "地方财政收入",
                  number = "3432"
                },
                new TeaInformation
                {
                  title = "地方财政支出（亿元）",
                  number = "2332"
                },
                new TeaInformation
                {
                  title = "固定资产投资总额（亿元）",
                  number = "5465"
                },   new TeaInformation
                {
                  title = "房地产开发投资",
                  number = "6757"
                },
                new TeaInformation
                {
                  title = "城市基础设施投资",
                  number = "6576"
                },
                new TeaInformation
                {
                  title = "外商直接投资合同项目（项）",
                  number = "245666"
                },
                new TeaInformation
                {
                  title = "外商直接投资合同金额（亿美元）",
                  number = "6456"
                },   new TeaInformation
                {
                  title = "期末内资企业注册数（个）",
                  number = "675"
                },
                new TeaInformation
                {
                  title = "研发机构数（个）",
                  number = "675"
                },
                new TeaInformation
                {
                  title = "申请专利数（项）",
                  number = "7653"
                },
                new TeaInformation
                {
                  title = "授权专利数（项）",
                  number = "6757"
                },   new TeaInformation
                {
                  title = "商品销售总额（亿)",
                  number = "242"
                },
                new TeaInformation
                {
                  title = "社会消费品零售总额（亿）",
                  number = "22"
                },
                new TeaInformation
                {
                  title = "外贸进出口总额（亿美元）",
                  number = "24"
                },
                new TeaInformation
                {
                  title = "出口总额（亿美元）",
                  number = "24"
                },                      
                  new TeaInformation
                {
                  title = "进口总额（亿美元）",
                  number = "56"
                }, 
            };

                economic.DataContext = TeaInfo;
                economic.SelectedIndex = 0;
            }
            if (slider.Value == 1) 
            {
                llable.Text = "GDP:7856 \r\n财政收入:2243";
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
                  number = "656"
                },
                new TeaInformation
                {
                  title = "财政收入（亿元）",
                  number = "865"
                },
                new TeaInformation
                {
                  title = "地方财政收入",
                  number = "765"
                },
                new TeaInformation
                {
                  title = "地方财政支出（亿元）",
                  number = "765"
                },
                new TeaInformation
                {
                  title = "固定资产投资总额（亿元）",
                  number = "4724"
                },   new TeaInformation
                {
                  title = "房地产开发投资",
                  number = "2467"
                },
                new TeaInformation
                {
                  title = "城市基础设施投资",
                  number = "247"
                },
                new TeaInformation
                {
                  title = "外商直接投资合同项目（项）",
                  number = "72"
                },
                new TeaInformation
                {
                  title = "外商直接投资合同金额（亿美元）",
                  number = "742"
                },   new TeaInformation
                {
                  title = "期末内资企业注册数（个）",
                  number = "87"
                },
                new TeaInformation
                {
                  title = "研发机构数（个）",
                  number = "675"
                },
                new TeaInformation
                {
                  title = "申请专利数（项）",
                  number = "765"
                },
                new TeaInformation
                {
                  title = "授权专利数（项）",
                  number = "763"
                },   new TeaInformation
                {
                  title = "商品销售总额（亿)",
                  number = "7373"
                },
                new TeaInformation
                {
                  title = "社会消费品零售总额（亿）",
                  number = "7563"
                },
                new TeaInformation
                {
                  title = "外贸进出口总额（亿美元）",
                  number = "735"
                },
                new TeaInformation
                {
                  title = "出口总额（亿美元）",
                  number = "8768"
                },                      
                  new TeaInformation
                {
                  title = "进口总额（亿美元）",
                  number = "58"
                }, 
            };

                economic.DataContext = TeaInfo;
                economic.SelectedIndex = 0;
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
                  number = "375"
                },
                new TeaInformation
                {
                  title = "财政收入（亿元）",
                  number = "875"
                },
                new TeaInformation
                {
                  title = "地方财政收入",
                  number = "2657"
                },
                new TeaInformation
                {
                  title = "地方财政支出（亿元）",
                  number = "72"
                },
                new TeaInformation
                {
                  title = "固定资产投资总额（亿元）",
                  number = "24"
                },   new TeaInformation
                {
                  title = "房地产开发投资",
                  number = "87"
                },
                new TeaInformation
                {
                  title = "城市基础设施投资",
                  number = "68"
                },
                new TeaInformation
                {
                  title = "外商直接投资合同项目（项）",
                  number = "635"
                },
                new TeaInformation
                {
                  title = "外商直接投资合同金额（亿美元）",
                  number = "865"
                },   new TeaInformation
                {
                  title = "期末内资企业注册数（个）",
                  number = "976"
                },
                new TeaInformation
                {
                  title = "研发机构数（个）",
                  number = "34"
                },
                new TeaInformation
                {
                  title = "申请专利数（项）",
                  number = "765"
                },
                new TeaInformation
                {
                  title = "授权专利数（项）",
                  number = "657"
                },   new TeaInformation
                {
                  title = "商品销售总额（亿)",
                  number = "765"
                },
                new TeaInformation
                {
                  title = "社会消费品零售总额（亿）",
                  number = "657"
                },
                new TeaInformation
                {
                  title = "外贸进出口总额（亿美元）",
                  number = "67"
                },
                new TeaInformation
                {
                  title = "出口总额（亿美元）",
                  number = "876"
                },                      
                  new TeaInformation
                {
                  title = "进口总额（亿美元）",
                  number = "876"
                }, 
            };

           
            }
            if (slider.Value == 3)
            {
                llable.Text = "GDP:7944 \r\n财政收入:3965";
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
                  number = "654"
                },
                new TeaInformation
                {
                  title = "财政收入（亿元）",
                  number = "767"
                },
                new TeaInformation
                {
                  title = "地方财政收入",
                  number = "767"
                },
                new TeaInformation
                {
                  title = "地方财政支出（亿元）",
                  number = "456"
                },
                new TeaInformation
                {
                  title = "固定资产投资总额（亿元）",
                  number = "5426"
                },   new TeaInformation
                {
                  title = "房地产开发投资",
                  number = "624"
                },
                new TeaInformation
                {
                  title = "城市基础设施投资",
                  number = "624"
                },
                new TeaInformation
                {
                  title = "外商直接投资合同项目（项）",
                  number = "76"
                },
                new TeaInformation
                {
                  title = "外商直接投资合同金额（亿美元）",
                  number = "767"
                },   new TeaInformation
                {
                  title = "期末内资企业注册数（个）",
                  number = "31"
                },
                new TeaInformation
                {
                  title = "研发机构数（个）",
                  number = "3431"
                },
                new TeaInformation
                {
                  title = "申请专利数（项）",
                  number = "3434"
                },
                new TeaInformation
                {
                  title = "授权专利数（项）",
                  number = "7654"
                },   new TeaInformation
                {
                  title = "商品销售总额（亿)",
                  number = "546"
                },
                new TeaInformation
                {
                  title = "社会消费品零售总额（亿）",
                  number = "654"
                },
                new TeaInformation
                {
                  title = "外贸进出口总额（亿美元）",
                  number = "6546"
                },
                new TeaInformation
                {
                  title = "出口总额（亿美元）",
                  number = "6546"
                },                      
                  new TeaInformation
                {
                  title = "进口总额（亿美元）",
                  number = "6546"
                }, 
            };

                economic.DataContext = TeaInfo;
                economic.SelectedIndex = 0;
            }
            if (slider.Value == 4) 
            {
                llable.Text = "GDP:9877 \r\n财政收入:4023";
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
                  number = "642"
                },
                new TeaInformation
                {
                  title = "地方财政收入",
                  number = "64"
                },
                new TeaInformation
                {
                  title = "地方财政支出（亿元）",
                  number = "987"
                },
                new TeaInformation
                {
                  title = "固定资产投资总额（亿元）",
                  number = "9860"
                },   new TeaInformation
                {
                  title = "房地产开发投资",
                  number = "559"
                },
                new TeaInformation
                {
                  title = "城市基础设施投资",
                  number = "78"
                },
                new TeaInformation
                {
                  title = "外商直接投资合同项目（项）",
                  number = "735"
                },
                new TeaInformation
                {
                  title = "外商直接投资合同金额（亿美元）",
                  number = "735"
                },   new TeaInformation
                {
                  title = "期末内资企业注册数（个）",
                  number = "264"
                },
                new TeaInformation
                {
                  title = "研发机构数（个）",
                  number = "6524"
                },
                new TeaInformation
                {
                  title = "申请专利数（项）",
                  number = "62"
                },
                new TeaInformation
                {
                  title = "授权专利数（项）",
                  number = "62"
                },   new TeaInformation
                {
                  title = "商品销售总额（亿)",
                  number = "26"
                },
                new TeaInformation
                {
                  title = "社会消费品零售总额（亿）",
                  number = "64"
                },
                new TeaInformation
                {
                  title = "外贸进出口总额（亿美元）",
                  number = "64"
                },
                new TeaInformation
                {
                  title = "出口总额（亿美元）",
                  number = "64"
                },                      
                  new TeaInformation
                {
                  title = "进口总额（亿美元）",
                  number = "65446"
                }, 
            };

                economic.DataContext = TeaInfo;
                economic.SelectedIndex = 0;
            }
        }
        public class TeaInformation
        {
            public string title { get; set; }
            public string number { get; set; }

        }

    }
}
