﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NetworkApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            

            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjUwMDQxQDMxMzgyZTMxMmUzMFpWSkVHTkhzMENuK2t2QlcwRnYrcG41bllBTk1LRUdnV0ZwdS84OTY3NDQ9");
        }
    }
}
