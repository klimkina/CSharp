using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfCallbackService
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
	[ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IServiceCallback))]
	public interface IService
	{
		[OperationContract(IsOneWay =true)]
		void GetData(string userName, string password);
	}

	public interface IServiceCallback
	{
		[OperationContract(IsOneWay = true)]
		void SendResult(Department[] arrDept);
	}

	// Use a data contract as illustrated in the sample below to add composite types to service operations.
	[DataContract]
	public class Department
	{
		public int DeptNo { get; set; }

		[DataMember]
		public string DeptName
		{
			get;
			set;
		}

		[DataMember]
		public int Capacity { get; set; }
	}
}
