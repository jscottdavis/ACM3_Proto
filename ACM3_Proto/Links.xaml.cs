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
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;
using Infragistics.Windows.DataPresenter;

namespace ACM3_Proto
{
    /// <summary>
    /// Interaction logic for Links.xaml
    /// </summary>
    public partial class Links : Page
    {
        const int MaxLinks = 16; // 4 Base Station * 2 Mobile Station * 2 directions (DL/UL for FDD mode)

        public XamDataPresenter DataSource
        {
            get { return this.LinkDataSource; }
        }

        public Links()
        {
            InitializeComponent();

            System.Windows.Thickness thickness = new Thickness(2, 2, 2, 2);
            Button[] button = new Button[MaxLinks];
            CheckBox[] cb = new CheckBox[MaxLinks];
            LinkData.LinkDirection direction;

            for (int i = 0; i < MaxLinks; i++)
            {
                cb[i] = new CheckBox();
                cb[i].IsChecked = true;

                button[i] = new Button();
                button[i].Content = "Edit";
                button[i].Margin = thickness;
                button[i].Click += DisplayChannelModel;
                button[i].Tag = i;  //this helps identify which button was clicked

                if (i % 2 == 0)
                    direction = LinkData.LinkDirection.DL;
                else
                    direction = LinkData.LinkDirection.UL;

                this.LinkDataSource.DataItems.Add(new LinkData(cb[i], i+1, (i % 4)+1, (i % 2)+1, direction, button[i]));
            }
        }

        public void DisplayChannelModel(object sender, RoutedEventArgs e)
        {
            // When user clicks the edit button, switch the view to show Channel Model GUI
            Button button = (Button)e.Source;

            var msg = new AppMessage { Type=AppMessage.MsgType.ActivateChannelModelTab, Param0 = button.Tag };
            Messenger.Default.Send<AppMessage>(msg);
         }

    }
}
