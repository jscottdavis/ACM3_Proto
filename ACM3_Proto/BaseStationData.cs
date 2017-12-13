using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM3_Proto
{
    public class BSDataPoint : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private double _X, _Y;

        public string Label { get; set; }
        public double Radius { get; set; }
        public double X
        {
            get { return _X; }
            set { _X = value; OnPropertyChanged("X"); }
        }
        public double Y
        {
            get { return _Y; }
            set { _Y = value; OnPropertyChanged("Y"); }
        }
        void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        } 
    }

    public class BSDataSource : List<BSDataPoint>
    {
        public List<BSDataPoint> Data { get { return bsData; } set { bsData = value; }  }
        private List<BSDataPoint> bsData;
    
        public BSDataSource()
        {
            this.Add(new BSDataPoint
            {
                Label = "1",
                Radius = 20,
                X = 757,
                Y = 338
            });

            this.Add(new BSDataPoint
            {
                Label = "2",
                Radius = 20,
                X = 512,
                Y = -265
            });

            this.Add(new BSDataPoint
            {
                Label = "3",
                Radius = 20,
                X = -267,
                Y = 898
            });

            this.Add(new BSDataPoint
            {
                Label = "4",
                Radius = 20,
                X = -13,
                Y = -422
            });

            bsData = this;
        }
    }

    }


