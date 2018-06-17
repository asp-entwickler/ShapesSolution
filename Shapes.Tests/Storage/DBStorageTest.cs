using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using WebShapes.DAL;

namespace Shapes.Tests
{
	[TestClass]
	public class DBStorageTest
	{
		[TestMethod]
		public void SaveAndRestore()
		{
			// Configure DataDirectory
			var solutionDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
			string dataPath = Path.Combine(solutionDir, "WebShapes\\App_Data");
			AppDomain.CurrentDomain.SetData("DataDirectory", dataPath);

			var shapeStorage = new ShapeStorage();

			var etalonString = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...";
			var key4Storage = "user@contoso";

			shapeStorage.SaveShapesCollection(etalonString, key4Storage);
			var valueFromDb = shapeStorage.QueryShapesCollection(key4Storage).Trim();

			Assert.IsTrue(etalonString.Equals(valueFromDb));

		}

	}

}
