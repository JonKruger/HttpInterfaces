using System;
using System.Web;
    
namespace HttpInterfaces
{
   
    public interface IHttpCachePolicy
    {
        HttpCacheVaryByContentEncodings VaryByContentEncodings
        {
            get;
        }
        
        HttpCacheVaryByHeaders VaryByHeaders
        {
            get;
        }
        
        HttpCacheVaryByParams VaryByParams
        {
            get;
        }
        
        void SetNoServerCaching();
        
        void SetVaryByCustom(string custom);
        
        void AppendCacheExtension(string extension);
        
        void SetNoTransforms();
        
        void SetCacheability(HttpCacheability cacheability);
        
        void SetCacheability(HttpCacheability cacheability, string field);
        
        void SetNoStore();
        
        void SetExpires(DateTime date);
        
        void SetMaxAge(TimeSpan delta);
        
        void SetProxyMaxAge(TimeSpan delta);
        
        void SetSlidingExpiration(bool slide);
        
        void SetValidUntilExpires(bool validUntilExpires);
        
        void SetAllowResponseInBrowserHistory(bool allow);
        
        void SetRevalidation(HttpCacheRevalidation revalidation);
        
        void SetETag(string etag);
        
        void SetLastModified(DateTime date);
        
        void SetLastModifiedFromFileDependencies();
        
        void SetETagFromFileDependencies();
        
        void SetOmitVaryStar(bool omit);
        
        void AddValidationCallback(HttpCacheValidateHandler handler, object data);
    }

    public class HttpCachePolicyProxy : IHttpCachePolicy
    {
        private readonly HttpCachePolicy _httpCachePolicy;

        public HttpCachePolicyProxy(HttpCachePolicy httpCachePolicy)
        {
            _httpCachePolicy = httpCachePolicy;
        }

        public HttpCacheVaryByContentEncodings VaryByContentEncodings
        {
            get { return _httpCachePolicy.VaryByContentEncodings; }
        }

        public HttpCacheVaryByHeaders VaryByHeaders
        {
            get { return _httpCachePolicy.VaryByHeaders; }
        }

        public HttpCacheVaryByParams VaryByParams
        {
            get { return _httpCachePolicy.VaryByParams; }
        }

        public void SetNoServerCaching()
        {
            _httpCachePolicy.SetNoServerCaching();
        }

        public void SetVaryByCustom(string custom)
        {
            _httpCachePolicy.SetVaryByCustom(custom);
        }

        public void AppendCacheExtension(string extension)
        {
            _httpCachePolicy.AppendCacheExtension(extension);
        }

        public void SetNoTransforms()
        {
            _httpCachePolicy.SetNoTransforms();
        }

        public void SetCacheability(HttpCacheability cacheability)
        {
            _httpCachePolicy.SetCacheability(cacheability);
        }

        public void SetCacheability(HttpCacheability cacheability, string field)
        {
            _httpCachePolicy.SetCacheability(cacheability, field);
        }

        public void SetNoStore()
        {
            _httpCachePolicy.SetNoStore();
        }

        public void SetExpires(DateTime date)
        {
            _httpCachePolicy.SetExpires(date);
        }

        public void SetMaxAge(TimeSpan delta)
        {
            _httpCachePolicy.SetMaxAge(delta);
        }

        public void SetProxyMaxAge(TimeSpan delta)
        {
            _httpCachePolicy.SetProxyMaxAge(delta);
        }

        public void SetSlidingExpiration(bool slide)
        {
            _httpCachePolicy.SetSlidingExpiration(slide);
        }

        public void SetValidUntilExpires(bool validUntilExpires)
        {
            _httpCachePolicy.SetValidUntilExpires(validUntilExpires);
        }

        public void SetAllowResponseInBrowserHistory(bool allow)
        {
            _httpCachePolicy.SetAllowResponseInBrowserHistory(allow);
        }

        public void SetRevalidation(HttpCacheRevalidation revalidation)
        {
            _httpCachePolicy.SetRevalidation(revalidation);
        }

        public void SetETag(string etag)
        {
            _httpCachePolicy.SetETag(etag);
        }

        public void SetLastModified(DateTime date)
        {
            _httpCachePolicy.SetLastModified(date);
        }

        public void SetLastModifiedFromFileDependencies()
        {
            _httpCachePolicy.SetLastModifiedFromFileDependencies();
        }

        public void SetETagFromFileDependencies()
        {
            _httpCachePolicy.SetETagFromFileDependencies();
        }

        public void SetOmitVaryStar(bool omit)
        {
            _httpCachePolicy.SetOmitVaryStar(omit);
        }

        public void AddValidationCallback(HttpCacheValidateHandler handler, object data)
        {
            _httpCachePolicy.AddValidationCallback(handler, data);
        }
    }
}
