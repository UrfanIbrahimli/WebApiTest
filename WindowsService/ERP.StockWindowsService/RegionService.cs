﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ERP.StockWindowsService
{
    partial class RegionService : ServiceBase
    {
        public RegionService()
        {
            InitializeComponent();
        }

        public void OnDebug()
        {
            OnStart(null);
        }
       
        protected override void OnStart(string[] args)
        {
            JobConfig.Start();
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }
}
