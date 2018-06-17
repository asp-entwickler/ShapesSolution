using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapesLib;

namespace Shapes.Tests
{
	[TestClass]
	public class ShapesFunctionTest
	{

		public bool NearlyEquals(double value1, double value2, double unimportantDifference = 0.0001)
		{
			if (value1 != value2)
			{
				return Math.Abs(value1 - value2) < unimportantDifference;
			}

			return true;
		}

		[TestMethod]
		public void AreaCalculation()
		{

			IShapeFactory shapeFactory = new ShapeFactory();

			Shape shape;
			double width = 5;

			for (var i = 1; i <= 3; i++)
			{

				shape = shapeFactory.CreateShape((ShapeTypeEnum)i, width);
				double shapeArea = 0;

				switch (i)
				{
					case 1:
						Assert.AreEqual(shape.CalculateArea(), 25);
						break;

					case 2:
						shapeArea = shape.CalculateArea();
						Assert.IsTrue(NearlyEquals(shapeArea, 19.6349540849362));
						break;

					case 3:
						shapeArea = shape.CalculateArea();
						Assert.IsTrue(NearlyEquals(shapeArea, 16.6666666666667));
						break;
				}

			}

		}

	}

}

