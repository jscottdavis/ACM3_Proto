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
        CheckBox _enabled;
        int _linkID;
        int _BSID;
        int _MSID;
        Button _button;
 
        public LinkData(CheckBox enabled, int linkID, int BSID, int MSID, Button button)
        {
            this._enabled = enabled;
            this._linkID = linkID;
            this._BSID = BSID;
            this._MSID = MSID;
            this._button = button;
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

