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

namespace WpfApplication3.Case
{
    /// <summary>
    /// Interaction logic for PageCase.xaml
    /// </summary>
    public partial class PageCase : Page
    {
        public DataSet_Case.T_CaseDataTable dtSource;
        public PageCase(int i)
        {
            InitializeComponent();
            ShowTreeView(i);
            DataSet_CaseTableAdapters.T_CaseTableAdapter adapter = new DataSet_CaseTableAdapters.T_CaseTableAdapter();
            switch (i)
            {
                case 1:
                    dtSource = adapter.GetDataByMenu("城市发展案例");
                    break;
                case 2:
                    dtSource = adapter.GetDataByMenu("城市百科知识");
                    break;
                case 3:
                    dtSource = adapter.GetDataByMenu("城市数据知识");
                    break;
                default:
                    break;
            }

            DataBind(20, 1);
        }

        private void DataBind(int number, int currentSize)
        {
            if (dtSource == null)
            {
                return;
            }



            int iPageSize;
            //DataSetCityCaseTableAdapters.T_CaseTableAdapter adapter = new DataSetCityCaseTableAdapters.T_CaseTableAdapter();
            //DataSetCityCase.T_CaseDataTable dt = adapter.SearchByKeyValue(tbx_JianYanYinJian_Search.Text);
            int count = dtSource.Count;
            if (count % number == 0)
                iPageSize = count / number;
            else
                iPageSize = count / number + 1;
            tbkTotal.Text = iPageSize.ToString();
            tbkCurrentsize.Text = currentSize.ToString();
            List<DataSet_Case.T_CaseRow> m_list = dtSource.Skip(number * (currentSize - 1)).Take(number).ToList();
            foreach (DataSet_Case.T_CaseRow row in m_list)
            {
                row.StarLevel = "/Images/StarLevel" + row.StarLevel + ".jpg";
            }
            dataGridSearchResult.ItemsSource = m_list;
        }

        private void ShowTreeView(int i)
        {
            List<ClassCatalogNodeItem> itemList = new List<ClassCatalogNodeItem>();
            ClassCatalogNodeItem node;
            ClassCatalogNodeItem child;
            switch (i)
            {
                case 1:
                    node = new ClassCatalogNodeItem() { strText = "城市发展案例", isOpen = true };
                    child = new ClassCatalogNodeItem() { strText = "区域规划", isOpen = true };
                    node.Children.Add(child);
                    child = new ClassCatalogNodeItem() { strText = "总体规划", isOpen = true };
                    node.Children.Add(child);
                    child = new ClassCatalogNodeItem() { strText = "详细规划", isOpen = true };
                    node.Children.Add(child);
                    child = new ClassCatalogNodeItem() { strText = "城市设计", isOpen = true };
                    node.Children.Add(child);
                    child = new ClassCatalogNodeItem() { strText = "专项规划", isOpen = true };
                    node.Children.Add(child);
                    itemList.Add(node);
                    break;
                case 2:
                    node = new ClassCatalogNodeItem() { strText = "城市百科知识", isOpen = true };
                    child = new ClassCatalogNodeItem() { strText = "城镇运营管理", isOpen = true };
                    ClassCatalogNodeItem grandChild = new ClassCatalogNodeItem() { strText = "城市发展", isOpen = true };
                    child.Children.Add(grandChild);
                    grandChild = new ClassCatalogNodeItem() { strText = "城市更新", isOpen = true };
                    child.Children.Add(grandChild);
                    grandChild = new ClassCatalogNodeItem() { strText = "突发事件处理", isOpen = true };
                    child.Children.Add(grandChild);
                    node.Children.Add(child);
                    child = new ClassCatalogNodeItem() { strText = "乡村运营管理", isOpen = true };
                    grandChild = new ClassCatalogNodeItem() { strText = "土地流转", isOpen = true };
                    child.Children.Add(grandChild);
                    grandChild = new ClassCatalogNodeItem() { strText = "农业合作", isOpen = true };
                    child.Children.Add(grandChild);
                    node.Children.Add(child);
                    child = new ClassCatalogNodeItem() { strText = "农乡统筹发展", isOpen = true };
                    node.Children.Add(child);
                    itemList.Add(node);
                    break;
                case 3:
                    node = new ClassCatalogNodeItem() { strText = "城市数据知识", isOpen = true };
                    child = new ClassCatalogNodeItem() { strText = "城市数据知识菜单一", isOpen = true };
                    node.Children.Add(child);
                    child = new ClassCatalogNodeItem() { strText = "城市数据知识菜单二", isOpen = true };
                    node.Children.Add(child);
                    child = new ClassCatalogNodeItem() { strText = "城市数据知识菜单三", isOpen = true };
                    node.Children.Add(child);
                    itemList.Add(node);
                    break;
                default:
                    break;
            }
            this.treeViewCatalog.ItemsSource = itemList;
        }

