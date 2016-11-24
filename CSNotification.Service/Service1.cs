using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CSNotification.Service
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
//#if DEBUG
  //          Debugger.Launch();
//#endif
            WebApp.Start(System.Configuration.ConfigurationManager.AppSettings["url"]);
        }

        protected override void OnStop()
        {
        }
    }
    
}
