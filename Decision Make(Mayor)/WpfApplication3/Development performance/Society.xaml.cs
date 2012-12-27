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
            {  new TeaInformation
                {
                  title = "年末常住人口（万人）",
                  number = "54.73"
                },
                new TeaInformation
                {
                  title = "年末户籍人口（万人）",
                  number = "924"
                },
                new TeaInformation
                {
                  title = "年末户数（万户）",
                  number = "17.57"
                },
                new TeaInformation
                {
                  title = "自然增长率‰",
                  number = "453"
                },
                new TeaInformation
                {
                  title = "从业人员（万人）",
                  number = "5435"
                },
                new TeaInformation
                {
                  title = "职工人数（万人）",
                  number = "654"
                },
                new TeaInformation
                {
                  title = "新增就业岗位（万人）",
                  number = "9823"
                },
                new TeaInformation
                {
                  title = "期末城镇登记失业人数（万人）",
                  number = "324"
                },   new TeaInformation
                {
                  title = "城镇居民人均年可支配收入（元）",
                  number = "6464"
                },
                new TeaInformation
                {
                  title = "郊区居民人均可支配收入（元）",
                  number = "423"
                },
                new TeaInformation
                {
                  title = "职工年平均工资（元）",
                  number = "43634"
                },
                new TeaInformation
                {
                  title = "外商直接投资合同金额（亿美元）",
                  number = "8677"
                },   new TeaInformation
                {
                  title = "城镇居民人均住宅建筑面积（㎡）",
                  number = "2234"
                },
                new TeaInformation
                {
                  title = "平均期望寿命（岁）",
                  number = "876"
                },
                new TeaInformation
                {
                  title = "高等学校在校学生数（人）",
                  number = "4556"
                },
                new TeaInformation
                {
                  title = "中等学校在校学生数（人）",
                  number = "1333"
                },   new TeaInformation
                {
                  title = "小学校在校学生数（人）",
                  number = "45445"
                },
                new TeaInformation
                {
                  title = "小学在校学生数（人）",
                  number = "656"
                },
                new TeaInformation
                {
                  title = "学龄儿童入学率％",
                  number = "56"
                },
                new TeaInformation
                {
                  title = "医疗机构数（个）",
                  number = "655"
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
                  title = "年末常住人口（万人）",
                  number = "54.73"
                },
                new TeaInformation
                {
                  title = "年末户籍人口（万人）",
                  number = "924"
                },
                new TeaInformation
                {
                  title = "年末户数（万户）",
                  number = "17.57"
                },
                new TeaInformation
                {
                  title = "自然增长率‰",
                  number = "5465"
                },
                new TeaInformation
                {
                  title = "从业人员（万人）",
                  number = "767"
                },
                new TeaInformation
                {
                  title = "职工人数（万人）",
                  number = "3432"
                },
                new TeaInformation
                {
                  title = "新增就业岗位（万人）",
                  number = "2332"
                },
                new TeaInformation
                {
                  title = "期末城镇登记失业人数（万人）",
                  number = "5465"
                },   new TeaInformation
                {
                  title = "城镇居民人均年可支配收入（元）",
                  number = "6757"
                },
                new TeaInformation
                {
                  title = "郊区居民人均可支配收入（元）",
                  number = "6576"
                },
                new TeaInformation
                {
                  title = "职工年平均工资（元）",
                  number = "245666"
                },
                new TeaInformation
                {
                  title = "外商直接投资合同金额（亿美元）",
                  number = "6456"
                },   new TeaInformation
                {
                  title = "城镇居民人均住宅建筑面积（㎡）",
                  number = "675"
                },
                new TeaInformation
                {
                  title = "平均期望寿命（岁）",
                  number = "675"
                },
                new TeaInformation
                {
                  title = "高等学校在校学生数（人）",
                  number = "7653"
                },
                new TeaInformation
                {
                  title = "中等学校在校学生数（人）",
                  number = "6757"
                },   new TeaInformation
                {
                  title = "小学校在校学生数（人）",
                  number = "242"
                },
                new TeaInformation
                {
                  title = "小学在校学生数（人）",
                  number = "22"
                },
                new TeaInformation
                {
                  title = "学龄儿童入学率％",
                  number = "24"
                },
                new TeaInformation
                {
                  title = "医疗机构数（个）",
                  number = "24"
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
                  title = "年末常住人口（万人）",
                  number = "54.51"
                },
                new TeaInformation
                {
                  title = "年末户籍人口（万人）",
                  number = "693"
                },
                new TeaInformation
                {
                  title = "年末户数（万户）",
                  number = "232"
                },
                new TeaInformation
                {
                  title = "自然增长率‰",
                  number = "656"
                },
                new TeaInformation
                {
                  title = "从业人员（万人）",
                  number = "865"
                },
                new TeaInformation
                {
                  title = "职工人数（万人）",
                  number = "765"
                },
                new TeaInformation
                {
                  title = "新增就业岗位（万人）",
                  number = "765"
                },
                new TeaInformation
                {
                  title = "期末城镇登记失业人数（万人）",
                  number = "4724"
                },   new TeaInformation
                {
                  title = "城镇居民人均年可支配收入（元）",
                  number = "2467"
                },
                new TeaInformation
                {
                  title = "郊区居民人均可支配收入（元）",
                  number = "247"
                },
                new TeaInformation
                {
                  title = "职工年平均工资（元）",
                  number = "72"
                },
                new TeaInformation
                {
                  title = "外商直接投资合同金额（亿美元）",
                  number = "742"
                },   new TeaInformation
                {
                  title = "城镇居民人均住宅建筑面积（㎡）",
                  number = "87"
                },
                new TeaInformation
                {
                  title = "平均期望寿命（岁）",
                  number = "675"
                },
                new TeaInformation
                {
                  title = "高等学校在校学生数（人）",
                  number = "765"
                },
                new TeaInformation
                {
                  title = "中等学校在校学生数（人）",
                  number = "763"
                },   new TeaInformation
                {
                  title = "小学校在校学生数（人）",
                  number = "7373"
                },
                new TeaInformation
                {
                  title = "小学在校学生数（人）",
                  number = "7563"
                },
                new TeaInformation
                {
                  title = "学龄儿童入学率％",
                  number = "735"
                },
                new TeaInformation
                {
                  title = "医疗机构数（个）",
                  number = "8768"
                },                      
            };

                Economic.DataContext = TeaInfo;
                Economic.SelectedIndex = 0;
            }
            if (slider.Value == 2)
            {
              
                List<TeaInformation> TeaInfo = new List<TeaInformation>
            { new TeaInformation
                {
                  title = "年末常住人口（万人）",
                  number = "64.3"
                },
                new TeaInformation
                {
                  title = "年末户籍人口（万人）",
                  number = "56.2"
                },
                new TeaInformation
                {
                  title = "年末户数（万户）",
                  number = "78.5"
                },
                new TeaInformation
                {
                  title = "自然增长率‰",
                  number = "375"
                },
                new TeaInformation
                {
                  title = "从业人员（万人）",
                  number = "875"
                },
                new TeaInformation
                {
                  title = "职工人数（万人）",
                  number = "2657"
                },
                new TeaInformation
                {
                  title = "新增就业岗位（万人）",
                  number = "72"
                },
                new TeaInformation
                {
                  title = "期末城镇登记失业人数（万人）",
                  number = "24"
                },   new TeaInformation
                {
                  title = "城镇居民人均年可支配收入（元）",
                  number = "87"
                },
                new TeaInformation
                {
                  title = "郊区居民人均可支配收入（元）",
                  number = "68"
                },
                new TeaInformation
                {
                  title = "职工年平均工资（元）",
                  number = "635"
                },
                new TeaInformation
                {
                  title = "外商直接投资合同金额（亿美元）",
                  number = "865"
                },   new TeaInformation
                {
                  title = "城镇居民人均住宅建筑面积（㎡）",
                  number = "976"
                },
                new TeaInformation
                {
                  title = "平均期望寿命（岁）",
                  number = "34"
                },
                new TeaInformation
                {
                  title = "高等学校在校学生数（人）",
                  number = "765"
                },
                new TeaInformation
                {
                  title = "中等学校在校学生数（人）",
                  number = "657"
                },   new TeaInformation
                {
                  title = "小学校在校学生数（人）",
                  number = "765"
                },
                new TeaInformation
                {
                  title = "小学在校学生数（人）",
                  number = "657"
                },
                new TeaInformation
                {
                  title = "学龄儿童入学率％",
                  number = "67"
                },
                new TeaInformation
                {
                  title = "医疗机构数（个）",
                  number = "876"
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
                  title = "年末常住人口（万人）",
                  number = "56.2"
                },
                new TeaInformation
                {
                  title = "年末户籍人口（万人）",
                  number = "78.23"
                },
                new TeaInformation
                {
                  title = "年末户数（万户）",
                  number = "33.26"
                },
                new TeaInformation
                {
                  title = "自然增长率‰",
                  number = "654"
                },
                new TeaInformation
                {
                  title = "从业人员（万人）",
                  number = "767"
                },
                new TeaInformation
                {
                  title = "职工人数（万人）",
                  number = "767"
                },
                new TeaInformation
                {
                  title = "新增就业岗位（万人）",
                  number = "456"
                },
                new TeaInformation
                {
                  title = "期末城镇登记失业人数（万人）",
                  number = "5426"
                },   new TeaInformation
                {
                  title = "城镇居民人均年可支配收入（元）",
                  number = "624"
                },
                new TeaInformation
                {
                  title = "郊区居民人均可支配收入（元）",
                  number = "624"
                },
                new TeaInformation
                {
                  title = "职工年平均工资（元）",
                  number = "76"
                },
                new TeaInformation
                {
                  title = "外商直接投资合同金额（亿美元）",
                  number = "767"
                },   new TeaInformation
                {
                  title = "城镇居民人均住宅建筑面积（㎡）",
                  number = "31"
                },
                new TeaInformation
                {
                  title = "平均期望寿命（岁）",
                  number = "3431"
                },
                new TeaInformation
                {
                  title = "高等学校在校学生数（人）",
                  number = "3434"
                },
                new TeaInformation
                {
                  title = "中等学校在校学生数（人）",
                  number = "7654"
                },   new TeaInformation
                {
                  title = "小学校在校学生数（人）",
                  number = "546"
                },
                new TeaInformation
                {
                  title = "小学在校学生数（人）",
                  number = "654"
                },
                new TeaInformation
                {
                  title = "学龄儿童入学率％",
                  number = "6546"
                },
                new TeaInformation
                {
                  title = "医疗机构数（个）",
                  number = "6546"
                },                      
            };

                Economic.DataContext = TeaInfo;
                Economic.SelectedIndex = 0;
            }
            if (slider.Value == 4)
            {
                Lable.Text = "GDP:9877 \r\n财政收入:4023";
                List<TeaInformation> TeaInfo = new List<TeaInformation>
            {
                new TeaInformation
                {
                  title = "年末常住人口（万人）",
                  number = "456"
                },
                new TeaInformation
                {
                  title = "年末户籍人口（万人）",
                  number = "32.2"
                },
                new TeaInformation
                {
                  title = "年末户数（万户）",
                  number = "45.25"
                },
                new TeaInformation
                {
                  title = "自然增长率‰",
                  number = "56.2"
                },
                new TeaInformation
                {
                  title = "从业人员（万人）",
                  number = "642"
                },
                new TeaInformation
                {
                  title = "职工人数（万人）",
                  number = "64"
                },
                new TeaInformation
                {
                  title = "新增就业岗位（万人）",
                  number = "987"
                },
                new TeaInformation
                {
                  title = "期末城镇登记失业人数（万人）",
                  number = "9860"
                },   new TeaInformation
                {
                  title = "城镇居民人均年可支配收入（元）",
                  number = "559"
                },
                new TeaInformation
                {
                  title = "郊区居民人均可支配收入（元）",
                  number = "78"
                },
                new TeaInformation
                {
                  title = "职工年平均工资（元）",
                  number = "735"
                },
                new TeaInformation
                {
                  title = "外商直接投资合同金额（亿美元）",
                  number = "735"
                },   new TeaInformation
                {
                  title = "城镇居民人均住宅建筑面积（㎡）",
                  number = "264"
                },
                new TeaInformation
                {
                  title = "平均期望寿命（岁）",
                  number = "6524"
                },
                new TeaInformation
                {
                  title = "高等学校在校学生数（人）",
                  number = "62"
                },
                new TeaInformation
                {
                  title = "中等学校在校学生数（人）",
                  number = "62"
                },   new TeaInformation
                {
                  title = "小学校在校学生数（人）",
                  number = "26"
                },
                new TeaInformation
                {
                  title = "小学在校学生数（人）",
                  number = "64"
                },
                new TeaInformation
                {
                  title = "学龄儿童入学率％",
                  number = "64"
                },
                new TeaInformation
                {
                  title = "医疗机构数（个）",
                  number = "64"
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
