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

ICache - Cache<br/>
IHttpApplication - HttpApplication<br/>
IHttpApplicationState - HttpApplicationState<br/>
IHttpCachePolicy - CachePolicy<br/>
IHttpClientCertificate - HttpClientCertificate<br/>
IHttpContext - HttpContext<br/>
IHttpFileCollection - HttpFileCollection<br/>
IHttpModuleCollection - HttpModuleCollection<br/>
IHttpRequest - HttpRequest<br/>
IHttpResponse - HttpResponse<br/>
IHttpServerUtility - HttpServerUtility<br/>
IHttpSession - System.Web.SessionState.HttpSessionState<br/>
ITraceContext - TraceContext<br/>

You can configure a DI container like StructureMap to use the interfaces like this:

<pre>
ObjectFactory.Initialize(x =>
{
    x.For&lt;IHttpApplication&gt;().Use(
        c => WebContext.Cast(HttpContext.Current.ApplicationInstance));
    x.For&lt;IHttpApplicationState&gt;().Use(
        c => WebContext.Cast(HttpContext.Current.Application));
    x.For&lt;IHttpCachePolicy&gt;().Use(
        c => WebContext.Cast(HttpContext.Current.Response.Cache));
    x.For&lt;IHttpClientCertificate&gt;().Use(
        c => WebContext.Cast(HttpContext.Current.Request.ClientCertificate));
    x.For&lt;IHttpContext&gt;().Use(
        c => WebContext.Cast(HttpContext.Current));
    x.For&lt;IHttpFileCollection&gt;().Use(
        c => WebContext.Cast(HttpContext.Current.Request.Files));
    x.For&lt;IHttpModuleCollection&gt;().Use(
        c => WebContext.Cast(HttpContext.Current.ApplicationInstance.Modules));
    x.For&lt;IHttpRequest&gt;().Use(
        c => WebContext.Cast(HttpContext.Current.Request));
    x.For&lt;IHttpResponse&gt;().Use(
        c => WebContext.Cast(HttpContext.Current.Response));
    x.For&lt;IHttpServerUtility&gt;().Use(
        c => WebContext.Cast(HttpContext.Current.Server));
    x.For&lt;IHttpSession&gt;().Use(
        c => WebContext.Cast(HttpContext.Current.Session));
    x.For&lt;ITraceContext&gt;().Use(
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

This was originally inspired by <a href="http://haacked.com/archive/2007/09/09/ihttpcontext-and-other-interfaces-for-your-duck-typing-benefit.aspx">this blog post</a> by Phil Haack.  In Phil's post, he uses a library that dynamically generates the interfaces.  I ran into some problems with the library that did this... it sometimes would throw an exception generating the interface code and I would have to restart IIS.  So I spent the 20 minutes that it took to create the interfaces and implement the proxy classes by hand.

Have fun!
