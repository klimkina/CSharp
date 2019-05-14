using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CalculatorService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class Calculator : System.Timers.Timer, ICalculator
    {
        private static Dictionary<string, ICalculatorCallback> clients =
                new Dictionary<string, ICalculatorCallback>();
        private static object locker = new object();

        public Calculator()
        {
            base.Interval = 300 * 1000; //milliseconds
            this.Enabled = true;
            this.AutoReset = true;//repeat
            this.Elapsed += new System.Timers.ElapsedEventHandler(Calculator_Elapsed);
        }

        private void Calculator_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (clients != null && clients.Count > 0)
            {
                NotifyClients("Current time is: " + DateTime.Now.TimeOfDay.ToString());
            }
        }

        public void NotifyClients(string message)
        {
            lock (locker)
            {
                var inactiveClients = new List<string>();
                foreach (var client in clients)
                {
                    try
                    {
                        client.Value.BroadcastToClient(message);
                    }
                    catch (Exception ex)
                    {
                        inactiveClients.Add(client.Key);
                    }
                }

                if (inactiveClients.Count > 0)
                {
                    foreach (var client in inactiveClients)
                    {
                        clients.Remove(client);
                    }
                }
            }
        }
        public ICalculatorCallback CurrentCallback
        {
            get
            {
                return OperationContext.Current.
                       GetCallbackChannel<ICalculatorCallback>();
            }
        }

        public void RegisterClient(string clientName)
        {
            if (clientName != null && clientName != "")
            {
                try
                {
                    lock (locker)
                    {
                        //remove the old client
                        if (clients.Keys.Contains(clientName))
                            clients.Remove(clientName);
                        clients.Add(clientName, CurrentCallback);
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        public void Add(double n1, double n2)
        {
            CalculateData data = new CalculateData { Number1 = n1, Number2 = n2, Operator ="+", Result = n1 + n2, Message = string.Empty };
            CurrentCallback.ReceiveCalculateResult(data);
        }

        public void Divide(double n1, double n2)
        {
            double result = n2 == 0 ? 0 : n1 / n2;
            string message = n2 == 0 ? "Failed! n2 should not be 0!" : string.Empty;
            CalculateData data = new CalculateData { Number1 = n1, Number2 = n2, Operator = "/", Result = result, Message = message };
            CurrentCallback.ReceiveCalculateResult(data);
        }

        public void Multiply(double n1, double n2)
        {
            CalculateData data = new CalculateData { Number1 = n1, Number2 = n2, Operator ="x", Result = n1 * n2, Message = string.Empty };
            CurrentCallback.ReceiveCalculateResult(data);
        }

        public void Subtract(double n1, double n2)
        {
            CalculateData data = new CalculateData { Number1 = n1, Number2 = n2, Operator = "-", Result = n1 - n2, Message = string.Empty };
            CurrentCallback.ReceiveCalculateResult(data);
        }
    }
}
