using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Memo.Models
{
	public class Student
	{
		public int Id { get; set; }

		[Required(ErrorMessage ="Name is required")]
		public string Name { get; set; }

		[Required(ErrorMessage = "NRC is required")]
		public string NRC { get; set; }

		[Required(ErrorMessage = "Phone is required")]
		public string Phone { get; set; }

		[Required(ErrorMessage = "Address is required")]
		public string Address { get; set; }

		[Required(ErrorMessage = "City is required")]
		public string City { get; set; }

		public bool IsAddState { get; set; }
	}

	public class StudentList
	{
		public List<Student> Students { get; set; }
		public PagingData Paging { get; set; }
	}
}