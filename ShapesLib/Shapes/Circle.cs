using System;

namespace ShapesLib
{
	class Circle : Shape
	{

		public Circle(double width) : base(width)
		{
		}

		public override double CalculateArea()
		{
			return Math.PI * (Width / 2) * (Width / 2);
		}
	}
}
