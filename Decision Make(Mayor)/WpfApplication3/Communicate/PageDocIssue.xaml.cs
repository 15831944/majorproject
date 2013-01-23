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
using System.Data;
using System.Collections;
using System.IO;
using System.Windows.Ink;

namespace WpfApplication3.Communicate
{
    /// <summary>
    /// Interaction logic for PageDocIssue.xaml
    /// </summary>
    public partial class PageDocIssue : Page
    {
        bool IsRead;
        int DocType;
        int OrderType;//1:时间正序   2：时间倒序
        int iFirstDocId;
        DataSetDoc.T_DocDataTable dtDocs;
//        DataSetDoc.T_DocDataTable dtCurrent;
//		DataSetDoc.T_DocDataTable dtLatestCurrent;
		
        int iCurrentId;
        public PageDocIssue()
        {
            InitializeComponent();
            dtDocs = new DataSetDoc.T_DocDataTable();
            this.InkCanvasAnnotation1.IsEnabled = false;
            OrderType = 1;
            iFirstDocId = -1;
        }

        private void typejudge()
        {
            if (Already.IsSelected == true)
            {
                IsRead = true;
                if (DocType1.IsSelected == true)
                {
                    DocType = 1;
                }
                else
                {
                    if (DocType2.IsSelected == true)
                    {
                        DocType = 2;
                    }
                    else
                    {
                        DocType = 3;
                    }
                }
            }
            else
            {
                IsRead = false;
                if (DocType4.IsSelected == true)
                {
                    DocType = 1;
                }
                else
                {
                    if (DocType5.IsSelected == true)
                    {
                        DocType = 2;
                    }
                    else
                    {
                        DocType = 3;
                    }
                }
            }
                
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            typejudge();
            listboxDocsRefresh(IsRead, DocType,OrderType);
            if (iFirstDocId != -1)
                ShowDoc(iFirstDocId);
        }

		private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox m_ComboBox = (ComboBox)sender;
            for (int i = 1; i < m_ComboBox.Items.Count - 1; i++)
            {
                CheckBox m_CheckBox = (CheckBox)m_ComboBox.Items[i];
                if ((bool)m_CheckBox.IsChecked && listboxSend.Items.IndexOf(m_CheckBox.Content.ToString()) == -1)
                    listboxSend.Items.Add(m_CheckBox.Content.ToString());
                else if (!(bool)m_CheckBox.IsChecked && listboxSend.Items.IndexOf(m_CheckBox.Content.ToString()) != -1)
                    listboxSend.Items.Remove(m_CheckBox.Content.ToString());
            }

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ComboBox m_ComboBox = (ComboBox)((CheckBox)sender).Parent;
            for (int i = 1; i < m_ComboBox.Items.Count - 1; i++)
            {
                ((CheckBox)m_ComboBox.Items[i]).IsChecked = true;
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ComboBox m_ComboBox = (ComboBox)((CheckBox)sender).Parent;
            for (int i = 1; i < m_ComboBox.Items.Count - 1; i++)
            {
                ((CheckBox)m_ComboBox.Items[i]).IsChecked = false;
            }
        }

        private void rbtBlackInk_Click(object sender, RoutedEventArgs e)
        {
            InkCanvasAnnotation1.EditingMode = InkCanvasEditingMode.Ink;
            DrawingAttributes inkDA = this.InkCanvasAnnotation1.DefaultDrawingAttributes;
            inkDA.Color = Color.FromRgb(0, 0, 0);
            this.InkCanvasAnnotation1.DefaultDrawingAttributes = inkDA;
        }

        private void rbtRedInk_Click(object sender, RoutedEventArgs e)
        {
            InkCanvasAnnotation1.EditingMode = InkCanvasEditingMode.Ink;
            DrawingAttributes inkDA = this.InkCanvasAnnotation1.DefaultDrawingAttributes;
            inkDA.Color = Color.FromRgb(255, 0, 0);
            this.InkCanvasAnnotation1.DefaultDrawingAttributes = inkDA;
        }

