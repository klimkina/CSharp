using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;

namespace WcfCallbackService
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
	public class Service : IService
	{
		public IServiceCallback CallBack
		{
			get
			{
				return OperationContext.Current.GetCallbackChannel<IServiceCallback>();
			}
		}
		public void GetData(string userName, string password)
		{
			Department[] arrDept = new Department[]
			{
				new Department(){DeptNo=10, DeptName="IT", Capacity=4500 },
				new Department(){DeptNo=20, DeptName="HRD", Capacity=200 },
				new Department(){DeptNo=30, DeptName="ACCTS", Capacity=40 }
			};

			if (userName.Trim() == "Mila" && password == "1")
			{
				Thread.Sleep(10000);
				CallBack.SendResult(arrDept);
			}

		}
	}
}
