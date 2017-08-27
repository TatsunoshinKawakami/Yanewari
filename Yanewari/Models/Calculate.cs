using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanewari.Models
{
    class Calculate
    {
        private double tile;
        private double width;
        private double left;
        private double right;

        private int number;
        private double extra;
        private List<Tuple<double, double>> answers = new List<Tuple<double, double>>();

        /// <summary>
        /// 幅に用いる瓦の枚数
        /// </summary>
        public int Number { get { return number; } set { number = value; } }
        /// <summary>
        /// 指定幅との差
        /// </summary>
        public double Extra { get { return extra; } set { extra = value; } }
        public List<Tuple<double,double>> Answers { get { return answers; } }

        private void calculate()
        {
            number = (int)(width / tile);
            extra = width - number * tile;
            if (tile == 600 || tile == 500)
            {
                if (extra > tile)
                {
                    number++;
                    extra -= tile;
                }
            }
            else
            {
                if(extra < tile)
                {
                    number--;
                    extra += tile;
                }
            }
            extra /= 2;

            double diff = Math.Abs(left - right);
            double scale = width / diff;
            double width_triangle = Math.Max(left, right) * scale;
            answers.Add(new Tuple<double, double>(left < right ? 0 : width - extra, (width_triangle - width + extra) * Math.Max(left, right) / width_triangle));
            foreach (int coeff in Enumerable.Range(1, number))
                if(left < right)
                    answers.Add(new Tuple<double, double>((coeff - 1) * tile + extra, (width_triangle - width + extra + tile * coeff) * Math.Max(left, right) / width_triangle));
                else
                    answers.Add(new Tuple<double, double>((number - coeff) * tile + extra, (width_triangle - width + extra + tile * coeff) * Math.Max(left, right) / width_triangle));
            answers.Add(new Tuple<double, double>(left < right ? width - extra : 0, (width_triangle) * Math.Max(left, right) / width_triangle));
        }

        /// <summary>
        /// 初期化コンストラクタ
        /// </summary>
        /// <param name="tile">瓦の種類</param>
        /// <param name="width">指定される幅</param>
        public Calculate(double tile, double width, double left, double right)
        {
            this.tile = tile;
            this.width = width;
            this.right = right;
            this.left = left;
            calculate();
        }
    }
}
