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

namespace CallbackHost
{
	public partial class CallbackHostService : ServiceBase
	{
		public CallbackHostService()
		{
			InitializeComponent();
		}

		public ServiceHost serviceHost = null;
		/// 
		/// Called by the SCM when the service starts
		/// 
		protected override void OnStart(string[] args)
		{
			if (serviceHost != null)
			{
				serviceHost.Close();
			}

			// Create a ServiceHost for the TrayNotifyService type and 
			// provide the base address.
			serviceHost = new ServiceHost(typeof(WcfCallbackService.Service));

			// Open the ServiceHostBase to create listeners and start 
			// listening for messages.
			serviceHost.Open();
		}
		/// 
		/// Called by the SCM when the service is shutdown
		/// 
		protected override void OnShutdown()
		{
			OnStop();
			serviceHost = null;

		}
		/// 
		/// Called by the SCM when the service is stopped
		/// 
		protected override void OnStop()
		{
			if (serviceHost != null)
			{
				serviceHost.Close();
				serviceHost = null;
			}
		}

		public static void Main()
		{
			ServiceBase.Run(new CallbackHostService());
		}
	}
}
