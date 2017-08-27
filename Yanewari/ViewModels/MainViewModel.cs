using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Yanewari.Common;
using Yanewari.Models;
using Yanewari.Views;

using Microsoft.Win32;

namespace Yanewari.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private double[] table = { 500, 333, 600, 370 };
        private double tile;
        private double? width;
        private double? left;
        private double? right;
        private double scale = 500;
        private List<Line> lines = new List<Line>();
        private int number;
        private double extra;
        private double lastX;

        private double max;

        private DelegateCommand calculateCommand;
        private DelegateCommand printCommand;
        private DelegateCommand saveCommnad;

        public List<string> Tile
        {
            get { return new List<string> { "166ハゼ", "Tかん金", "90ハゼ", "立馳" }; }
            set { }
        }
        public int SelectedTile { get; set; }
        public double? Width
        {
            get { return width; }
            set { width = value??-1; RaisePropertyChanged("CalculateCommand"); }
        }
        public double? Left
        {
            get { return left; }
            set { left = value??-1; RaisePropertyChanged("CalculateCommand"); }
        }
        public double? Right
        {
            get { return right; }
            set { right = value??-1; RaisePropertyChanged("CalculateCommand"); }
        }
        public double Scale
        {
            get { return scale; }
            set
            {
                scale = value;
                if (lines.Count == 0)
                    return;
                lines = lines.AsParallel().Select(x => new Line(x.X1, x.X2, x.Y1, x.Y2, max, scale, x.IsView, 0)).ToList();
                lastX = lines.Last().X1D;
                RaisePropertyChanged("Scale");
                RaisePropertyChanged("Lines");
                RaisePropertyChanged("LastX");
            }
        }
        public List<Line> Lines
        {
            get { return lines; }
            set { lines = value; }
        }
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        public double Extra
        {
            get { return extra; }
            set { extra = value; }
        }
        public double LastX
        {
            get { return lastX; }
            set { lastX = value; RaisePropertyChanged("LastX"); }
        }


        public DelegateCommand CalculateCommand { get { return calculateCommand ?? (calculateCommand = new DelegateCommand(calculate, canCalculate)); } }
        private void calculate()
        {
            double width = this.width??-1;
            double left = this.left??-1;
            double right = this.right??-1;

            tile = table[SelectedTile];
            lines = new List<Line>();
            Calculate calculater = new Calculate(tile, width, left, right);
            number = calculater.Number;
            extra = calculater.Extra;
            max = Math.Max(calculater.Answers.Max(), width);
            foreach (var item in calculater.Answers.Select((x, index) => new Tuple<int, double>(index, x)))
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
        private bool canCalculate() { return width != null && left != null && right != null; }

        public DelegateCommand PrintCommand { get { return printCommand ?? (printCommand = new DelegateCommand(print, canPrint)); } }
        private void print() { Printer.Print(this); }
        private bool canPrint() { return lines.Count > 0; }

        public DelegateCommand SaveCommand { get { return saveCommnad ?? (saveCommnad = new DelegateCommand(save, canSave)); } }
        private void save()
        {
            var dialog = new SaveFileDialog();
            dialog.Title = "図形を保存";
            dialog.Filter = "XPSファイル|*.xps";
            if (dialog.ShowDialog() == true)
                SaveGraph.Save(this, dialog.FileName);
        }
        private bool canSave() { return lines.Count > 0; }
    }
}
