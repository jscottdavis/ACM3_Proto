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

namespace ACM3_Proto
{
     /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BSDataSource myDataSource;
        public MainWindow()
        {
            InitializeComponent();

            myDataSource = new BSDataSource();
            this.DataContext = myDataSource;
            this.NetworkLayout1.Series[0].ItemsSource = myDataSource;
        }
     }
}
