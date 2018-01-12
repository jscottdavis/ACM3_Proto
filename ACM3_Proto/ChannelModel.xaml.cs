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

namespace ACM3_Proto
{
    /// <summary>
    /// Interaction logic for ChannelModel.xaml
    /// </summary>
    public partial class ChannelModel : Page
    {
        private bool isLoaded = false;

         public ChannelModel()
        {
            InitializeComponent();

            Messenger.Default.Register<AppMessage>(this, (action) => ReceiveAMessage(action));

            isLoaded = true;
        }

        public void SetLinkID(int linkID)
        {
            this.ComboLinkID.SelectedIndex = linkID;
        }

        // central message handler for the MainWindow
        private object ReceiveAMessage(AppMessage msg)
        {
            switch (msg.Type)
            {
                case AppMessage.MsgType.ActivateChannelModelTab:
                     this.ComboLinkID.SelectedIndex = (int)msg.Param0;
                    break;
            }
            return null;
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

        private void ParameterChanged(object sender, SelectionChangedEventArgs e)
        {
            int customIndex = 3;

            if (isLoaded)
            {
                if (sender == this.ChannelModelType)
                {
                    if (this.ChannelModelType.SelectedIndex != customIndex)
                    {
                        ComboBoxItem myItem = (ComboBoxItem)this.ChannelModelType.Items[customIndex];
                        myItem.Visibility = Visibility.Collapsed;

                        isLoaded = false;
                        this.PowerAngleSpectrum.SelectedIndex = 0;
                        isLoaded = true;
                    }
                }
                else
                {
                    ComboBoxItem myItem = (ComboBoxItem)this.ChannelModelType.Items[customIndex];
                    myItem.Visibility = Visibility.Visible;
                    this.ChannelModelType.SelectedIndex = customIndex;
                }
            }
        }
    }
}
