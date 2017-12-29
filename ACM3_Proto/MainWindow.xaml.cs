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
using GalaSoft.MvvmLight.Messaging;
using Infragistics.Windows.DataPresenter;

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

            Messenger.Default.Register<AppMessage>(this, (action) => ReceiveAMessage(action));
        }

        // central message handler for the MainWindow
        private object ReceiveAMessage(AppMessage msg)
        {
            switch (msg.Type)
            {
                case AppMessage.MsgType.ActivateChannelModelTab:
                    this.CenterTab.SelectedIndex = 2;
                    this.ComboLinkID.SelectedIndex = (int)msg.Param0;
                    break;
            }
            return null;
        }

         private void Menu_Instruments_Click(object sender, RoutedEventArgs e)
        {
            InstrumentConfig instrumentConfig = new InstrumentConfig();
            instrumentConfig.ShowDialog();
        }

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            // ... Create a new BitmapImage.
            BitmapImage b = new BitmapImage();
            b.BeginInit();
            b.UriSource = new Uri(Environment.CurrentDirectory + "\\8x2.png");
            b.EndInit();

            // ... Get Image reference from sender.
            var image = sender as Image;
            // ... Assign Source.
            image.Source = b;
        }

        private void Link_Loaded(object sender, RoutedEventArgs e)
        {
            // ... Create a new BitmapImage.
            BitmapImage b = new BitmapImage();
            b.BeginInit();
            b.UriSource = new Uri(Environment.CurrentDirectory + "\\link.png");
            b.EndInit();

            // ... Get Image reference from sender.
            var image = sender as Image;
            // ... Assign Source.
            image.Source = b;

        }

        //private void BS_Loaded(object sender, RoutedEventArgs e)
        //{
        //    // ... Create a new BitmapImage.
        //    BitmapImage b = new BitmapImage();
        //    b.BeginInit();
        //    b.UriSource = new Uri(Environment.CurrentDirectory + "\\BaseStation.bmp");
        //    b.EndInit();

        //    // ... Get Image reference from sender.
        //    var image = sender as Image;
        //    // ... Assign Source.
        //    image.Source = b;

        //}
    }

 
}
