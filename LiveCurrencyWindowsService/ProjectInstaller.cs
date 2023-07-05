using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace LiveCurrencyWindowsService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        private void LiveCurrencyService_AfterInstall(object sender, InstallEventArgs e)
        {
            using (ServiceController sc = new ServiceController(LiveCurrencyService.ServiceName))
            {
                sc.Start();
            }
        }
    }
}
