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
    public partial class Environment : Page
    {
        public Environment()
        {
            InitializeComponent();
        }

        protected void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<TeaInformation> TeaInfo = new List<TeaInformation>
            {
                new TeaInformation
                {
                  title = "建成区绿化覆盖率（%）",
                  number = "54.73"
                },
                new TeaInformation
                {
                  title = "园林绿地面积（万平方米）",
                  number = "924"
                },
                new TeaInformation
                {
                  title = "人均公共绿地（㎡）",
                  number = "17.57"
                },
                new TeaInformation
                {
                  title = "工业固体废物产生量（万吨/年）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "工业废水排放量（万吨/年）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "工业废气排放总量（亿立方米/年）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "城镇污水纳管率（%）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "空气质量优良率（%）",
                  number = ""
                },  
                new TeaInformation
                {
                  title = "清运垃圾（万吨）",
                  number = ""
                },
                new TeaInformation
                {
                  title = "垃圾焚烧（万吨）",
                  number = ""
                },
          
            };

            Economic.DataContext = TeaInfo;
            Economic.SelectedIndex = 0;
			Lable.Text="GDP:4785  \r\n财政收入：1324";
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
                  title = "建成区绿化覆盖率（%）",
                  number = "54.73"
                },
                new TeaInformation
                {
                  title = "园林绿地面积（万平方米）",
                  number = "924"
                },
                new TeaInformation
                {
                  title = "人均公共绿地（㎡）",
                  number = "17.57"
                },
                new TeaInformation
                {
                  title = "工业固体废物产生量（万吨/年）",
                  number = "4565"
                },
                new TeaInformation
                {
                  title = "工业废水排放量（万吨/年）",
                  number = "4145"
                },
                new TeaInformation
                {
                  title = "工业废气排放总量（亿立方米/年）",
                  number = "2541"
                },
                new TeaInformation
                {
                  title = "城镇污水纳管率（%）",
                  number = "265"
                },
                new TeaInformation
                {
                  title = "空气质量优良率（%）",
                  number = "482"
                },  
                new TeaInformation
                {
                  title = "清运垃圾（万吨）",
                  number = "3546"
                },
                new TeaInformation
                {
                  title = "垃圾焚烧（万吨）",
                  number = "5465"
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
                  title = "建成区绿化覆盖率（%）",
                  number = "77.87"
                },
                new TeaInformation
                {
                  title = "园林绿地面积（万平方米）",
                  number = "714"
                },
                new TeaInformation
                {
                  title = "人均公共绿地（㎡）",
                  number = "23.11"
                },
                new TeaInformation
                {
                  title = "工业固体废物产生量（万吨/年）",
                  number = "4521"
                },
                new TeaInformation
                {
                  title = "工业废水排放量（万吨/年）",
                  number = "332"
                },
                new TeaInformation
                {
                  title = "工业废气排放总量（亿立方米/年）",
                  number = "454"
                },
                new TeaInformation
                {
                  title = "城镇污水纳管率（%）",
                  number = "455"
                },
                new TeaInformation
                {
                  title = "空气质量优良率（%）",
                  number = "442"
                },  
                new TeaInformation
                {
                  title = "清运垃圾（万吨）",
                  number = "544"
                },
                new TeaInformation
                {
                  title = "垃圾焚烧（万吨）",
                  number = "4523"
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
                  title = "建成区绿化覆盖率（%）",
                  number = "33.57"
                },
                new TeaInformation
                {
                  title = "园林绿地面积（万平方米）",
                  number = "4521"
                },
                new TeaInformation
                {
                  title = "人均公共绿地（㎡）",
                  number = "765"
                },
                new TeaInformation
                {
                  title = "工业固体废物产生量（万吨/年）",
                  number = "4324"
                },
                new TeaInformation
                {
                  title = "工业废水排放量（万吨/年）",
                  number = "3554"
                },
                new TeaInformation
                {
                  title = "工业废气排放总量（亿立方米/年）",
                  number = "112"
                },
                new TeaInformation
                {
                  title = "城镇污水纳管率（%）",
                  number = "665"
                },
                new TeaInformation
                {
                  title = "空气质量优良率（%）",
                  number = "876"
                },  
                new TeaInformation
                {
                  title = "清运垃圾（万吨）",
                  number = "342"
                },
                new TeaInformation
                {
                  title = "垃圾焚烧（万吨）",
                  number = "324"
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
                  title = "建成区绿化覆盖率（%）",
                  number = "79.25"
                },
                new TeaInformation
                {
                  title = "园林绿地面积（万平方米）",
                  number = "432"
                },
                new TeaInformation
                {
                  title = "人均公共绿地（㎡）",
                  number = "12.35"
                },
                new TeaInformation
                {
                  title = "工业固体废物产生量（万吨/年）",
                  number = "6533"
                },
                new TeaInformation
                {
                  title = "工业废水排放量（万吨/年）",
                  number = "234"
                },
                new TeaInformation
                {
                  title = "工业废气排放总量（亿立方米/年）",
                  number = "653"
                },
                new TeaInformation
                {
                  title = "城镇污水纳管率（%）",
                  number = "645"
                },
                new TeaInformation
                {
                  title = "空气质量优良率（%）",
                  number = "1344"
                },  
                new TeaInformation
                {
                  title = "清运垃圾（万吨）",
                  number = "6545"
                },
                new TeaInformation
                {
                  title = "垃圾焚烧（万吨）",
                  number = "4543"
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
                  title = "建成区绿化覆盖率（%）",
                  number = "543.23"
                },
                new TeaInformation
                {
                  title = "园林绿地面积（万平方米）",
                  number = "543"
                },
                new TeaInformation
                {
                  title = "人均公共绿地（㎡）",
                  number = "16.57"
                },
                new TeaInformation
                {
                  title = "工业固体废物产生量（万吨/年）",
                  number = "6546"
                },
                new TeaInformation
                {
                  title = "工业废水排放量（万吨/年）",
                  number = "665"
                },
                new TeaInformation
                {
                  title = "工业废气排放总量（亿立方米/年）",
                  number = "766"
                },
                new TeaInformation
                {
                  title = "城镇污水纳管率（%）",
                  number = "765"
                },
                new TeaInformation
                {
                  title = "空气质量优良率（%）",
                  number = "322"
                },  
                new TeaInformation
                {
                  title = "清运垃圾（万吨）",
                  number = "3232"
                },
                new TeaInformation
                {
                  title = "垃圾焚烧（万吨）",
                  number = "5643"
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
