namespace WindowsServiceCalculatorHost
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceCalculatorProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceCalculatorInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceCalculatorProcessInstaller
            // 
            this.serviceCalculatorProcessInstaller.Account = System.ServiceProcess.ServiceAccount.NetworkService;
            this.serviceCalculatorProcessInstaller.Password = null;
            this.serviceCalculatorProcessInstaller.Username = null;
            // 
            // serviceCalculatorInstaller
            // 
            this.serviceCalculatorInstaller.Description = "Calculator host";
            this.serviceCalculatorInstaller.DisplayName = "Calculator Host";
            this.serviceCalculatorInstaller.ServiceName = "Calculator";
            this.serviceCalculatorInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceCalculatorProcessInstaller,
            this.serviceCalculatorInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceCalculatorProcessInstaller;
        private System.ServiceProcess.ServiceInstaller serviceCalculatorInstaller;
    }
}