using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CalculatorService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(ICalculatorCallback),
                         SessionMode = SessionMode.Required)]
    public interface ICalculator
    {
        [OperationContract(IsOneWay = true)]
        void RegisterClient(string clientName);
        [OperationContract]
        void Add(double n1, double n2);
        [OperationContract]
        void Subtract(double n1, double n2);
        [OperationContract]
        void Multiply(double n1, double n2);
        [OperationContract]
        void Divide(double n1, double n2);
    }


    public interface ICalculatorCallback
    {
        [OperationContract(IsOneWay = true)]
        void ReceiveCalculateResult(CalculateData data);
        [OperationContract(IsOneWay = true)]
        void BroadcastToClient(string message);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CalculateData
    {
        [DataMember]
        public double Number1 { get; set; }
        [DataMember]
        public double Number2 { get; set; }
        [DataMember]
        public double Result { get; set; }
        [DataMember]
        public string Operator { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}
