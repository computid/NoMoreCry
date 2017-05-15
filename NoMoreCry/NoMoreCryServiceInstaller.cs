using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace NoMoreCry
{
    [RunInstaller(true)]
    public class NoMoreCryInstaller : Installer
    {
        public NoMoreCryInstaller()
        {
            ServiceProcessInstaller serviceProcessInstaller = new ServiceProcessInstaller();
            ServiceInstaller serviceInstaller = new ServiceInstaller();

            serviceProcessInstaller.Account = ServiceAccount.LocalSystem;
            serviceProcessInstaller.Username = null;
            serviceProcessInstaller.Password = null;

            serviceInstaller.DisplayName = "NoMoreCry";
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            serviceInstaller.ServiceName = "NoMoreCry";

            this.Installers.Add(serviceProcessInstaller);
            this.Installers.Add(serviceInstaller);

            serviceInstaller.AfterInstall += NoMoreCryInstaller_AfterInstall;
        }

        private void NoMoreCryInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
            using (ServiceController sc = new ServiceController("NoMoreCry"))
            {
                sc.Start();
            }
        }
    }

    
}
