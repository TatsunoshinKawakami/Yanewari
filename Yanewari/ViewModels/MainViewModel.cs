using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Yanewari.Common;
using Yanewari.Models;
using Yanewari.Views;

namespace Yanewari.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private double tile;
        private double width;
        private double left;
        private double right;
        private int number;
        private double extra;
        private List<Line> lines = new List<Line>();

        private DelegateCommand calculateCommand;

        public double Tile
        {
            get { return tile; }
            set { tile = value; }
        }
        public double Width
        {
            get { return width; }
            set { width = value; }
        }
        public double Left
        {
            get { return left; }
            set { left = value; }
        }
        public double Right
        {
            get { return right; }
            set { right = value; }
        }
        public List<Line> Lines
        {
            get { return lines; }
            set { lines = value; }
        }


        public DelegateCommand CalculateCommand { get { return calculateCommand ?? (calculateCommand=new DelegateCommand(calculate)); } }
        private void calculate()
        {
            CalculateXaxis calculaterXaxis = new CalculateXaxis(tile, width);
            number = calculaterXaxis.Number;
            extra = calculaterXaxis.Extra;
            RaisePropertyChanged("Number");
            RaisePropertyChanged("Extra");
        }
    }
}
