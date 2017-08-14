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

        /// <summary>
        /// 幅に用いる瓦の枚数
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// 指定幅との差
        /// </summary>
        public double Extra { get; set; }

        private void calculate()
        {
            int number = (int)(width / tile);
            double extra = width - number * tile;
            if(extra < tile)
            {
                number--;
                extra += tile;
            }
            Number = number;
            Extra = extra/2;
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
