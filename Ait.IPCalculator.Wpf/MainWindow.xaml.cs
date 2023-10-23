using Ait.IPCalculator.Lib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Ait.IPCalculator.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SubnetmaskerService subnetmaskerService;
       
        public MainWindow()
        {
            InitializeComponent();

            subnetmaskerService = new SubnetmaskerService();

            foreach(var item in subnetmaskerService.Sunbnetmaskers)
            {
                var ComboBoxItem = new ComboBoxItem();
                ComboBoxItem.Content = item;
           
                ComboBoxItem.Tag = item.Subnetmasker;
                cmbSubnet.Items.Add(ComboBoxItem);
            }

            // your code here...

           
            
        }



        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            ClearControls();
            // your code here ...

            IPAddress iPAddress;

            bool ValidateIpAddress = IPAddress.TryParse(txtIP.Text, out iPAddress);

            if(ValidateIpAddress == true)
            {

                if(cmbSubnet.SelectedIndex >= 0)
                {
                    iPAddress = IPAddress.Parse(txtIP.Text);
                    string ipInBits = CalculatorService.ConvertIPAddressToStringOffBits(iPAddress);
                    txtIPBit.Text = ipInBits;
                    
                    
                    //

                    int subnetmaskerCdir = Convert.ToInt32(subnetmaskerService.Sunbnetmaskers[cmbSubnet.SelectedIndex].CdirPrefix);
                    var subnetmaskString = ((ComboBoxItem)cmbSubnet.SelectedItem).Tag.ToString();

                    //

                    IPAddress SubnetMask = IPAddress.Parse(subnetmaskString);
                    string subnetBits = CalculatorService.ConvertIPAddressToStringOffBits(SubnetMask);
                    txtSubnetBit.Text = subnetBits;
                   
                    string networkAddressInBits = CalculatorService.CalculateNetworkAddressFromIpAndCdir(ipInBits, subnetmaskerCdir);
                    txtNetworkAddressBit.Text = networkAddressInBits;
                    string networkAddressInDigits = CalculatorService.ConvertBitsToStringOffDigits(networkAddressInBits);

                    txtNetworkAddressDD.Text = networkAddressInDigits;

                    //

                    string firstHostAddressInBits = CalculatorService.CalculateFirstHostAddressInBitsByNetworkAddressInBits(networkAddressInBits, subnetmaskerCdir);

                    txtFirstHostAddressBit.Text = firstHostAddressInBits;

                    string firstHostAddressInDigits = CalculatorService.ConvertBitsToStringOffDigits(firstHostAddressInBits);

                    txtFirstHostAddressDD.Text = firstHostAddressInDigits;

                    //

                    string maxHostInBits = CalculatorService.ConvertedHostMinInBitsToHostMaxInBits(firstHostAddressInBits,subnetmaskerCdir);

                    txtLastHostAddressBit.Text = maxHostInBits;

                    string maxHostInDigits = CalculatorService.ConvertBitsToStringOffDigits(maxHostInBits);

                    txtLastHostAddressDD.Text = maxHostInDigits;

                    //

                    string broadcastAddressBits = CalculatorService.FindBroadcastAddress(maxHostInBits);


                    txtBroadcastAddressBit.Text = broadcastAddressBits;

                    string broadcastAddressDigits = CalculatorService.ConvertBitsToStringOffDigits(broadcastAddressBits);

                    txtBroadcastAddressDD.Text = broadcastAddressDigits;


                    double maxPossibleHosts = CalculatorService.CalculateMaxNumbersOfHosts(subnetmaskerCdir);


                    txtMaxNumberOfHosts.Text = $"{maxPossibleHosts}";

                    string networkClass = CalculatorService.CalculateNetworkClassOffIpAddress(ipInBits);

                    txtNetworkClass.Text = networkClass;

                    string networkType = CalculatorService.CheckNetworkTypeIpAddress(ipInBits);

                    txtNetworkType.Text = networkType;




                }

                else
                {
                    MessageBox.Show("Select a subnet from the combobox first");
                }

            }

            else
            {
                MessageBox.Show("The IP address is not a valid IP");
            }

            
 
        }
        private void ClearControls()
        {
            txtIPBit.Text = "";
            txtSubnetBit.Text = "";
            txtNetworkAddressBit.Text = "";
            txtNetworkAddressDD.Text = "";
            txtFirstHostAddressBit.Text = "";
            txtFirstHostAddressDD.Text = "";
            txtLastHostAddressBit.Text = "";
            txtLastHostAddressDD.Text = "";
            txtBroadcastAddressBit.Text = "";
            txtBroadcastAddressDD.Text = "";
            txtMaxNumberOfHosts.Text = "";
            txtNetworkClass.Text = "";
            txtNetworkType.Text = "";

        }

        private void cmbSubnet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearControls();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //IPAddress ip = new IPAddress(new byte[] { 192, 168, 20, 11 });

            //string array = CalculatorService.ConvertIPAddressToStringOffBits(ip);

            
           
            //MessageBox.Show(array);

           
        }
    }
}
