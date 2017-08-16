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
        private double[] table = { 500, 333, 600, 370 };
        private double tile;
        private double width;
        private double left;
        private double right;
        private List<Line> lines;
        private double extra;

        private DelegateCommand calculateCommand;

        public List<string> Tile
        {
            get { return new List<string> { "166ハゼ", "Tかん金", "90ハゼ", "立？？" }; }
            set { }
        }
        public int SelectedTile { get; set; }
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
            set { lines = value; RaisePropertyChanged("Lines"); }
        }
        public double Extra
        {
            get { return extra; }
            set { extra = value; RaisePropertyChanged("Extra"); }
        }


        public DelegateCommand CalculateCommand { get { return calculateCommand ?? (calculateCommand=new DelegateCommand(calculate)); } }
        private void calculate()
        {
            tile = table[SelectedTile];
            lines = new List<Line>();
            CalculateXaxis calculaterXaxis = new CalculateXaxis((double)tile, width);
            int number = calculaterXaxis.Number;
            extra = calculaterXaxis.Extra;
            CalculateYaxis calculaterYaxis = new CalculateYaxis(number, left, right);
            double max = Math.Max(calculaterYaxis.Answers.Max(), width);
            foreach (var item in calculaterYaxis.Answers.Select((x, index) => new Tuple<int, double>(index, x)))
            {
                lines.Add(new Line(max, 500, item.Item2, item.Item1 * (double)tile));
                lines.Add(new Line(item.Item1 * (double)tile, item.Item1 * (double)tile + (double)tile, 0, 0, max, 500));
                lines.Add(new Line(item.Item1 * (double)tile, item.Item1 * (double)tile + (double)tile, item.Item2, item.Item2, max, 500));
                lines.Add(new Line(max, 500, item.Item2, (item.Item1 + 1) * (double)tile));
            }
            RaisePropertyChanged("Lines");
            RaisePropertyChanged("Extra");
        }
    }
}
