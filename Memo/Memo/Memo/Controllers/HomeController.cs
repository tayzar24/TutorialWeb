using Memo.Models;
using Memo.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Memo.Helper;

namespace Memo.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult AddStudent()
		{
			return View();
		}

		public ActionResult Index()
		{
			return View();
		}
		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}
		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
		private void AddMemoList(bool isAbout=true)
		{
			var list = new List<Student>();
			if (Session["StudentData"] != null)
			{
				list = Session["StudentData"] as List<Student>;
			}
			if (isAbout)
			{
				for (int i = 0; i < 100; i++)
				{
					list.Add(new Student() { Name = "Maung Maung" + i, NRC = "7/PaKhaNa(N)362515", Address = "Bahan", City = "Yangon", Phone = "0925478452" });
				}
			}
			else
			{
				list.Add(new Student() { Name = "Maung Maung" , NRC = "7/PaKhaNa(N)362515", Address = "Bahan", City = "Yangon", Phone = "0925478452" });
			}
			
			Session["StudentData"] = list;
		}

		public ActionResult ShowAddEditDialog()
		{
			return View("~/View/Home/Dialog/_AddMemoViewDialog.cshtml", "");
		}

		[HttpGet]
		public JsonResult List()
		{
			AddMemoList();
			StudentList list = new StudentList();
			list.Students = new List<Student>();

			if (Session["StudentData"] != null)
				list.Students = Session["StudentData"] as List<Student>;

			ResStudentList response = new ResStudentList()
			{
				Success = true,
				ErrorMessage = string.Empty,
				Route = string.Empty,
				Students = list
			};
			return Json(response, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public JsonResult StudentList(int pageIndex,string sortName,string sortDirection)
		{
			AddMemoList(true);
			PagingData pagingData = new PagingData();
			pagingData.PageIndex = pageIndex;
			pagingData.PageSize = 10;
			StudentList list = new StudentList();
			list.Students = new List<Student>();

			int startIndex = (pageIndex - 1) * pagingData.PageSize;
			if (Session["StudentData"] != null)
				list.Students = Session["StudentData"] as List<Student>;

			pagingData.RecordCount = list.Students.Count();
			list.Students = list.Students.Skip(startIndex).Take(pagingData.PageSize).ToList();
			list.Paging = pagingData;
			ResStudentList response = new ResStudentList()
			{
				Success = true,
				ErrorMessage = string.Empty,
				Route = string.Empty,
				Students = list
			};
			
			
			return Json(response, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public ActionResult AddEditStudentShow(Student input)
		{
			string partialView = this.RenderPartialView("~/Views/Home/Dialog/_AddMemoViewDialog.cshtml", input);
			return Json(new JsonResponse() { Success = true, View = partialView });
		}

		[HttpPost]
		public ActionResult AddStudentProcess(Student input)
		{
			if (!ModelState.IsValid)
			{
				return View("AddStudent");
			}
			return View("Index");
		}
	}
}