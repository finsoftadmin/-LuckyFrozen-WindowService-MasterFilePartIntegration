using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace LFWMSIntegration
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
            InitScheduler();
        }
        public void InitScheduler()
        {
            Schedular oScheduler = new Schedular();
            oScheduler.Start();
        }
        public void OnDebug()
        {
            OnStart(null);
        }
        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
    }
}
