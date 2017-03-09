using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Threading;
using ZigBeeLibrary;
using ComLibrary;
using DigitalLibrary;

namespace ADAMMoni
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        DispatcherTimer dst = new DispatcherTimer();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dst.Tick += Dst_Tick;
            dst.Interval = new TimeSpan(0, 0, 1);
            dst.Start();
        }

        private void Dst_Tick(object sender, EventArgs e)
        {
            ZigBeeLibrary.ComSettingModel zig = new ZigBeeLibrary.ComSettingModel();
            zig.ZigbeeCom="com3";

            DigitalLibrary.ComSettingModel adam = new DigitalLibrary.ComSettingModel();
            adam.DigitalQuantityCom = "com2";

            ZigBee zigb = new ZigBee(zig);
            zigb.GetSet();

            ADAM4150 ada = new ADAM4150(adam);
            ada.SetData();
            
            textBox.Text = zigb.temperatureValue;
            textBox1.Text = zigb.humidityValue;
            textBox5.Text = zigb.lightValue;
            textBox2.Text = ada.DI2.ToString();
            textBox3.Text = ada.DI1.ToString();
            textBox4.Text = ada.DI0.ToString();
            textBox6.Text = ada.DI4.ToString();

        }



        private void button_Click(object sender, RoutedEventArgs e)
        {
            DigitalLibrary.ComSettingModel csm = new DigitalLibrary.ComSettingModel();
            csm.DigitalQuantityCom = "com2";
            ADAM4150 adam = new ADAM4150(csm);

            if (button.Tag.ToString()=="1")
            {
                adam.OnOff(ADAM4150FuncID.OffDO2);
                button.Tag = "0";
            }
            else
            {
                adam.OnOff(ADAM4150FuncID.OnDO2);
                button.Tag = "1";
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            DigitalLibrary.ComSettingModel csm = new DigitalLibrary.ComSettingModel();
            csm.DigitalQuantityCom = "com2";
            ADAM4150 adam = new ADAM4150(csm);

            if (button1.Tag.ToString() == "1")
            {
                adam.OnOff(ADAM4150FuncID.OffDO0);
                button1.Tag = "0";
            }
            else
            {
                adam.OnOff(ADAM4150FuncID.OnDO0);
                button1.Tag = "1";
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            DigitalLibrary.ComSettingModel csm = new DigitalLibrary.ComSettingModel();
            csm.DigitalQuantityCom = "com2";
            ADAM4150 adam = new ADAM4150(csm);

            if (button2.Tag.ToString() == "1")
            {
                adam.OnOff(ADAM4150FuncID.OffDO1);
                button2.Tag = "0";
            }
            else
            {
                adam.OnOff(ADAM4150FuncID.OnDO1);
                button2.Tag = "1";
            }
        }
    }
}
