using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsWcfCallbackClient.MyRef;

namespace WindowsWcfCallbackClient
{
	using System.Linq;

	public partial class frmDepartments : Form
	{
		MyRef.ServiceClient Proxy;
		RequestCallback _callback;
		public frmDepartments()
		{
			InitializeComponent();
		}

		private void btnGetData_Click(object sender, EventArgs e)
		{
			Proxy.GetData("Mila", "1");
			MessageBox.Show("Values are sent to the service");
			dgvDept.DataSource = _callback.Departments;
		}

		private void frmDepartments_Load(object sender, EventArgs e)
		{
			_callback = new RequestCallback();
			System.ServiceModel.InstanceContext context = new System.ServiceModel.InstanceContext(_callback);
			Proxy = new MyRef.ServiceClient(context);
		}
	}
}
