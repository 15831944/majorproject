﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows;
using WpfApplication3.Language;
//using ESRI.ArcGIS.ADF.CATIDs;
//using ESRI.ArcGIS.Controls;
//using ESRI.ArcGIS.Geometry;
//using ESRI.ArcGIS.Display;
//using ESRI.ArcGIS.Carto;
//using ESRI.ArcGIS.ADF.BaseClasses;
//using ESRI.ArcGIS.esriSystem;

namespace WpfApplication3
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
        public App()
        {
            //ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.Engine);
            //InitializeEngineLicense();
            LanguageHelper lh = new LanguageHelper();
            lh.setLanguage("en-US");
        }

        //private void InitializeEngineLicense()
        //{
        //    AoInitialize aoi = new AoInitialize();

        //    esriLicenseProductCode productCode = esriLicenseProductCode.esriLicenseProductCodeEngine;
        //    if (aoi.IsProductCodeAvailable(productCode) == esriLicenseStatus.esriLicenseAvailable)
        //    {
        //        aoi.Initialize(productCode);
        //    }
        //}
	}
}