        private void btnPageUp_Click(object sender, RoutedEventArgs e)
        {
            int currentsize = int.Parse(tbkCurrentsize.Text); //获取当前页数  
            if (currentsize > 1)
            {
                DataBind(20, currentsize - 1);   //调用分页方法  
            }
        }

        private void btnPageNext_Click(object sender, RoutedEventArgs e)
        {
            int total = int.Parse(tbkTotal.Text); //总页数  
            int currentsize = int.Parse(tbkCurrentsize.Text); //当前页数  
            if (currentsize < total)
            {
                DataBind(20, currentsize + 1);   //调用分页方法  
            }
        }

        private void dataGridSearchResult_Click(object sender, RoutedEventArgs e)
        {
            if (this.dataGridSearchResult.SelectedItem == null)
            {
                return;
            }
            if (e.OriginalSource.GetType() != typeof(System.Windows.Documents.Hyperlink))
                return;
            //todo:
            int i = dataGridSearchResult.SelectedIndex;
            DataSet_Case.T_CaseRow ThisCase = dataGridSearchResult.SelectedItem as DataSet_Case.T_CaseRow;

            string strFileName = ThisCase.CasePDF;
            DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string strPath = di.Parent.Parent.FullName;
            if (System.IO.File.Exists(strPath + @"/PDF/" + strFileName))
            {
                PDFReader m_PDFReader = new PDFReader();
                m_PDFReader.showPdf(strFileName);
            }
            else
            {
                MessageBox.Show("没有该文件");
            }
        }

        private void btnPageGo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int pageNum = int.Parse(tbxPageNum.Text);
                int total = int.Parse(tbkTotal.Text); //总页数  
                if (pageNum >= 1 && pageNum <= total)
                {
                    DataBind(20, pageNum);     //调用分页方法  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (tbxSearch.Text == null || tbxSearch.Text == "")
                return;
            DataSet_CaseTableAdapters.T_CaseTableAdapter adapter = new DataSet_CaseTableAdapters.T_CaseTableAdapter();
            string strMenu = cbbType.SelectedIndex == -1 || cbbType.SelectedIndex == 0 ? "" : ((ComboBoxItem)cbbType.SelectedItem).Content.ToString();
            string strFunc = cbbFunction.SelectedIndex == -1 || cbbFunction.SelectedIndex == 0 ? "" : ((ComboBoxItem)cbbFunction.SelectedItem).Content.ToString();
            string strTime = cbbTime.SelectedIndex == -1 || cbbTime.SelectedIndex == 0 ? "" : ((ComboBoxItem)cbbTime.SelectedItem).Content.ToString();
            string strProvince = cbbArea.SelectedIndex == -1 || cbbArea.SelectedIndex == 0 ? "" : ((ComboBoxItem)cbbArea.SelectedItem).Content.ToString();
            dtSource = adapter.GetDataByKey(strMenu, strFunc, tbxSearch.Text, strTime, strProvince);
            DataBind(20, 1);
        }

        private void dataGridSearchResult_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.dataGridSearchResult.SelectedItem == null)
            {
                return;
            }
            int i = dataGridSearchResult.SelectedIndex;
            DataSet_Case.T_CaseRow ThisCase = dataGridSearchResult.SelectedItem as DataSet_Case.T_CaseRow;

