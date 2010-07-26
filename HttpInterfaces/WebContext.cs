using System;
using System.Web;
using System.Web.Caching;
using System.Web.SessionState;

namespace HttpInterfaces
{
	public static class WebContext
	{
		public static IHttpContext Current
		{
			get
			{
				return Cast(HttpContext.Current);
			}
		}

		#region Helper methods for casting Http Intrinsics
		public static IHttpContext Cast(HttpContext context)
		{
		    return new HttpContextProxy(context);
		}

		public static IHttpRequest Cast(HttpRequest request)
		{
		    return new HttpRequestProxy(request);
		}

		public static IHttpResponse Cast(HttpResponse response)
		{
		    return new HttpResponseProxy(response);
		}

		public static IHttpSession Cast(HttpSessionState session)
		{
		    return new HttpSessionProxy(session);
		}

		public static IHttpApplication Cast(HttpApplication application)
		{
		    return new HttpApplicationProxy(application);
		}

		public static IHttpApplicationState Cast(HttpApplicationState application)
		{
		    return new HttpApplicationStateProxy(application);
		}

		public static IHttpServerUtility Cast(HttpServerUtility server)
		{
		    return new HttpServerUtilityProxy(server);
		}

		public static IHttpCachePolicy Cast(HttpCachePolicy cachePolicy)
		{
		    return new HttpCachePolicyProxy(cachePolicy);
		}

		public static IHttpClientCertificate Cast(HttpClientCertificate clientCertificate)
		{
		    return new HttpClientCertificateProxy(clientCertificate);
		}

		public static IHttpFileCollection Cast(HttpFileCollection files)
		{
		    return new HttpFileCollectionProxy(files);
		}

		public static IHttpModuleCollection Cast(HttpModuleCollection modules)
		{
		    return new HttpModuleCollectionProxy(modules);
		}

		public static ITraceContext Cast(TraceContext context)
		{
		    return new TraceContextProxy(context);
		}

		public static ICache Cast(Cache cache)
		{
		    return new CacheProxy(cache);
		}
		#endregion
	}
}
