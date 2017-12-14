using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security;
using Walnut.Api.Providers;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

[assembly: OwinStartup(typeof(Walnut.Api.Startup))]

namespace Walnut.Api
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			// For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
			#region OAuthConfiguration

			var OAuthOptions = new OAuthAuthorizationServerOptions
			{
				AllowInsecureHttp = true,
				AuthenticationMode = AuthenticationMode.Active,
				TokenEndpointPath = new PathString("/token"), //获取 access_token 认证服务请求地址
				AuthorizeEndpointPath = new PathString("/authorize"), //获取 authorization_code 认证服务请求地址
				AccessTokenExpireTimeSpan = TimeSpan.FromSeconds(10), //access_token 过期时间

				Provider = new OpenAuthorizationServerProvider(), //access_token 相关认证服务
				AuthorizationCodeProvider = new OpenAuthorizationCodeProvider(), //authorization_code 认证服务
				RefreshTokenProvider = new OpenRefreshTokenProvider() //refresh_token 认证服务
			};

			#endregion

			#region HttpConfiguration

			var configuration = new HttpConfiguration();

			#region RouteConfiguration

			configuration.MapHttpAttributeRoutes();
			configuration.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{action}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			#endregion

			#region JsonConfiguration

			configuration.Formatters.Clear();
			configuration.Formatters.Add(new JsonMediaTypeFormatter());
			configuration.Formatters.JsonFormatter.SerializerSettings =
				new JsonSerializerSettings
				{
					ContractResolver = new CamelCasePropertyNamesContractResolver()
				};

			#endregion

			#endregion

			app.UseOAuthBearerTokens(OAuthOptions);
			app.UseWebApi(configuration);
		}
	}
}
