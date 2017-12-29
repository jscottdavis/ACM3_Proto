using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ACM3_Proto
{
 
    public class LinkData : INotifyPropertyChanged
    {
        public enum LinkDirection { DL, UL, BI };

        CheckBox _enabled;
        int _linkID;
        int _BSID;
        int _MSID;
        Button _button;
        LinkDirection _linkDirection;

        public LinkData(CheckBox enabled, int linkID, int BSID, int MSID, LinkDirection linkDirection, Button button)
        {
            this._enabled = enabled;
            LinkID = linkID;
            this._BSID = BSID;
            this._MSID = MSID;
            this._button = button;
            this._linkDirection = linkDirection;
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

        public int LinkID
        {
            get { return _linkID; }
            set
            {
                if (_linkID != value)
                {
                    if (value > 16)
                        return;

                    _linkID = value;
                    OnPropertyChanged("LinkID");
                }
            }
        }
        public int MSID
        {
            get { return _MSID; }
            set
            {
                if (_MSID != value)
                {
                    _MSID = value;
                    OnPropertyChanged("MSID");
                }
            }
        }
        public int BSID
        {
            get { return _BSID; }
            set
            {
                if (_BSID != value)
                {
                    _BSID = value;
                    OnPropertyChanged("BSID");
                }
            }
        }

        public LinkDirection Direction
        {
            get { return _linkDirection; }
            set
            {
                if (_linkDirection != value)
                {
                    _linkDirection = value;
                    OnPropertyChanged("LinkDirection");
                }
            }
        }

        public Button ChannelModel
        {
            get { return _button; }
            set
            {
                if (_button != value)
                {
                    _button = value;
                    OnPropertyChanged("Channel Model");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}

