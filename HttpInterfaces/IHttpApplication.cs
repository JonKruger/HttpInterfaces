using System;
using System.Security.Principal;
using System.Web;

namespace HttpInterfaces
{  
    public interface IHttpApplication
    {
        IHttpContext Context {get;}
        
        IHttpRequest Request {get;}
        
        IHttpResponse Response {get;}
        
        IHttpSession Session {get;}
        
        IHttpApplicationState Application { get; }
        
        IHttpServerUtility Server {get;}
        
        IPrincipal User {get;}
        
        IHttpModuleCollection Modules{get;}
                
        event EventHandler BeginRequest;
        
        event EventHandler AuthenticateRequest;
        
        event EventHandler PostAuthenticateRequest;
        
        event EventHandler AuthorizeRequest;
        
        event EventHandler PostAuthorizeRequest;
        
        event EventHandler ResolveRequestCache;
        
        event EventHandler PostResolveRequestCache;
        
        event EventHandler MapRequestHandler;
        
        event EventHandler PostMapRequestHandler;
        
        event EventHandler AcquireRequestState;
        
        event EventHandler PostAcquireRequestState;
        
        event EventHandler PreRequestHandlerExecute;
        
        event EventHandler PostRequestHandlerExecute;
        
        event EventHandler ReleaseRequestState;
        
        event EventHandler PostReleaseRequestState;
        
        event EventHandler UpdateRequestCache;
        
        event EventHandler PostUpdateRequestCache;
        
        event EventHandler LogRequest;
        
        event EventHandler PostLogRequest;
        
        event EventHandler EndRequest;
        
        event EventHandler Error;
        
        event EventHandler PreSendRequestHeaders;
        
        event EventHandler PreSendRequestContent;
        
        void CompleteRequest();
        
        void AddOnBeginRequestAsync(BeginEventHandler bh, EndEventHandler eh);
        
        void AddOnBeginRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);
        
        void AddOnAuthenticateRequestAsync(BeginEventHandler bh, EndEventHandler eh);
        
