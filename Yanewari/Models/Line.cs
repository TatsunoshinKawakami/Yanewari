using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanewari.Models
{
    class Line
    {
        public double X1 { get { return x1; } set { x1 = value; } }
        public double X2 { get { return x2; } set { x2 = value; } }
        public double Y1 { get { return y1; } set { y1 = value; } }
        public double Y2 { get { return y2; } set { y2 = value; } }
        public double X1D { get { return x1 / max * display; } set { } }
        public double X2D { get { return x2 / max * display; } set { } }
        public double Y1D { get { return y1 / max * display; } set { } }
        public double Y2D { get { return y2 / max * display; } set { } }
        public string RealValue { get; set; }
        public double PostionY { get { return (y1 + y2) / 2 / max * display; } set { } }
        public bool IsView { get; set; }

        private double x1;
        private double x2;
        private double y1;
        private double y2;

        private double max;
        private double display;

        public Line(double max, double display, double height, double x, bool isView, double extra)
        {
            x1 = x+extra;
            y1 = 0;
            x2 = x+extra;
            y2 = height;
            this.max = max;
            this.display = display;
            this.PostionY = (y1 + y2) / 2;
            this.RealValue = isView ? ((int)height).ToString() : "";
            IsView = isView;
        }
        public Line(double x1, double x2, double y1, double y2, double max, double display, bool isView, double extra)
        {
            this.x1 = x1+extra;
            this.x2 = x2+extra;
            this.y1 = y1;
            this.y2 = y2;
            this.max = max;
            this.display = display;
            this.RealValue = isView ? ((int)y2).ToString() : "";
            IsView = isView;
        }
    }
}
