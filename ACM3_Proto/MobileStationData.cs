using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM3_Proto
{
    public class MSDataPoint : INotifyPropertyChanged
    {
        double _OriginX;
           

        public event PropertyChangedEventHandler PropertyChanged;
        public int Index { get; set; } 
        public double X { get; set; }
        public double Y { get; set; }
        public double OriginY { get; set; }
        public double OriginX { get { return _OriginX; } set { _OriginX = value; OnPropertyChanged("X"); } }
        public double Radius { get; set; }
        public double Velocity { get; set; }
        void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class MSDataSource : List<MSDataPoint>
    {
        public List<MSDataPoint> Data { get { return MsData; } set { MsData = value; } }
        private List<MSDataPoint> MsData;

        public MSDataSource()
        {
            double OriginX = 37, OriginY = -216, Radius = 118, NumPoints = 12;
            double X, Y, angle;

            for (int i=0; i<NumPoints; i++)
            {
                angle = 2 * Math.PI / NumPoints * i;
                X = OriginX + Math.Cos(angle)*Radius;
                Y = OriginY + Math.Sin(angle)*Radius;
                this.Add(new MSDataPoint { Index = i+1, X = X, Y = Y });
            }

            MsData = this;            
        }
    }
}
