using System;
using System.Collections;
using System.Security.Principal;
using System.Web;
using System.Web.Profile;

namespace HttpInterfaces
{
	public interface IHttpContext
	{
		void AddError(Exception errorInfo);
		void ClearError();
		object GetSection(string sectionName);
		void RewritePath(string path);
		void RewritePath(string path, bool rebaseClientPath);
		void RewritePath(string filePath, string pathInfo, string queryString);
		void RewritePath(string filePath, string pathInfo, string queryString, bool setClientFilePath);
		
		// Properties
		Exception[] AllErrors { get; }
		
		IHttpApplicationState Application { get; }
		IHttpApplication ApplicationInstance { get; set; }
		
		ICache Cache { get; }
		IHttpHandler CurrentHandler { get; }
		RequestNotification CurrentNotification { get;}
		Exception Error { get; }
		IHttpHandler Handler { get; set; }
		bool IsCustomErrorEnabled { get; }
		bool IsDebuggingEnabled { get; }
		bool IsPostNotification { get; }
		IDictionary Items { get; }
		IHttpHandler PreviousHandler { get; }
		ProfileBase Profile { get; }
		IHttpRequest Request { get; }
		IHttpResponse Response { get; }
		IHttpServerUtility Server { get; }
		IHttpSession Session { get; }
		bool SkipAuthorization { get; set; }
		DateTime Timestamp { get; }
		ITraceContext Trace { get; }
		IPrincipal User { get; set; }

	    HttpContext GetInternalHttpContext();
	}

    public class HttpContextProxy : IHttpContext
    {
        private readonly HttpContext _httpContext;

        public HttpContextProxy(HttpContext httpContext)
        {
            _httpContext = httpContext;
        }

        public Exception[] AllErrors
        {
            get { return _httpContext.AllErrors; }
        }

        public IHttpApplicationState Application
        {
            get { return new HttpApplicationStateProxy(_httpContext.Application); }
        }

        public IHttpApplication ApplicationInstance
        {
            get { return new HttpApplicationProxy(_httpContext.ApplicationInstance); }
            set { _httpContext.ApplicationInstance = (HttpApplication) value; }
        }

        public ICache Cache
        {
            get { return new CacheProxy(_httpContext.Cache); }
        }

        public IHttpHandler CurrentHandler
        {
            get { return _httpContext.CurrentHandler; }
        }

        public RequestNotification CurrentNotification
        {
            get { return _httpContext.CurrentNotification; }
        }

        public Exception Error
        {
            get { return _httpContext.Error; }
        }

        public IHttpHandler Handler
        {
            get { return _httpContext.Handler; }
            set { _httpContext.Handler = value; }
        }

        public bool IsCustomErrorEnabled
        {
            get { return _httpContext.IsCustomErrorEnabled; }
        }

        public bool IsDebuggingEnabled
        {
            get { return _httpContext.IsDebuggingEnabled; }
        }

        public bool IsPostNotification
        {
            get { return _httpContext.IsPostNotification; }
        }

        public IDictionary Items
        {
            get { return _httpContext.Items; }
        }

        public IHttpHandler PreviousHandler
        {
            get { return _httpContext.PreviousHandler; }
        }

        public ProfileBase Profile
        {
            get { return _httpContext.Profile; }
        }

        public IHttpRequest Request
        {
            get { return new HttpRequestProxy(_httpContext.Request); }
        }

        public IHttpResponse Response
        {
            get { return new HttpResponseProxy(_httpContext.Response); }
        }

        public IHttpServerUtility Server
        {
            get { return new HttpServerUtilityProxy(_httpContext.Server); }
        }

        public IHttpSession Session
        {
            get { return new HttpSessionProxy(_httpContext.Session); }
        }

        public bool SkipAuthorization
        {
            get { return _httpContext.SkipAuthorization; }
            set { _httpContext.SkipAuthorization = value; }
        }

        public DateTime Timestamp
        {
            get { return _httpContext.Timestamp; }
        }

        public ITraceContext Trace
        {
            get { return new TraceContextProxy(_httpContext.Trace); }
        }

        public IPrincipal User
        {
            get { return _httpContext.User; }
            set { _httpContext.User = value; }
        }

        public void AddError(Exception errorInfo)
        {
            _httpContext.AddError(errorInfo);
        }

        public void ClearError()
        {
            _httpContext.ClearError();
        }

        public object GetSection(string sectionName)
        {
            return _httpContext.GetSection(sectionName);
        }

        public void RewritePath(string path)
        {
            _httpContext.RewritePath(path);
        }

        public void RewritePath(string path, bool rebaseClientPath)
        {
            _httpContext.RewritePath(path, rebaseClientPath);
        }

        public void RewritePath(string filePath, string pathInfo, string queryString)
        {
            _httpContext.RewritePath(filePath, pathInfo, queryString);
        }

        public void RewritePath(string filePath, string pathInfo, string queryString, bool setClientFilePath)
        {
            _httpContext.RewritePath(filePath, pathInfo, queryString, setClientFilePath);
        }

        /// <summary>
        /// Get the concrete HttpContext object that is wrapped by this wrapper class.
        /// </summary>
        /// <returns></returns>
        public HttpContext GetInternalHttpContext()
        {
            return _httpContext;
        }
    }
}
