
namespace ShapesLib
{
	public interface IShapeFactory
	{
		Shape CreateShape(ShapeTypeEnum shapeType, double shapeWidth);
	}
}
