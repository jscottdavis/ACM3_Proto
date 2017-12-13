using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM3_Proto
{
    public class MSDataPoint
    {
        public int Index { get; set; } 
        public double X { get; set; }
        public double Y { get; set; }
    }

    public class MSDataSource : List<MSDataPoint>
    {
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
            
        }
    }
}
