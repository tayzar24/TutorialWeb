using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Memo.Models.Response
{
	public class ResStudentList : ResponseBase
	{
		public StudentList Students { get; set; }
	}
}