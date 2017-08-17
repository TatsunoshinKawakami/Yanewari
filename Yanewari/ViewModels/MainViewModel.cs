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
        private double scale = 500;
        private List<Line> lines;
        private int number;
        private double extra;
        private double lastX;

        private double max;

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
        public double Scale
        {
            get { return scale; }
            set
            {
                scale = value;
                if (lines.Count == 0)
                    return;
                lines = lines.Select(x => new Line(x.X1, x.X2, x.Y1, x.Y2, max, scale, x.IsView, 0)).ToList();
                lastX = lines.Last().X1D;
                RaisePropertyChanged("Scale");
                RaisePropertyChanged("Lines");
                RaisePropertyChanged("LastX");
            }
        }
        public List<Line> Lines
        {
            get { return lines; }
            set { lines = value; RaisePropertyChanged("Lines"); }
        }
        public int Number
        {
            get { return number; }
            set { number = value; RaisePropertyChanged("Number"); }
        }
        public double Extra
        {
            get { return extra; }
            set { extra = value; RaisePropertyChanged("Extra"); }
        }
        public double LastX
        {
            get { return lastX; }
            set { lastX = value; RaisePropertyChanged("LastX"); }
        }


        public DelegateCommand CalculateCommand { get { return calculateCommand ?? (calculateCommand=new DelegateCommand(calculate)); } }
        private void calculate()
        {
            tile = table[SelectedTile];
            lines = new List<Line>();
            CalculateXaxis calculaterXaxis = new CalculateXaxis(tile, width);
            number = calculaterXaxis.Number;
            extra = calculaterXaxis.Extra;
            CalculateYaxis calculaterYaxis = new CalculateYaxis(number, left, right);
            max = Math.Max(calculaterYaxis.Answers.Max(), width);
            foreach (var item in calculaterYaxis.Answers.Select((x, index) => new Tuple<int, double>(index, x)))
            {
                lines.Add(new Line(max, scale, item.Item2, item.Item1 * tile, true, extra));
                lines.Add(new Line(item.Item1 * tile, item.Item1 * tile + tile, 0, 0, max, scale, false, extra));
                lines.Add(new Line(item.Item1 * tile, item.Item1 * tile + tile, item.Item2, item.Item2, max, scale, false, extra));
                lines.Add(new Line(max, scale, item.Item2, (item.Item1 + 1) * tile, false, extra));
            }
            lines.Add(new Line(0, extra, 0, 0, max, scale, false, 0));
            lines.Add(new Line(number * tile, number * tile + extra, 0, 0, max, scale, false, extra));
            lastX = lines.Last().X1D;
            RaisePropertyChanged("Lines");
            RaisePropertyChanged("Number");
            RaisePropertyChanged("Extra");
        }
    }
}
