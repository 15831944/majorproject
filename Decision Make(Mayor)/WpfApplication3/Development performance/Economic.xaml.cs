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
using Visifire.Charts;
using WpfApplication3.CreateChart;

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


            //ChartInformationPreparation-----------------------------------------------------------------------------------------
            //柱状图
            ciEconomic0 = new ChartInformation()
            {
                m_BorderThickness = new Thickness(1.0),
                m_Theme = "Theme1",
                m_View3D = true,
                m_axisXTitle = "经济指标",
                m_axisYTitle = "数值",
                m_axisYMaximum = 6000,
                m_axisYInterval = 1000,
                dsc = new DataSeriesCollection()
                    {
                        new DataSeries()
                        {
                            LegendText = "\"十五\"期末",
                            RenderAs = RenderAs.Column,
                            AxisYType = AxisTypes.Primary,
                            DataPoints = new DataPointCollection()
                            {
                                new DataPoint()
                                {
                                    AxisXLabel = "金融市场交易总额(万亿美元)",
                                    YValue = 25,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "港口集装箱吞吐量(万标准箱)",
                                    YValue = 1800,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "关区进出口总额(亿美元)",
                                    YValue = 3500,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "服务贸易总额(亿美元)",
                                    YValue = 325,
                                },
                            }
                        },
                        new DataSeries()
                        {
                            LegendText = "\"十一五\"期末(预计)",
                            RenderAs = RenderAs.Column,
                            AxisYType = AxisTypes.Primary,
                            DataPoints = new DataPointCollection()
                            {
                                new DataPoint()
                                {
                                    AxisXLabel = "金融市场交易总额(万亿美元)",
                                    YValue = 380,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "港口集装箱吞吐量(万标准箱)",
                                    YValue = 2900,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "关区进出口总额(亿美元)",
                                    YValue = 6800,
                                },
                                new DataPoint()
                                {
                                    AxisXLabel = "服务贸易总额(亿美元)",
                                    YValue = 1000,
                                },
                            }
                        },
                    },
            };

            //折线图
            ciEconomic1 = new ChartInformation()
            {
                m_BorderThickness = new Thickness(1.0),
                m_Theme = "Theme1",
                m_View3D = true,
                m_axisXTitle = "时间",
                m_axisYTitle = "数值",
                m_axisYMaximum = 1000000,
                m_axisYInterval = 250000,
                dsc = new DataSeriesCollection()
            };
            //净迁移率
            ds1 = new DataSeries()
            {
                LegendText = "净迁移率",
                RenderAs = RenderAs.Line,
                AxisYType = AxisTypes.Primary,
                DataPoints = new DataPointCollection()
                {
                    new DataPoint()
                    {
                    AxisXLabel = "Jul 07",
                    YValue = 900000,
                    },
                    new DataPoint()
                    {
                        AxisXLabel = "Aug 07",
                        YValue = 800000,
                    },
                    new DataPoint()
                    {
                        AxisXLabel = "Sep 07",
                        YValue = 700000,
                    },
                    new DataPoint()
                    {
                        AxisXLabel = "Nov 07",
                        YValue = 800000,
                    },
                    new DataPoint()
                    {
                        AxisXLabel = "Jan 08",
                        YValue = 600000,
                    },
                    new DataPoint()
                    {
                        AxisXLabel = "Feb 08",
                        YValue = 1000000,
                    },
                }
            };
            //千人拥有病床数
            ds2 = new DataSeries()
            {
                LegendText = "千人拥有病床数",
                RenderAs = RenderAs.Line,
                AxisYType = AxisTypes.Primary,
                DataPoints = new DataPointCollection()
                {
                    new DataPoint()
                    {
                        AxisXLabel = "Jul 07",
                        YValue = 700000,
                    },
                    new DataPoint()
                    {
                        AxisXLabel = "Aug 07",
                        YValue = 900000,
                    },
                    new DataPoint()
                    {
                        AxisXLabel = "Sep 07",
                        YValue = 600000,
                    },
                    new DataPoint()
                    {
                        AxisXLabel = "Nov 07",
                        YValue = 500000,
                    },
                    new DataPoint()
                    {
                        AxisXLabel = "Jan 08",
                        YValue = 800000,
                    },
                    new DataPoint()
                    {
                        AxisXLabel = "Feb 08",
                        YValue = 700000,
                    },
                }
            };
            //人均住房使用面积
            ds3 = new DataSeries()
            {
                LegendText = "人均住房使用面积",
                RenderAs = RenderAs.Line,
                AxisYType = AxisTypes.Primary,
                DataPoints = new DataPointCollection()
                {
                    new DataPoint()
                    {
                        AxisXLabel = "Jul 07",
                        YValue = 400000,
                    },
                    new DataPoint()
                    {
                        AxisXLabel = "Aug 07",
                        YValue = 600000,
                    },
                    new DataPoint()
                    {
                        AxisXLabel = "Sep 07",
                        YValue = 300000,
                    },
                    new DataPoint()
                    {
                        AxisXLabel = "Nov 07",
                        YValue = 200000,
                    },
                    new DataPoint()
                    {
                        AxisXLabel = "Jan 08",
                        YValue = 500000,
                    },
                    new DataPoint()
                    {
                        AxisXLabel = "Feb 08",
                        YValue = 400000,
                    },
                }
            };
            //普通中学人数比重
            ds4 = new DataSeries()
            {
                LegendText = "普通中学人数比重",
                RenderAs = RenderAs.Line,
                AxisYType = AxisTypes.Primary,
                DataPoints = new DataPointCollection()
                {
                    new DataPoint()
                    {
                        AxisXLabel = "Jul 07",
                        YValue = 500000,
                    },
                    new DataPoint()
                    {
                        AxisXLabel = "Aug 07",
                        YValue = 500000,
                    },
                    new DataPoint()
                    {
                        AxisXLabel = "Sep 07",
                        YValue = 100000,
                    },
                    new DataPoint()
                    {
                        AxisXLabel = "Nov 07",
                        YValue = 500000,
                    },
                    new DataPoint()
                    {
                        AxisXLabel = "Jan 08",
                        YValue = 700000,
                    },
                    new DataPoint()
                    {
                        AxisXLabel = "Feb 08",
                        YValue = 800000,
                    },
                }
            };

            //--------------------------------------------------------------------------------------------

            listGraphItems = new List<listboxitemGraph>();
            listGraphItems.Add(new listboxitemGraph() { index = 0, lblContent = "净迁移率" });
            lbxGraph.ItemsSource = listGraphItems;

            ChartHelper ch = new ChartHelper();
            ciEconomic1.dsc.Clear();
            ciEconomic1.dsc.Add(ds1);
            Chart m_chart = ch.CreateChart(ciEconomic1);
            gridRightTopContent.Children.Add(m_chart);

            m_chart = ch.CreateChart(ciEconomic0);
            gridRightMiddleContent.Children.Add(m_chart);

            gridGraph.Visibility = System.Windows.Visibility.Hidden;
            gridMap.Visibility = System.Windows.Visibility.Visible;
        }

        ChartInformation ciEconomic0;
        ChartInformation ciEconomic1;
        DataSeries ds1;
        DataSeries ds2;
        DataSeries ds3;
        DataSeries ds4;

        public class listboxitemGraph
        {
            public int index{get;set;}
            public string lblContent { get; set; }
        }
        List<listboxitemGraph> listGraphItems;

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
            Slider slider = (Slider)sender;
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

        private void gridRightTop_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (lblRightTopTitle.Content.ToString()=="折线图")
                {
                    lblRightTopTitle.Content = "城市图";
                    gridGraph.Visibility = System.Windows.Visibility.Visible;
                    gridMap.Visibility = System.Windows.Visibility.Hidden;
                    gridRightTopContent.Children.Clear();
                    ChartHelper ch = new ChartHelper();
                    Chart m_chart = ch.CreateChart(ciEconomic1);
                    gridGraphContent.Children.Clear();
                    gridGraphContent.Children.Add(m_chart);
                }
                else if (lblRightTopTitle.Content.ToString()=="城市图")
                {
                    lblRightTopTitle.Content = "折线图";
                    gridGraph.Visibility = System.Windows.Visibility.Hidden;
                    gridMap.Visibility = System.Windows.Visibility.Visible;
                    ChartHelper ch = new ChartHelper();
                    Chart m_chart = ch.CreateChart(ciEconomic1);
                    gridRightTopContent.Children.Clear();
                    gridRightTopContent.Children.Add(m_chart);
                }
            }
        }

        private void refreshGraphAndListBox()
        {
            ciEconomic1.dsc.Clear();
            for (int i = 0; i < listGraphItems.Count; i++)
            {
                if (listGraphItems[i].index == 0)
                    ciEconomic1.dsc.Add(ds1);
                else if (listGraphItems[i].index == 1)
                    ciEconomic1.dsc.Add(ds2);
                else if (listGraphItems[i].index == 2)
                    ciEconomic1.dsc.Add(ds3);
                else if (listGraphItems[i].index == 3)
                    ciEconomic1.dsc.Add(ds4);
            }
            ChartHelper ch = new ChartHelper();
            Chart m_chart = ch.CreateChart(ciEconomic1);
            gridGraphContent.Children.Clear();
            gridGraphContent.Children.Add(m_chart);

            lbxGraph.ItemsSource = null;
            lbxGraph.ItemsSource = listGraphItems;
        }

        private void btnBrokenLine1_Click(object sender, RoutedEventArgs e)
        {
            foreach (listboxitemGraph item in listGraphItems)
            {
                if (item.index == 0)
                    return;
            }
            listGraphItems.Add(new listboxitemGraph() { index = 0, lblContent = "净迁移率" });
            lbxGraph.ItemsSource = listGraphItems;

            refreshGraphAndListBox();

        }

        private void btnBrokenLine2_Click(object sender, RoutedEventArgs e)
        {
            foreach (listboxitemGraph item in listGraphItems)
            {
                if (item.index == 1)
                    return;
            }
            listGraphItems.Add(new listboxitemGraph() { index = 1, lblContent = "千人拥有病床数" });
            lbxGraph.ItemsSource = listGraphItems;
            refreshGraphAndListBox();
        }

        private void btnBrokenLine3_Click(object sender, RoutedEventArgs e)
        {
            foreach (listboxitemGraph item in listGraphItems)
            {
                if (item.index == 2)
                    return;
            }
            listGraphItems.Add(new listboxitemGraph() { index = 2, lblContent = "人均住房使用面积" });
            lbxGraph.ItemsSource = listGraphItems;

            refreshGraphAndListBox();
        }

        private void btnBrokenLine4_Click(object sender, RoutedEventArgs e)
        {
            foreach (listboxitemGraph item in listGraphItems)
            {
                if (item.index == 3)
                    return;
            }
            listGraphItems.Add(new listboxitemGraph() { index = 3, lblContent = "普通中学人数比重" });
            lbxGraph.ItemsSource = listGraphItems;

            refreshGraphAndListBox();
        }

        private void btnGraphClear_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            int i = Convert.ToInt32(btn.Tag);
            foreach (listboxitemGraph item in listGraphItems)
            {
                if (item.index == i)
                {
                    listGraphItems.Remove(item);
                    break;
                }
            }
            refreshGraphAndListBox();
        }

        private void btnGraphSelectAll_Click(object sender, RoutedEventArgs e)
        {
            listGraphItems.Clear();
            listGraphItems.Add(new listboxitemGraph() { index = 0, lblContent = "净迁移率" });
            listGraphItems.Add(new listboxitemGraph() { index = 1, lblContent = "千人拥有病床数" });
            listGraphItems.Add(new listboxitemGraph() { index = 2, lblContent = "人均住房使用面积" });
            listGraphItems.Add(new listboxitemGraph() { index = 3, lblContent = "普通中学人数比重" });
            refreshGraphAndListBox();
        }

        private void btnGraphClearAll_Click(object sender, RoutedEventArgs e)
        {
            listGraphItems.Clear();
            refreshGraphAndListBox();
        }

    }
}
