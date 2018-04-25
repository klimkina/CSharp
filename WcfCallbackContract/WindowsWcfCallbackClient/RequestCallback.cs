using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsWcfCallbackClient.MyRef;

namespace WindowsWcfCallbackClient
{
	class RequestCallback : IServiceCallback
	{
		private WcfCallbackService.Department[] _departments;

		public WcfCallbackService.Department[] Departments
		{
			get { return _departments; }
			set { _departments = value; }
		}
		public void SendResult(WcfCallbackService.Department[] arrDept)
		{
			_departments = arrDept;
			MessageBox.Show("Responces Received: " + Departments.Count().ToString());
		}
	}
}
