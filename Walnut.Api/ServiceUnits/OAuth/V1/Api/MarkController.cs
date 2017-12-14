using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Walnut.OpenAuth.V1.Api
{
	public class MarkController : ApiController
	{
		[HttpGet]
		[Route("api/mark")]
		public HttpResponseMessage Get(string code)
		{
			return new HttpResponseMessage()
			{
				Content = new StringContent(code, Encoding.UTF8, "text/plain")
			};
		}

		[HttpGet]
		[Route("api/access_mark")]
		public HttpResponseMessage GetToken()
		{
			var url = Request.RequestUri;
			return new HttpResponseMessage()
			{
				Content = new StringContent("", Encoding.UTF8, "text/plain")
			};
		}
	}
}
