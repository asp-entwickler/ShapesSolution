using System;

namespace ShapesLib
{
	public class EquilateralTriangle : Shape
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
