using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Memo.Models
{
	public class NoteObj
	{
		public string Title { get; set; }

		public string MemoString { get; set; }

		public DateTime CreationDate { get; set; }

		public DateTime UpdateDate { get; set; }
	}
}