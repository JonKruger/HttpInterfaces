HttpInterfaces provides interfaces to wrap HttpContext and other unmockable, abstract base classes that you might use in your controllers and model binders on an ASP.NET MVC project.  

For example, in the following code, you would not be able write a unit test for this code because you don't have an actual HttpContext:

<pre>
public class OrderController
{
	public ActionResult Index()
	{
		Session["foo"] = "bar";
		var productName = Request.Form["Product_3_Name"];
	}
}
</pre>

You can try to use partial mocks, create derived classes, and implement abstract classes in order to make these things testable, but everyone I know who has tried eventually gets frustrated or runs into something they can't fake out in a test.  So just save yourself the trouble and use the interfaces instead.

You get the following interfaces:

ICache - Cache
IHttpApplication - HttpApplication
IHttpApplicationState - HttpApplicationState
IHttpCachePolicy - CachePolicy
IHttpClientCertificate - HttpClientCertificate
IHttpContext - HttpContext
IHttpFileCollection - HttpFileCollection
IHttpModuleCollection - HttpModuleCollection
IHttpRequest - HttpRequest
IHttpResponse - HttpResponse
IHttpServerUtility - HttpServerUtility
IHttpSession - System.Web.SessionState.HttpSessionState
ITraceContext - TraceContext

You can configure a DI container like StructureMap to use the interfaces like this:

<pre>
ObjectFactory.Initialize(x =>
{
    x.For<IHttpApplication>().Use(
        c => WebContext.Cast(HttpContext.Current.ApplicationInstance));
    x.For<IHttpApplicationState>().Use(
        c => WebContext.Cast(HttpContext.Current.Application));
    x.For<IHttpCachePolicy>().Use(
        c => WebContext.Cast(HttpContext.Current.Response.Cache));
    x.For<IHttpClientCertificate>().Use(
        c => WebContext.Cast(HttpContext.Current.Request.ClientCertificate));
    x.For<IHttpContext>().Use(
        c => WebContext.Cast(HttpContext.Current));
    x.For<IHttpFileCollection>().Use(
        c => WebContext.Cast(HttpContext.Current.Request.Files));
    x.For<IHttpModuleCollection>().Use(
        c => WebContext.Cast(HttpContext.Current.ApplicationInstance.Modules));
    x.For<IHttpRequest>().Use(
        c => WebContext.Cast(HttpContext.Current.Request));
    x.For<IHttpResponse>().Use(
        c => WebContext.Cast(HttpContext.Current.Response));
    x.For<IHttpServerUtility>().Use(
        c => WebContext.Cast(HttpContext.Current.Server));
    x.For<IHttpSession>().Use(
        c => WebContext.Cast(HttpContext.Current.Session));
    x.For<ITraceContext>().Use(
        c => WebContext.Cast(HttpContext.Current.Trace));
}
</pre>

Now you can take these interfaces into your controllers as constructor parameters:

<pre>
public class OrderController
{
	private IHttpSession _session;
	private IHttpRequest _request;
	
	public OrderController(IHttpSession session, IHttpRequest request)
	{
		_session = session;
		_request = request;
	}
	
	public ActionResult Index()
	{
		_session["foo"] = "bar";
		var productName = _request.Form["Product_3_Name"];
	}
}
</pre>

I can easily test these controller methods because I can stub out the interfaces in my tests.

Win!
