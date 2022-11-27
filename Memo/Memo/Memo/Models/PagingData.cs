using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Memo.Models
{
	public class PagingData
	{
		public int PageIndex { get; set; }
		public int PageSize { get; set; }
		public int RecordCount { get; set; }
		public int TotalPage { get; set; }
	}
}