        void AddOnAuthenticateRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);
        
        void AddOnPostAuthenticateRequestAsync(BeginEventHandler bh, EndEventHandler eh);
        
        void AddOnPostAuthenticateRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);
        
        void AddOnAuthorizeRequestAsync(BeginEventHandler bh, EndEventHandler eh);
        
        void AddOnAuthorizeRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);
        
        void AddOnPostAuthorizeRequestAsync(BeginEventHandler bh, EndEventHandler eh);
        
        void AddOnPostAuthorizeRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);
        
        void AddOnResolveRequestCacheAsync(BeginEventHandler bh, EndEventHandler eh);
        
        void AddOnResolveRequestCacheAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);
        
        void AddOnPostResolveRequestCacheAsync(BeginEventHandler bh, EndEventHandler eh);
        
        void AddOnPostResolveRequestCacheAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);
        
        void AddOnMapRequestHandlerAsync(BeginEventHandler bh, EndEventHandler eh);
        
        void AddOnMapRequestHandlerAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);
        
        void AddOnPostMapRequestHandlerAsync(BeginEventHandler bh, EndEventHandler eh);
        
        void AddOnPostMapRequestHandlerAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);
        
        void AddOnAcquireRequestStateAsync(BeginEventHandler bh, EndEventHandler eh);
        
        void AddOnAcquireRequestStateAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);
        
        void AddOnPostAcquireRequestStateAsync(BeginEventHandler bh, EndEventHandler eh);
        
        void AddOnPostAcquireRequestStateAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);
        
        void AddOnPreRequestHandlerExecuteAsync(BeginEventHandler bh, EndEventHandler eh);
        
        void AddOnPreRequestHandlerExecuteAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);
        
        void AddOnPostRequestHandlerExecuteAsync(BeginEventHandler bh, EndEventHandler eh);
        
        void AddOnPostRequestHandlerExecuteAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);
        
        void AddOnReleaseRequestStateAsync(BeginEventHandler bh, EndEventHandler eh);
        
        void AddOnReleaseRequestStateAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);
        
        void AddOnPostReleaseRequestStateAsync(BeginEventHandler bh, EndEventHandler eh);
        
        void AddOnPostReleaseRequestStateAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);
        
        void AddOnUpdateRequestCacheAsync(BeginEventHandler bh, EndEventHandler eh);
        
        void AddOnUpdateRequestCacheAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);
        
        void AddOnPostUpdateRequestCacheAsync(BeginEventHandler bh, EndEventHandler eh);
        
        void AddOnPostUpdateRequestCacheAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);
        
        void AddOnLogRequestAsync(BeginEventHandler bh, EndEventHandler eh);
        
        void AddOnLogRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);
        
        void AddOnPostLogRequestAsync(BeginEventHandler bh, EndEventHandler eh);
        
        void AddOnPostLogRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);
        
        void AddOnEndRequestAsync(BeginEventHandler bh, EndEventHandler eh);
        
        void AddOnEndRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);
        
        void Init();

		string GetVaryByCustomString(IHttpContext context, string custom);
    }

    public class HttpApplicationProxy : IHttpApplication
    {
        private readonly HttpApplication _httpApplication;

        public HttpApplicationProxy(HttpApplication httpApplication)
        {
            _httpApplication = httpApplication;
        }

        public IHttpContext Context
        {
            get { return new HttpContextProxy(_httpApplication.Context); }
        }

        public IHttpRequest Request
        {
            get { return new HttpRequestProxy(_httpApplication.Request); }
        }

        public IHttpResponse Response
        {
            get { return new HttpResponseProxy(_httpApplication.Response); }
        }

        public IHttpSession Session
        {
            get { return new HttpSessionProxy(_httpApplication.Session); }
        }

        public IHttpApplicationState Application
        {
            get { return new HttpApplicationStateProxy(_httpApplication.Application); }
        }

        public IHttpServerUtility Server
        {
            get { return new HttpServerUtilityProxy(_httpApplication.Server); }
        }

        public IPrincipal User
        {
            get { return _httpApplication.User; }
        }

        public IHttpModuleCollection Modules
        {
            get { return new HttpModuleCollectionProxy(_httpApplication.Modules); }
        }

        event EventHandler IHttpApplication.BeginRequest
        {
            add { _httpApplication.BeginRequest += value; }
            remove { _httpApplication.BeginRequest -= value; }
        }

        event EventHandler IHttpApplication.AuthenticateRequest
        {
            add { _httpApplication.AuthenticateRequest += value; }
            remove { _httpApplication.AuthenticateRequest -= value; }
        }

        event EventHandler IHttpApplication.PostAuthenticateRequest
        {
            add { _httpApplication.PostAuthenticateRequest += value; }
            remove { _httpApplication.PostAuthenticateRequest -= value; }
        }

        event EventHandler IHttpApplication.AuthorizeRequest
        {
            add { _httpApplication.AuthorizeRequest += value; }
            remove { _httpApplication.AuthorizeRequest -= value; }
        }

        event EventHandler IHttpApplication.PostAuthorizeRequest
        {
            add { _httpApplication.PostAuthorizeRequest += value; }
            remove { _httpApplication.PostAuthorizeRequest -= value; }
        }

        event EventHandler IHttpApplication.ResolveRequestCache
        {
            add { _httpApplication.ResolveRequestCache += value; }
            remove { _httpApplication.ResolveRequestCache -= value; }
        }

        event EventHandler IHttpApplication.PostResolveRequestCache
        {
            add { _httpApplication.PostResolveRequestCache += value; }
            remove { _httpApplication.PostResolveRequestCache -= value; }
        }

        event EventHandler IHttpApplication.MapRequestHandler
        {
            add { _httpApplication.MapRequestHandler += value; }
            remove { _httpApplication.MapRequestHandler -= value; }
        }

        event EventHandler IHttpApplication.PostMapRequestHandler
        {
            add { _httpApplication.PostMapRequestHandler += value; }
            remove { _httpApplication.PostMapRequestHandler -= value; }
        }

        event EventHandler IHttpApplication.AcquireRequestState
        {
            add { _httpApplication.AcquireRequestState += value; }
            remove { _httpApplication.AcquireRequestState -= value; }
        }

        event EventHandler IHttpApplication.PostAcquireRequestState
        {
            add { _httpApplication.PostAcquireRequestState += value; }
            remove { _httpApplication.PostAcquireRequestState -= value; }
        }

        event EventHandler IHttpApplication.PreRequestHandlerExecute
        {
            add { _httpApplication.PreRequestHandlerExecute += value; }
            remove { _httpApplication.PreRequestHandlerExecute -= value; }
        }

        event EventHandler IHttpApplication.PostRequestHandlerExecute
        {
            add { _httpApplication.PostRequestHandlerExecute += value; }
            remove { _httpApplication.PostRequestHandlerExecute -= value; }
        }

        event EventHandler IHttpApplication.ReleaseRequestState
        {
            add { _httpApplication.ReleaseRequestState += value; }
            remove { _httpApplication.ReleaseRequestState -= value; }
        }

        event EventHandler IHttpApplication.PostReleaseRequestState
        {
            add { _httpApplication.PostReleaseRequestState += value; }
            remove { _httpApplication.PostReleaseRequestState -= value; }
        }

        event EventHandler IHttpApplication.UpdateRequestCache
        {
            add { _httpApplication.UpdateRequestCache += value; }
            remove { _httpApplication.UpdateRequestCache -= value; }
        }

        event EventHandler IHttpApplication.PostUpdateRequestCache
        {
            add { _httpApplication.PostUpdateRequestCache += value; }
            remove { _httpApplication.PostUpdateRequestCache -= value; }
        }

        event EventHandler IHttpApplication.LogRequest
        {
            add { _httpApplication.LogRequest += value; }
            remove { _httpApplication.LogRequest -= value; }
        }

        event EventHandler IHttpApplication.PostLogRequest
        {
            add { _httpApplication.PostLogRequest += value; }
            remove { _httpApplication.PostLogRequest -= value; }
        }

        event EventHandler IHttpApplication.EndRequest
        {
            add { _httpApplication.EndRequest += value; }
            remove { _httpApplication.EndRequest -= value; }
        }

        event EventHandler IHttpApplication.Error
        {
            add { _httpApplication.Error += value; }
            remove { _httpApplication.Error -= value; }
        }

        event EventHandler IHttpApplication.PreSendRequestHeaders
        {
            add { _httpApplication.PreSendRequestHeaders += value; }
            remove { _httpApplication.PreSendRequestHeaders -= value; }
        }

        event EventHandler IHttpApplication.PreSendRequestContent
        {
            add { _httpApplication.PreSendRequestContent += value; }
            remove { _httpApplication.PreSendRequestContent -= value; }
        }

        public void CompleteRequest()
        {
            _httpApplication.CompleteRequest();
        }

        public void AddOnBeginRequestAsync(BeginEventHandler bh, EndEventHandler eh)
        {
            _httpApplication.AddOnBeginRequestAsync(bh, eh);
        }

        public void AddOnBeginRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state)
        {
            _httpApplication.AddOnBeginRequestAsync(beginHandler, endHandler, state);
        }

        public void AddOnAuthenticateRequestAsync(BeginEventHandler bh, EndEventHandler eh)
        {
            _httpApplication.AddOnAuthenticateRequestAsync(bh, eh);
        }

        public void AddOnAuthenticateRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state)
        {
            _httpApplication.AddOnAuthenticateRequestAsync(beginHandler, endHandler, state);
        }

        public void AddOnPostAuthenticateRequestAsync(BeginEventHandler bh, EndEventHandler eh)
        {
            _httpApplication.AddOnPostAuthenticateRequestAsync(bh, eh);
        }

        public void AddOnPostAuthenticateRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state)
        {
            _httpApplication.AddOnPostAuthenticateRequestAsync(beginHandler, endHandler, state);
        }

        public void AddOnAuthorizeRequestAsync(BeginEventHandler bh, EndEventHandler eh)
        {
            _httpApplication.AddOnAuthorizeRequestAsync(bh, eh);
        }

        public void AddOnAuthorizeRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state)
        {
            _httpApplication.AddOnAuthorizeRequestAsync(beginHandler, endHandler, state);
        }

        public void AddOnPostAuthorizeRequestAsync(BeginEventHandler bh, EndEventHandler eh)
        {
            _httpApplication.AddOnPostAuthorizeRequestAsync(bh, eh);
        }

        public void AddOnPostAuthorizeRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state)
        {
            _httpApplication.AddOnPostAuthorizeRequestAsync(beginHandler, endHandler, state);
        }

        public void AddOnResolveRequestCacheAsync(BeginEventHandler bh, EndEventHandler eh)
        {
            _httpApplication.AddOnResolveRequestCacheAsync(bh, eh);
        }

        public void AddOnResolveRequestCacheAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state)
        {
            _httpApplication.AddOnResolveRequestCacheAsync(beginHandler, endHandler, state);
        }

        public void AddOnPostResolveRequestCacheAsync(BeginEventHandler bh, EndEventHandler eh)
        {
            _httpApplication.AddOnPostResolveRequestCacheAsync(bh, eh);
        }

        public void AddOnPostResolveRequestCacheAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state)
        {
            _httpApplication.AddOnPostResolveRequestCacheAsync(beginHandler, endHandler, state);
        }

        public void AddOnMapRequestHandlerAsync(BeginEventHandler bh, EndEventHandler eh)
        {
            _httpApplication.AddOnMapRequestHandlerAsync(bh, eh);
        }

        public void AddOnMapRequestHandlerAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state)
        {
            _httpApplication.AddOnMapRequestHandlerAsync(beginHandler, endHandler, state);
        }

        public void AddOnPostMapRequestHandlerAsync(BeginEventHandler bh, EndEventHandler eh)
        {
            _httpApplication.AddOnPostMapRequestHandlerAsync(bh, eh);
        }

        public void AddOnPostMapRequestHandlerAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state)
        {
            _httpApplication.AddOnPostMapRequestHandlerAsync(beginHandler, endHandler, state);
        }

        public void AddOnAcquireRequestStateAsync(BeginEventHandler bh, EndEventHandler eh)
        {
            _httpApplication.AddOnAcquireRequestStateAsync(bh, eh);
        }

        public void AddOnAcquireRequestStateAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state)
        {
            _httpApplication.AddOnAcquireRequestStateAsync(beginHandler, endHandler, state);
        }

        public void AddOnPostAcquireRequestStateAsync(BeginEventHandler bh, EndEventHandler eh)
        {
            _httpApplication.AddOnPostAcquireRequestStateAsync(bh, eh);
        }

        public void AddOnPostAcquireRequestStateAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state)
        {
            _httpApplication.AddOnPostAcquireRequestStateAsync(beginHandler, endHandler, state);
        }

        public void AddOnPreRequestHandlerExecuteAsync(BeginEventHandler bh, EndEventHandler eh)
        {
            _httpApplication.AddOnPreRequestHandlerExecuteAsync(bh, eh);
        }

        public void AddOnPreRequestHandlerExecuteAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state)
        {
            _httpApplication.AddOnPreRequestHandlerExecuteAsync(beginHandler, endHandler, state);
        }

        public void AddOnPostRequestHandlerExecuteAsync(BeginEventHandler bh, EndEventHandler eh)
        {
            _httpApplication.AddOnPostRequestHandlerExecuteAsync(bh, eh);
        }

        public void AddOnPostRequestHandlerExecuteAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state)
        {
            _httpApplication.AddOnPostRequestHandlerExecuteAsync(beginHandler, endHandler, state);
        }

        public void AddOnReleaseRequestStateAsync(BeginEventHandler bh, EndEventHandler eh)
        {
            _httpApplication.AddOnReleaseRequestStateAsync(bh, eh);
        }

        public void AddOnReleaseRequestStateAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state)
        {
            _httpApplication.AddOnReleaseRequestStateAsync(beginHandler, endHandler, state);
        }

        public void AddOnPostReleaseRequestStateAsync(BeginEventHandler bh, EndEventHandler eh)
        {
            _httpApplication.AddOnPostReleaseRequestStateAsync(bh, eh);
        }

        public void AddOnPostReleaseRequestStateAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state)
        {
            _httpApplication.AddOnPostReleaseRequestStateAsync(beginHandler, endHandler, state);
        }

        public void AddOnUpdateRequestCacheAsync(BeginEventHandler bh, EndEventHandler eh)
        {
            _httpApplication.AddOnUpdateRequestCacheAsync(bh, eh);
        }

        public void AddOnUpdateRequestCacheAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state)
        {
            _httpApplication.AddOnUpdateRequestCacheAsync(beginHandler, endHandler, state);
        }

        public void AddOnPostUpdateRequestCacheAsync(BeginEventHandler bh, EndEventHandler eh)
        {
            _httpApplication.AddOnPostUpdateRequestCacheAsync(bh, eh);
        }

        public void AddOnPostUpdateRequestCacheAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state)
        {
            _httpApplication.AddOnPostUpdateRequestCacheAsync(beginHandler, endHandler, state);
        }

        public void AddOnLogRequestAsync(BeginEventHandler bh, EndEventHandler eh)
        {
            _httpApplication.AddOnLogRequestAsync(bh, eh);
        }

        public void AddOnLogRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state)
        {
            _httpApplication.AddOnLogRequestAsync(beginHandler, endHandler, state);
        }

        public void AddOnPostLogRequestAsync(BeginEventHandler bh, EndEventHandler eh)
        {
            _httpApplication.AddOnPostLogRequestAsync(bh, eh);
        }

        public void AddOnPostLogRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state)
        {
            _httpApplication.AddOnPostLogRequestAsync(beginHandler, endHandler, state);
        }

        public void AddOnEndRequestAsync(BeginEventHandler bh, EndEventHandler eh)
        {
            _httpApplication.AddOnEndRequestAsync(bh, eh);
        }

        public void AddOnEndRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state)
        {
            _httpApplication.AddOnEndRequestAsync(beginHandler, endHandler, state);
        }

        public void Init()
        {
            _httpApplication.Init();
        }

        public string GetVaryByCustomString(IHttpContext context, string custom)
        {
            return _httpApplication.GetVaryByCustomString(context != null ? context.GetInternalHttpContext() : null, custom);
        }
    }
}