        private void rbtGreenInk_Click(object sender, RoutedEventArgs e)
        {
            InkCanvasAnnotation1.EditingMode = InkCanvasEditingMode.Ink;
            DrawingAttributes inkDA = this.InkCanvasAnnotation1.DefaultDrawingAttributes;
            inkDA.Color = Color.FromRgb(0, 255, 0);
            this.InkCanvasAnnotation1.DefaultDrawingAttributes = inkDA;
        }

        private void rbtBlueInk_Click(object sender, RoutedEventArgs e)
        {
            InkCanvasAnnotation1.EditingMode = InkCanvasEditingMode.Ink;
            DrawingAttributes inkDA = this.InkCanvasAnnotation1.DefaultDrawingAttributes;
            inkDA.Color = Color.FromRgb(0, 0, 255);
            this.InkCanvasAnnotation1.DefaultDrawingAttributes = inkDA;
        }

        private void rbtThickInk_Click(object sender, RoutedEventArgs e)
        {
            DrawingAttributes inkDA = this.InkCanvasAnnotation1.DefaultDrawingAttributes;
            inkDA.Width = 10;
            inkDA.Height = 10;
            this.InkCanvasAnnotation1.DefaultDrawingAttributes = inkDA;
        }

        private void rbtNormalInk_Click(object sender, RoutedEventArgs e)
        {
            DrawingAttributes inkDA = this.InkCanvasAnnotation1.DefaultDrawingAttributes;
            inkDA.Width = 5;
            inkDA.Height = 5;
            this.InkCanvasAnnotation1.DefaultDrawingAttributes = inkDA;
        }

        private void rbtThinInk_Click(object sender, RoutedEventArgs e)
        {
            DrawingAttributes inkDA = this.InkCanvasAnnotation1.DefaultDrawingAttributes;
            inkDA.Width = 1;
            inkDA.Height = 1;
            this.InkCanvasAnnotation1.DefaultDrawingAttributes = inkDA;
        }

        private void rbtRubber_Click(object sender, RoutedEventArgs e)
        {
            InkCanvasAnnotation1.EditingMode = InkCanvasEditingMode.EraseByPoint;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (tbxSearch.Text != "")
            {
                DataSetDocTableAdapters.T_DocTableAdapter adapter = new DataSetDocTableAdapters.T_DocTableAdapter();
                dtDocs = adapter.GetDataByKey(tbxSearch.Text);
                listboxDocs.ItemsSource = dtDocs;
            }
        }

        private void btnCommentClear_Click(object sender, RoutedEventArgs e)
        {
            this.InkCanvasAnnotation1.Strokes.Clear();
        }

        private void btnCommentOK_Click(object sender, RoutedEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string strPath = di.Parent.Parent.FullName;
            DataSetDocTableAdapters.T_DocTableAdapter adapter = new DataSetDocTableAdapters.T_DocTableAdapter();
            DataSetDoc.T_DocDataTable dt = adapter.GetDocById(iCurrentId);
            string filename = dt[0].DocTitle;
            if (Directory.Exists(strPath + @"/Comment") == false)
            {
                Directory.CreateDirectory(strPath + @"/Comment");
            }
            System.IO.FileStream fs = new System.IO.FileStream(strPath + @"/Comment/" + filename + ".isf", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            this.InkCanvasAnnotation1.Strokes.Save(fs);
            fs.Close();
            MessageBox.Show("批示保存成功！");
        }



        private void listboxDocsRefresh(bool Isread, int Doctype, int Ordertype)
        {
            //IsRead&&DocType
            DataSetDocTableAdapters.T_DocTableAdapter adapter = new DataSetDocTableAdapters.T_DocTableAdapter();
            switch (OrderType) { 
                case 1:
                    dtDocs = adapter.GetDataByStateNTypeOrderbyDateASC(Isread, Doctype);
                    break;
                case 2:
                    dtDocs = adapter.GetDataByStateNTypeOrderbyDateDESC(Isread, Doctype);
                    break;
            }
            listboxDocs.ItemsSource = dtDocs;

            if (iFirstDocId == -1 && dtDocs.Count > 0 && Isread == true)
                iFirstDocId = dtDocs[0].Id;
        }
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("发送成功！");
        }
		

