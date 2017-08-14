﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanewari.Models
{
    class CalculateYaxis
    {
        private int width_number;
        private double min_height;
        private double max_height;
        private bool isReverse;

        private List<double> answers = new List<double>();
        /// <summary>
        /// 表示される列ごとの高さ
        /// </summary>
        public List<double> Answers { get { return answers; } }

        /// <summary>
        /// 初期化コンストラクタ
        /// </summary>
        /// <param name="width">瓦の列数</param>
        /// <param name="left">左側の高さ</param>
        /// <param name="right">右側の高さ</param>
        public CalculateYaxis(int width, double left, double right)
        {
            this.width_number = width;
            this.min_height = Math.Min(left, right);
            this.max_height = Math.Max(left, right);
            this.isReverse = left == this.min_height;
        }
    }
}
