using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanewari.Models
{
    class CalculateXaxis
    {
        private double tile;
        private double width;

        private int number;
        private double extra;

        /// <summary>
        /// 幅に用いる瓦の枚数
        /// </summary>
        public int Number { get { return number; } set { number = value; } }
        /// <summary>
        /// 指定幅との差
        /// </summary>
        public double Extra { get { return extra; } set { extra = value; } }

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
        }

        /// <summary>
        /// 初期化コンストラクタ
        /// </summary>
        /// <param name="tile">瓦の種類</param>
        /// <param name="width">指定される幅</param>
        public CalculateXaxis(double tile, double width)
        {
            this.tile = tile;
            this.width = width;
            calculate();
        }
    }
}