        private void tbxSearch_GotMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
        	tbxSearch.Clear();// TODO: Add event handler implementation here.
        }

        private void tbxSearch_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
        	// TODO: Add event handler implementation here.
			if (tbxSearch.Text != "")
            {
                DataSetDocTableAdapters.T_DocTableAdapter adapter = new DataSetDocTableAdapters.T_DocTableAdapter();
                dtDocs = adapter.GetDataByKey(tbxSearch.Text);
                listboxDocs.ItemsSource = dtDocs;
            }
        }

        private void btnDocSearchShow_Click(object sender, System.Windows.RoutedEventArgs e)
        {
			Button btn = sender as Button;
            int id = Convert.ToInt32(btn.Tag.ToString());
            iCurrentId = id;
            DataSetDocTableAdapters.T_DocTableAdapter adapter = new DataSetDocTableAdapters.T_DocTableAdapter();
            DataSetDoc.T_DocDataTable dt = adapter.GetDocById(id);
			string filePDF = dt[0].DocAddress;
            string FileISF = dt[0].DocTitle + ".isf";
            DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string strPath = di.Parent.Parent.FullName;
            if (System.IO.File.Exists(strPath + @"/PDF/" + filePDF))
            {
                webbrowserDocContent.Navigate(new Uri(strPath + @"/PDF/" + filePDF,UriKind.RelativeOrAbsolute));
            }
            else
            {
                MessageBox.Show("未找到PDF文件");
            }
            if (System.IO.File.Exists(strPath + @"/Comment/" + FileISF))
            {
                System.IO.FileStream fs = new System.IO.FileStream(strPath + @"/Comment/" + FileISF, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                this.InkCanvasAnnotation1.Strokes = new System.Windows.Ink.StrokeCollection(fs);
                fs.Close();
            }
            else
                this.InkCanvasAnnotation1.Strokes = new System.Windows.Ink.StrokeCollection();
            this.InkCanvasAnnotation1.IsEnabled = true;
            adapter.UpdateState(true, id);
//            PDFReader pdfReader = new PDFReader();
//            pdfReader.showPdf(content + ".pdf");
        }

        private void ShowDoc(int id)
        {
            DataSetDocTableAdapters.T_DocTableAdapter adapter = new DataSetDocTableAdapters.T_DocTableAdapter();
            DataSetDoc.T_DocDataTable dt = adapter.GetDocById(id);
            string filePDF = dt[0].DocAddress;
            string FileISF = dt[0].DocTitle + ".isf";
            DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory);
            string strPath = di.Parent.Parent.FullName;
            if (System.IO.File.Exists(strPath + @"/PDF/" + filePDF))
            {
                webbrowserDocContent.Navigate(new Uri(strPath + @"/PDF/" + filePDF, UriKind.RelativeOrAbsolute));
            }
            else
            {
                MessageBox.Show("未找到PDF文件");
            }
            if (System.IO.File.Exists(strPath + @"/Comment/" + FileISF))
            {
                System.IO.FileStream fs = new System.IO.FileStream(strPath + @"/Comment/" + FileISF, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                this.InkCanvasAnnotation1.Strokes = new System.Windows.Ink.StrokeCollection(fs);
                fs.Close();
            }
            else
                this.InkCanvasAnnotation1.Strokes = new System.Windows.Ink.StrokeCollection();
            this.InkCanvasAnnotation1.IsEnabled = true;
            adapter.UpdateState(true, id);
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            typejudge();
            listboxDocsRefresh(IsRead, DocType,OrderType);
        }

		private void ckbDate_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            OrderType = 1;
            typejudge();
            listboxDocsRefresh(IsRead, DocType, OrderType);
        }

        private void ckbDate_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            OrderType = 2;
            typejudge();
            listboxDocsRefresh(IsRead, DocType, OrderType);
        }

    }
}
