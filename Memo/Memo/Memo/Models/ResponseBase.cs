﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Memo.Models
{
	public class ResponseBase
	{
		public bool Success { get; set; }

		public string ErrorMessage { get; set; }

		public string Route { get; set; }
	}
}