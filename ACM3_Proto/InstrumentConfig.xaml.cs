using Infragistics.Windows.DataPresenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace ACM3_Proto
{
    /// <summary>
    /// Interaction logic for InstrumentConfig.xaml
    /// </summary>
    public partial class InstrumentConfig : Window
    {
        public InstrumentConfig()
        {
            InitializeComponent();

            CheckBox checkBox1 = new CheckBox();
            checkBox1.IsChecked = true;
            checkBox1.VerticalContentAlignment = VerticalAlignment.Center;
            CheckBox checkBox2 = new CheckBox();
            checkBox2.IsChecked = true;
            checkBox2.VerticalContentAlignment = VerticalAlignment.Center;
            CheckBox checkBox3 = new CheckBox();
            checkBox3.IsChecked = true;
            checkBox3.VerticalContentAlignment = VerticalAlignment.Center;

            InstrumentData instrumentData1 = new InstrumentData(checkBox1, "Vertex Channel Emulator #1", "192.168.100.10");
            this.InstrumentConfigDataSource.DataItems.Add(instrumentData1);
            InstrumentData instrumentData2 = new InstrumentData(checkBox2, "Vertex Channel Emulator #2", "192.168.100.11");
            this.InstrumentConfigDataSource.DataItems.Add(instrumentData2);
            InstrumentData instrumentData3 = new InstrumentData(checkBox3, "Topyoung Phase Shifter", "192.168.100.53");
            this.InstrumentConfigDataSource.DataItems.Add(instrumentData3);

            //this.InstrumentConfigDataSource.FieldLayouts[0].Fields["Enabled"].Width = new FieldLength(10);
        }
    }

    public class InstrumentData : INotifyPropertyChanged
    {
        CheckBox _enabled;
        string _name;
        string _address;
        public event PropertyChangedEventHandler PropertyChanged;

        public InstrumentData(CheckBox enabled, string name, string address)
        {
            this._enabled = enabled;
            this._name = name;
            this._address = address;
        }
        public CheckBox Enabled
        {
            get { return _enabled; }
            set
            {
                if (_enabled != value)
                {
                    _enabled = value;
                    OnPropertyChanged("Enabled");
                }
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string Address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged("Address");
                }
            }
        }

        private void OnPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
