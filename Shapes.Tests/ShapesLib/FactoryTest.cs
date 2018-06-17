using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapesLib;
using System;

namespace Shapes.Tests
{
	/// <summary>
	/// Summary description for FabricTest
	/// </summary>
	[TestClass]
	public class FactoryTest
	{

		[TestMethod]
		public void FabricShapesProduction()
		{

			IShapeFactory shapeFactory = new ShapeFactory();

			Shape shape;
			double width = 5;

			for (var i = 1; i <= 3; i++)
			{

				shape = shapeFactory.CreateShape((ShapeTypeEnum)i, width);

				switch (i)
				{
					case 1:
						Assert.AreEqual(shape.GetType(), typeof(Square));
						break;

					case 2:
						Assert.AreEqual(shape.GetType(), typeof(Circle));
						break;

					case 3:
						Assert.AreEqual(shape.GetType(), typeof(EquilateralTriangle));
						break;
				}

			}

		}

		[TestMethod]
		public void OutOfRangeInput()
		{

			IShapeFactory shapeFactory = new ShapeFactory();

			Shape shape;
			double width = 5;

			try
			{ 
				shape = shapeFactory.CreateShape((ShapeTypeEnum)0, width);
			}
			catch(Exception ex)
			{
				Assert.AreEqual(ex.GetType(), typeof(ArgumentOutOfRangeException));
			}

		}

	}

}
