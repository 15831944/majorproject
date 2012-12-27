using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;

namespace WpfApplication3.Language
{
    class LanguageHelper
    {
        public void setLanguage(string str)
        {
            CultureInfo m_cultureInfo = new CultureInfo(str);
            Thread.CurrentThread.CurrentUICulture = m_cultureInfo;
            Thread.CurrentThread.CurrentCulture = m_cultureInfo;
        }
    }
}
