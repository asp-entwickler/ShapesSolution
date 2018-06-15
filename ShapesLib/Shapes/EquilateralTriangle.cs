using System;

namespace ShapesLib
{
	class EquilateralTriangle : Shape
	{
		public EquilateralTriangle(double width) : base(width)
		{
		}

		public override double CalculateArea()
		{
			return (Math.Sqrt(4) / 3) * Width * Width;
		}
	}
}
