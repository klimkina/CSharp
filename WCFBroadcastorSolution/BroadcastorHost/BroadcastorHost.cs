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

namespace BroadcastorHost
{
	public partial class BroadcastorHostService : ServiceBase
	{
		public ServiceHost serviceHost = null;
		public BroadcastorHostService()
		{
			InitializeComponent();
			//ServiceName = "Publisher Host";
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
			serviceHost = new ServiceHost(typeof(BroadcastorService.BroadcastorService));

			// Open the ServiceHostBase to create listeners and start 
			// listening for messages.
			serviceHost.Open();
		}

		protected override void OnStop()
		{
			// TODO: Add code here to perform any tear-down necessary to stop your service.
			if (serviceHost != null)
			{
				serviceHost.Close();
				serviceHost = null;
			}
		}

		public static void Main()
		{
			ServiceBase.Run(new BroadcastorHostService());
		}
	}
}
