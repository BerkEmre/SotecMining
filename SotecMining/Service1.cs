using SMCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SotecMining
{
    public partial class Service1 : ServiceBase
    {
        MiningCore miningCore = new MiningCore();

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Log.WriteLog("Servis başladı.");
            miningCore.Start();
        }

        protected override void OnStop()
        {
            miningCore.Stop();
            Log.WriteLog("Servis durdu.");
        }
    }
}
