using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Walnut.Sample.V1.Api
{
	public class SampleController : ApiController
	{
		[Authorize]
		public HttpResponseMessage GetData(int id)
		{
			var data = new SampleData();
			data.Id = "1";
			data.Name = "A1";
			data.Datas = new List<SampleSubData>()
			{
				new SampleSubData()
				{
					Id = "11"
					,Name = "A11"
				}
				,new SampleSubData()
				{
					Id = "12"
					,Name = "A12"
				}

			};

			return this.Request.CreateResponse<SampleData>(HttpStatusCode.OK, data);
		}

		public HttpResponseMessage GetOpenData(int id)
		{
			var data = new SampleData();
			data.Id = "1";
			data.Name = "A1";
			data.Datas = new List<SampleSubData>()
			{
				new SampleSubData()
				{
					Id = "11"
					,Name = "A11"
				}
				,new SampleSubData()
				{
					Id = "12"
					,Name = "A12"
				}

			};

			return this.Request.CreateResponse<SampleData>(HttpStatusCode.OK, data);
		}

	}

	public class SampleData
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public IEnumerable<SampleSubData> Datas { get; set; }
	}

	public class SampleSubData
	{
		public string Id { get; set; }

		public string Name { get; set; }
	}

}
