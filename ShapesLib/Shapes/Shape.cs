namespace ShapesLib
{
	public abstract class Shape
	{
		private double _width;

		public double Width
		{
			get
			{
				return _width;
			}
		}

		protected Shape(double width)
		{
			_width = width;
		}

		public abstract double CalculateArea();

	}

}