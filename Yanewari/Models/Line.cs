using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanewari.Models
{
    /// <summary>
    /// 直線の描画オブジェクトと長さを保持
    /// </summary>
    class Line
    {
        public double X1 { get; set; }
        public double X2 { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }

        public Line(double max, double display, double height, double x)
        {
            X1 = x/max*display;
            Y1 = 0;
            X2 = x/max*display;
            Y2 = height/max*display;
        }
        public Line(double X1, double X2, double Y1, double Y2, double max, double display)
        {
            this.X1 = X1/max*display;
            this.X2 = X2/max*display;
            this.Y1 = Y1/max*display;
            this.Y2 = Y2/max*display;
        }
    }
}
