namespace ShapesLib
{
	public class Square : Shape
	{

		public Square(double width) : base(width)
		{
		}

		public override double CalculateArea()
		{
			return Width * Width;
		}

	}

}