            string strFileName = ThisCase.CasePDF;
            DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string strPath = di.Parent.Parent.FullName;
            if (System.IO.File.Exists(strPath + @"/PDF/" + strFileName))
            {
                PDFReader m_PDFReader = new PDFReader();
                m_PDFReader.showPdf(strFileName);
            }
            else
            {
                MessageBox.Show("没有该文件");
            }
            dataGridSearchResult.SelectedIndex = -1;
        }

        private void tbxSearch_GotMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
            tbxSearch.Clear();// TODO: Add event handler implementation here.
        }

        private void tbxSearchCase_GotMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
            tbxSearchCase.Clear();// TODO: Add event handler implementation here.
        }

        private void cbbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbbType.SelectedIndex == 1)
            {
                cbbFunction.Items.Clear();
                ComboBoxItem cbbItem = new ComboBoxItem();
                cbbItem.Content = "区域规划";
                cbbItem.SetResourceReference(ComboBoxItem.StyleProperty, "ComboBoxItemCase");
                cbbItem.Foreground = new SolidColorBrush(Colors.Black);
                cbbFunction.Items.Add(cbbItem);
                cbbItem = new ComboBoxItem();
                cbbItem.SetResourceReference(ComboBoxItem.StyleProperty, "ComboBoxItemCase");
                cbbItem.Foreground = new SolidColorBrush(Colors.Black);
                cbbItem.Content = "总体规划";
                cbbFunction.Items.Add(cbbItem);
                cbbItem = new ComboBoxItem();
                cbbItem.SetResourceReference(ComboBoxItem.StyleProperty, "ComboBoxItemCase");
                cbbItem.Foreground = new SolidColorBrush(Colors.Black);
                cbbItem.Content = "详细规划";
                cbbFunction.Items.Add(cbbItem);
                cbbItem = new ComboBoxItem();
                cbbItem.SetResourceReference(ComboBoxItem.StyleProperty, "ComboBoxItemCase");
                cbbItem.Foreground = new SolidColorBrush(Colors.Black);
                cbbItem.Content = "城市设计";
                cbbFunction.Items.Add(cbbItem);
                cbbItem = new ComboBoxItem();
                cbbItem.SetResourceReference(ComboBoxItem.StyleProperty, "ComboBoxItemCase");
                cbbItem.Foreground = new SolidColorBrush(Colors.Black);
                cbbItem.Content = "专项规划";
                cbbFunction.Items.Add(cbbItem);
            }
            else if (cbbType.SelectedIndex == 2)
            {
                cbbFunction.Items.Clear();
                ComboBoxItem cbbItem = new ComboBoxItem();
                cbbItem.Content = "城镇运营管理";
                cbbItem.SetResourceReference(ComboBoxItem.StyleProperty, "ComboBoxItemCase");
                cbbItem.Foreground = new SolidColorBrush(Colors.Black);
                cbbFunction.Items.Add(cbbItem);
                cbbItem = new ComboBoxItem();
                cbbItem.SetResourceReference(ComboBoxItem.StyleProperty, "ComboBoxItemCase");
                cbbItem.Foreground = new SolidColorBrush(Colors.Black);
                cbbItem.Content = "乡村运营管理";
                cbbFunction.Items.Add(cbbItem);
                cbbItem = new ComboBoxItem();
                cbbItem.SetResourceReference(ComboBoxItem.StyleProperty, "ComboBoxItemCase");
                cbbItem.Foreground = new SolidColorBrush(Colors.Black);
                cbbItem.Content = "城乡统筹发展";
                cbbFunction.Items.Add(cbbItem);
            }
            else if (cbbType.SelectedIndex == 3)
            {
                cbbFunction.Items.Clear();
                ComboBoxItem cbbItem = new ComboBoxItem();
                cbbItem.Content = "城市数据知识库菜单一";
                cbbItem.SetResourceReference(ComboBoxItem.StyleProperty, "ComboBoxItemCase");
                cbbItem.Foreground = new SolidColorBrush(Colors.Black);
                cbbFunction.Items.Add(cbbItem);
                cbbItem = new ComboBoxItem();
                cbbItem.SetResourceReference(ComboBoxItem.StyleProperty, "ComboBoxItemCase");
                cbbItem.Foreground = new SolidColorBrush(Colors.Black);
                cbbItem.Content = "城市数据知识库菜单二";
                cbbFunction.Items.Add(cbbItem);
                cbbItem = new ComboBoxItem();
                cbbItem.SetResourceReference(ComboBoxItem.StyleProperty, "ComboBoxItemCase");
                cbbItem.Foreground = new SolidColorBrush(Colors.Black);
                cbbItem.Content = "城市数据知识库菜单三";
                cbbFunction.Items.Add(cbbItem);
            }
        }

        private void TreeViewTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock tbl = (TextBlock)sender;
            string str = tbl.Text;
            DataSet_CaseTableAdapters.T_CaseTableAdapter adapter = new DataSet_CaseTableAdapters.T_CaseTableAdapter();
            dtSource = adapter.GetDataByMenu(str);
            DataBind(20, 1);
        }
    }

}
