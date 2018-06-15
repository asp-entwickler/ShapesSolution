using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesLib
{
	public class ShapeFactory : IShapeFactory
	{

		public Shape CreateShape(ShapeTypeEnum shapeType, double shapeWidth)
		{
			switch(shapeType)
			{

				case ShapeTypeEnum.SQUARE:
					return new Square(shapeWidth);

				case ShapeTypeEnum.CIRCLE:
					return new Circle(shapeWidth);

				case ShapeTypeEnum.EQUILATERAL_TRIANGLE:
					return new EquilateralTriangle(shapeWidth);

				default:
					throw new ArgumentOutOfRangeException("ShapeType", "Unknown Shape Type");

			}


		}

	}
}
