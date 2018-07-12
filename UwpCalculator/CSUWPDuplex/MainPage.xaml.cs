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
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CSUWPDuplex
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public CalculatorClient MyCalculatorClient { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
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
                
                //new client
                MyCalculatorClient = new CalculatorClient(tcpBinding, new EndpointAddress("net.tcp://localhost:7991/CalculatorService/Calculator/tcp"));
                MyCalculatorClient.ClientCredentials.Windows.ClientCredential.UserName = "DptfTeamCityClient";
                MyCalculatorClient.ClientCredentials.Windows.ClientCredential.Password = "DptfTeamC!tyCl!ent2018";
                //bind call back event
                MyCalculatorClient.ReceiveCalculateResultReceived += MyCalculatorClient_ReceiveCalculateResultReceived;
                await MyCalculatorClient.OpenAsync();
                var deviceInfo = new Windows.Security.ExchangeActiveSyncProvisioning.EasClientDeviceInformation();
                await MyCalculatorClient.RegisterClientAsync(deviceInfo.FriendlyName);
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
