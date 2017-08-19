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
        private List<double> answers = new List<double>();

        /// <summary>
        /// 幅に用いる瓦の枚数
        /// </summary>
        public int Number { get { return number; } set { number = value; } }
        /// <summary>
        /// 指定幅との差
        /// </summary>
        public double Extra { get { return extra; } set { extra = value; } }
        public List<double> Answers { get { return answers; } }

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
            foreach (int coeff in Enumerable.Range(0, number))
                answers.Add((width_triangle - width + extra + tile * coeff) * Math.Max(left, right) / width_triangle);
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
