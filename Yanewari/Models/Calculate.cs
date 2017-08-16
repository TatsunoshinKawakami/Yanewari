using System;
using System.Collections.Generic;
using System.Linq;

namespace ForMyFather.Model
{
	class Calculate
	{
		private List<Trapezoid> _ans = new List<Trapezoid>();
		private double _upper;
		private double _lower;
		private double _height;
		private double _lap;
		private int _divNum;

		public List<Trapezoid> Ans
		{
			get
			{
				return new List<Trapezoid>(_ans);
			}
			set { _ans = value; }
		}     //答えのプロパティ

		private void calculate()
		{
			double lo, up;
			for (int i = 1; i <= _divNum; i++)
			{
				lo = ((i / (double)_divNum) * _height + _lap) / _height * (_lower - _upper) + _upper;
				up = (i - 1) / (double)_divNum * (_lower - _upper) + _upper;
				_ans.Add(new Trapezoid(up, lo, _height / _divNum + _lap));
			}
		}		 //それぞれの台形の上底、下底、高さを計算する関数

		public Calculate(double u, double l, double h, double lap, int d)
		{
			_upper = u;
			_lower = l;
			_height = h;
			_lap = lap;
			_divNum = d;
			calculate();
		}	 //コンストラクタ
	}   //台形を分けるようの計算クラス
}
