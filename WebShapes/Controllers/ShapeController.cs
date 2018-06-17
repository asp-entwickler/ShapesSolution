using System;
using System.Web.Mvc;
using WebShapes.BL;

namespace WebShapes.Controllers
{
	public class ShapeController : Controller
	{

		[HttpPost]
		public ActionResult Reflect(string id, string type, string width, string idx)
		{
			// TODO validate parameters
			if (string.IsNullOrEmpty(width))
				width = "0";

			var userName = User.Identity.Name;
			var shapesManager = new ShapesManager();
			var area = shapesManager.RegisterShape(id, Int32.Parse(type), double.Parse(width), 
				Int32.Parse(idx), userName);

			return Json(new { area = area.ToString() });

		}

		// TODO - refactor with DELETE mathod
		[HttpPost]
		public ActionResult Remove(string id)
		{
			// TODO validate parameters
			var userName = User.Identity.Name;
			var shapesManager = new ShapesManager();
			shapesManager.RemoveShape(id, userName);
			return Json(new { result = "ok" });
		}

		public ActionResult LoadCollection()
		{
			if (!User.Identity.IsAuthenticated)
			{
				Response.StatusCode = 204;
				return Json(
					new { result = "" },
					JsonRequestBehavior.AllowGet
				);
			}

			var userName = User.Identity.Name;
			var shapesManager = new ShapesManager();
			var shapesCollection = shapesManager.LoadForUser(userName);

			shapesManager.Clear();

			return Json(
					new { result = shapesCollection },
					JsonRequestBehavior.AllowGet
				);

		}

	}

}
