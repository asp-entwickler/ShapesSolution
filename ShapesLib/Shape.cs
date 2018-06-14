using System;

namespace ShapesLib
{

	public class Shape
	{
		private double width;
		private ShapeTypeEnum type;

		public Shape(ShapeTypeEnum type, double width)
		{
			this.type = type;
			this.width = width;
		}

		public double Width
		{
			get
			{
				return width;
			}
		}

		public double CalculateArea()
		{

			switch (type)
			{
				case ShapeTypeEnum.SQUARE:
					return width * width;
				case ShapeTypeEnum.CIRCLE:
					return Math.PI * (width / 2) * (width / 2);
				case ShapeTypeEnum.EQUILATERAL_TRIANGLE:
					return (Math.Sqrt(4) / 3) * width * width;
				default:
					return -1;

			}

		}

	}

}