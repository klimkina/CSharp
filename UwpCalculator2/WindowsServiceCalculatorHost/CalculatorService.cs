using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using CalculatorService;

namespace WindowsServiceCalculatorHost
{
    public partial class CalculatorHostService : ServiceBase
    {
        public ServiceHost serviceHost = null;
        public CalculatorHostService()
        {
            InitializeComponent();
            ServiceName = "Calculator Host";
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            // Create a ServiceHost for the CalculatorService type and 
            // provide the base address.
            serviceHost = new ServiceHost(typeof(CalculatorService.Calculator));

            // start to watch TeamCity
            StartProcess();
            // Open the ServiceHostBase to create listeners and start 
            // listening for messages.
            serviceHost.Open();
        }

        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }
        private static void StartProcess()
        {

            Console.WriteLine("Starting process");
        }

        const string CONSOLE = "console";
        public static void Main(string[] args)
        {
            if (args.Length == 1 && args[0].Equals(CONSOLE))
            {
                new CalculatorHostService().ConsoleRun();
            }
            else
                ServiceBase.Run(new CalculatorHostService());
        }

        private void ConsoleRun()
        {
            Console.WriteLine(string.Format("{0}::starting...", GetType().FullName));

            OnStart(null);

            Console.WriteLine(string.Format("{0}::ready (ENTER to exit)", GetType().FullName));
            Console.ReadLine();

            OnStop();

            Console.WriteLine(string.Format("{0}::stopped", GetType().FullName));
        }
    }
}
