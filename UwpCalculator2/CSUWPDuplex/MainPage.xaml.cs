using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CSUWPDuplex.CalculatorService;
using System.ServiceModel;
using Windows.ApplicationModel.Background;
using Windows.System.Threading;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CSUWPDuplex
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static MainPage Current;

        public const string TimeTriggeredTaskName = "TimeTriggeredTask";
        public static string TimeTriggeredTaskProgress = "";
        BackgroundTaskCancellationReason _cancelReason = BackgroundTaskCancellationReason.Abort;
        volatile bool _cancelRequested = false;
        public static bool TimeTriggeredTaskRegistered = false;
        BackgroundTaskDeferral _deferral = null;
        ThreadPoolTimer _periodicTimer = null;
        uint _progress = 0;
        IBackgroundTaskInstance _taskInstance = null;

        public CalculatorClient MyCalculatorClient { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            Current = this;
            RegisterBackgroundTask(null, "TimeTriggeredTaskName", new TimeTrigger(15, false));
        }

        //
        // The Run method is the entry point of a background task.
        //
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            
            //
            // Query BackgroundWorkCost
            // Guidance: If BackgroundWorkCost is high, then perform only the minimum amount
            // of work in the background task and return immediately.
            //
            var cost = BackgroundWorkCost.CurrentBackgroundWorkCost;

            //
            // Associate a cancellation handler with the background task.
            //
            taskInstance.Canceled += new BackgroundTaskCanceledEventHandler(OnCanceled);

            //
            // Get the deferral object from the task instance, and take a reference to the taskInstance;
            //
            _deferral = taskInstance.GetDeferral();
            _taskInstance = taskInstance;

            _periodicTimer = ThreadPoolTimer.CreatePeriodicTimer(new TimerElapsedHandler(PeriodicTimerCallback), TimeSpan.FromSeconds(1));
        }

        //
        // Handles background task cancellation.
        //
        private void OnCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            //
            // Indicate that the background task is canceled.
            //
            _cancelRequested = true;
            _cancelReason = reason;
        }

        //
        // Simulate the background task activity.
        //
        private void PeriodicTimerCallback(ThreadPoolTimer timer)
        {
            if ((_cancelRequested == false) && (_progress < 100))
            {
                _progress += 10;
                _taskInstance.Progress = _progress;
            }
            else
            {
                _periodicTimer.Cancel();

                var key = _taskInstance.Task.Name;

                //
                // Record that this background task ran.
                //
                String taskStatus = (_progress < 100) ? "Canceled with reason: " + _cancelReason.ToString() : "Completed";
               
                //
                // Indicate that the background task has completed.
                //
                _deferral.Complete();
            }
        }
       
        public static void Start(IBackgroundTaskInstance taskInstance)
        {
            // Use the taskInstance.Name and/or taskInstance.InstanceId to determine
            // what background activity to perform. In this sample, all of our
            // background activities are the same, so there is nothing to check.
            taskInstance.Canceled += new BackgroundTaskCanceledEventHandler(OnCanceled);

            //
            // Get the deferral object from the task instance, and take a reference to the taskInstance;
            //
            _deferral = taskInstance.GetDeferral();
            _taskInstance = taskInstance;

            _periodicTimer = ThreadPoolTimer.CreatePeriodicTimer(new TimerElapsedHandler(PeriodicTimerCallback), TimeSpan.FromSeconds(1));
        }

        /// <summary>
        /// Register a background task with the specified taskEntryPoint, name, trigger,
        /// and condition (optional).
        /// </summary>
        /// <param name="taskEntryPoint">Task entry point for the background task.</param>
        /// <param name="name">A name for the background task.</param>
        /// <param name="trigger">The trigger for the background task.</param>
        /// <param name="condition">An optional conditional event that must be true for the task to fire.</param>
        public static BackgroundTaskRegistration RegisterBackgroundTask(String taskEntryPoint, String name, IBackgroundTrigger trigger)
        {
            var requestTask = BackgroundExecutionManager.RequestAccessAsync();
            
            var builder = new BackgroundTaskBuilder();

            builder.Name = name;

            if (taskEntryPoint != null)
            {
                // If you leave the TaskEntryPoint at its default value, then the task runs
                // inside the main process from OnBackgroundActivated rather than as a separate process.
                builder.TaskEntryPoint = taskEntryPoint;
            }

            builder.SetTrigger(trigger);

            BackgroundTaskRegistration task = builder.Register();
            return task;
        }

        /// <summary>
        /// Unregister background tasks with specified name.
        /// </summary>
        /// <param name="name">Name of the background task to unregister.</param>
        public static void UnregisterBackgroundTasks(String name)
        {
            //
            // If the given task group is registered then loop through all background tasks associated with it
            // and unregister any with the given name.
            //
            
                //
                // Loop through all ungrouped background tasks and unregister any with the given name.
                //
                foreach (var cur in BackgroundTaskRegistration.AllTasks)
                {
                    if (cur.Value.Name == name)
                    {
                        cur.Value.Unregister(true);
                    }
                }
           
        }

        private async void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri((sender as HyperlinkButton).Tag.ToString()));
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //Add items to the operator list.
            this.cbxOperators.Items.Add("Add");
            this.cbxOperators.Items.Add("Subtract");
            this.cbxOperators.Items.Add("Multiply");
            this.cbxOperators.Items.Add("Divide");
            this.cbxOperators.SelectedIndex = 0;
            try
            {
                //set binding
                NetTcpBinding tcpBinding = new NetTcpBinding();
                tcpBinding.Security.Mode = SecurityMode.None;
                tcpBinding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
                tcpBinding.Security.Message.ClientCredentialType = MessageCredentialType.None;
                tcpBinding.ReceiveTimeout = TimeSpan.FromHours(10);

                //new client
                MyCalculatorClient = new CalculatorClient(tcpBinding, new EndpointAddress("net.tcp://localhost:7991/CalculatorService/Calculator/tcp"));
                MyCalculatorClient.ClientCredentials.Windows.ClientCredential.UserName = "DptfTeamCityClient";
                MyCalculatorClient.ClientCredentials.Windows.ClientCredential.Password = "DptfTeamC!tyCl!ent2018";
                //bind call back event
                MyCalculatorClient.ReceiveCalculateResultReceived += MyCalculatorClient_ReceiveCalculateResultReceived;
                await MyCalculatorClient.OpenAsync();
                var deviceInfo = new Windows.Security.ExchangeActiveSyncProvisioning.EasClientDeviceInformation();
                //await MyCalculatorClient.RegisterClientAsync(deviceInfo.FriendlyName);
                MyCalculatorClient.BroadcastToClientReceived += MyCalculatorClient_ReceiveBroadcastReceived;
            }
            catch (Exception ex)
            {

            }
        }

        private async void MyCalculatorClient_ReceiveBroadcastReceived(object sender, BroadcastToClientReceivedEventArgs e)
        {
            //Schedules the provided callback on the UI thread.
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                if (string.IsNullOrEmpty(e.message))
                {
                    this.tbResult.Text += $"{e.message}\n";
                }
            });
        }

        private async void MyCalculatorClient_ReceiveCalculateResultReceived(object sender, ReceiveCalculateResultReceivedEventArgs e)
        {
            //Schedules the provided callback on the UI thread.
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                if (string.IsNullOrEmpty(e.data.Message))
                {
                    this.tbResult.Text += $"{e.data.Number1} {e.data.Operator} {e.data.Number2}= {e.data.Result}\n";
                }
                else
                {
                    this.tbResult.Text += $"{e.data.Number1} {e.data.Operator} {e.data.Number2}: {e.data.Message}\n";
                }
            });
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (this.cbxOperators.SelectedIndex > -1 && !string.IsNullOrWhiteSpace(tbNumber1.Text) && !string.IsNullOrWhiteSpace(tbNumber2.Text))
            {
                string strNumber1 = tbNumber1.Text.Trim();
                string strNumber2 = tbNumber2.Text.Trim();
                double number1;
                double number2;
                if (!double.TryParse(strNumber1, out number1))
                {
                    this.tbResult.Text += $"Can't parse {strNumber1} to double.";
                }
                if (!double.TryParse(strNumber2, out number2))
                {
                    this.tbResult.Text += $"Can't parse {strNumber2} to double.";
                }
                try
                {
                    switch (this.cbxOperators.SelectedValue.ToString())
                    {
                        case "Add": MyCalculatorClient.AddAsync(number1, number2); break;
                        case "Subtract": MyCalculatorClient.SubtractAsync(number1, number2); break;
                        case "Multiply": MyCalculatorClient.MultiplyAsync(number1, number2); break;
                        case "Divide": MyCalculatorClient.DivideAsync(number1, number2); break;
                        default: break;
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        private async void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            await MyCalculatorClient.CloseAsync();
        }
    }
}
