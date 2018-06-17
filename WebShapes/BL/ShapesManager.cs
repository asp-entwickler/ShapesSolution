using Newtonsoft.Json;
using ShapesLib;
using System;
using System.Collections.Generic;
using Unity;
using WebShapes.DAL;

namespace WebShapes.BL
{
	public class ShapesManager
	{
		private static IShapeFactory _shapeFactory;
		private static List<ShapeDTO> _shapesCollection;

		private List<ShapeDTO> ShapesCollection
		{
			get { return _shapesCollection; }
		}

		private static void RegisterDependencies()
		{
			if (_shapeFactory == null)
			{
				var container = new UnityContainer();
				container.RegisterType<IShapeFactory, ShapeFactory>();
				_shapeFactory = container.Resolve<IShapeFactory>();
			}
			if (_shapesCollection == null)
			{
				_shapesCollection = new List<ShapeDTO>();
			}
		}

		public ShapesManager()
		{
			RegisterDependencies();
		}

		public double RegisterShape(string id, int typeParam, double width, int idx, string userName)
		{

			var shape = _shapeFactory.CreateShape((ShapeTypeEnum)typeParam, width);

			lock (_shapesCollection)
			{

				_shapesCollection.Add(
					new ShapeDTO()
					{
						Id = id,
						ShapeType = typeParam.ToString(),
						Width = width.ToString(),
						Idx = idx
				});

				var shapesCollectionJson = JsonConvert.SerializeObject(_shapesCollection);
				var storage = new ShapeStorage();
				if (!string.IsNullOrEmpty(userName))
					storage.SaveShapesCollection(shapesCollectionJson, userName);

			}

			return Math.Round(shape.CalculateArea(), 1);
		}

		public void RemoveShape(string id, string userName)
		{
			_shapesCollection.RemoveAll(x => x.Id == id);

			var shapesCollectionJson = JsonConvert.SerializeObject(_shapesCollection);

			var storage = new ShapeStorage();
			if (!string.IsNullOrEmpty(userName))
				storage.SaveShapesCollection(shapesCollectionJson, userName);

		}

		public void Clear()
		{
			_shapesCollection.Clear();
		}

		public string LoadForUser(string userName)
		{
			var storage = new ShapeStorage();
			var shapesCollection = storage.QueryShapesCollection(userName);
			return shapesCollection;
		}

	}

}