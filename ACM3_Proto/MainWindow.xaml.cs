﻿using System;
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
            button1.Click += this.DisplayChannelModel;
            Button button2 = new Button();
            button2.Content = "Edit";
            button2.Margin = thickness;
            button2.Click += this.DisplayChannelModel;
            Button button3 = new Button();
            button3.Content = "Edit";
            button3.Margin = thickness;
            button3.Click += this.DisplayChannelModel;
            // button.Width = 50;
            this.LinkDataSource.DataItems.Add(new LinkData(1, 1, 1, button1));
            this.LinkDataSource.DataItems.Add(new LinkData(2, 2, 1, button2));
            this.LinkDataSource.DataItems.Add(new LinkData(3, 2, 3, button3));

            //this.LinkDataSource.DataItems[0].FieldLayouts[0].Fields["LinkID"].Width = new FieldLength(50);
            //this.LinkDataSource.FieldLayouts[0].Fields["BSID"].Width = new FieldLength(50);
            //this.LinkDataSource.FieldLayouts[0].Fields["MSID"].Width = new FieldLength(50);
        }

        private void DisplayChannelModel(object sender, RoutedEventArgs e)
        {
            // When user clicks the edit button, switch the view to show Channel Model GUI
            this.CenterTab.SelectedIndex = 1;
            this.ComboLinkID.SelectedIndex = 1;
            //ChannelModel model = new ChannelModel();
            //model.Show();
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
    }

 
}
