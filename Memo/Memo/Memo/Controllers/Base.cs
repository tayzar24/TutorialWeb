using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Memo.Controllers
{
	public static class Base
	{
		public static string RenderPartialView(this Controller controller, string viewName, object model)
		{
			if (string.IsNullOrEmpty(viewName))
			{
				viewName = controller.ControllerContext.RouteData.GetRequiredString("action");
			}

			controller.ViewData.Model = model;
			using (var writer = new StringWriter())
			{
				ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
				var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, writer);
				viewResult.View.Render(viewContext, writer);

				return writer.GetStringBuilder().ToString();
			}
		}

		internal static string RenderPartialView(string v)
		{
			throw new NotImplementedException();
		}
	}
}