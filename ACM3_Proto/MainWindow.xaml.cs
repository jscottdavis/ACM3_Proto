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
using Infragistics.Windows.DataPresenter;

namespace ACM3_Proto
{
     /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BSDataSource myDataSource;
        MSDataSource msDataSource;
        public MainWindow()
        {
            InitializeComponent();

            myDataSource = new BSDataSource();
            this.DataContext = myDataSource;
            this.NetworkLayout1.Series[0].ItemsSource = myDataSource;

            System.Windows.Thickness thickness = new Thickness(2, 2, 2, 2);
            Button button1 = new Button();
            button1.Content = "Edit";
            button1.Margin = thickness;
            Button button2 = new Button();
            button2.Content = "Edit";
            button2.Margin = thickness;
            Button button3 = new Button();
            button3.Content = "Edit";
            button3.Margin = thickness;
            // button.Width = 50;
            this.LinkDataSource.DataItems.Add(new LinkData(1, 1, 1, button1));
            this.LinkDataSource.DataItems.Add(new LinkData(2, 2, 1, button2));
            this.LinkDataSource.DataItems.Add(new LinkData(3, 2, 3, button3));

            //this.LinkDataSource.DataItems[0].FieldLayouts[0].Fields["LinkID"].Width = new FieldLength(50);
            //this.LinkDataSource.FieldLayouts[0].Fields["BSID"].Width = new FieldLength(50);
            //this.LinkDataSource.FieldLayouts[0].Fields["MSID"].Width = new FieldLength(50);
        }
    }
}
