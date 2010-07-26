using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace HttpInterfaces
{
	public interface IHttpResponse
	{
		void AddCacheDependency(params CacheDependency[] dependencies);
		void AddCacheItemDependencies(string[] cacheKeys);
		void AddCacheItemDependencies(ArrayList cacheKeys);
		void AddCacheItemDependency(string cacheKey);
		void AddFileDependencies(ArrayList filenames);
		void AddFileDependencies(string[] filenames);
		void AddFileDependency(string filename);
		void AddHeader(string name, string value);
		void AppendCookie(HttpCookie cookie);
		void AppendHeader(string name, string value);
		void AppendToLog(string param);
		string ApplyAppPathModifier(string virtualPath);
		void BinaryWrite(byte[] buffer);
		void Clear();
		void ClearContent();
		void ClearHeaders();
		void Close();
		void DisableKernelCache();
		void End();
		void Flush();
		void Pics(string value);
		void Redirect(string url);
		void Redirect(string url, bool endResponse);
		void SetCookie(HttpCookie cookie);
		void TransmitFile(string filename);
		void TransmitFile(string filename, long offset, long length);
		void Write(char ch);
		void Write(object obj);
		void Write(string s);
		void Write(char[] buffer, int index, int count);
		void WriteFile(string filename);
		void WriteFile(string filename, bool readIntoMemory);
		void WriteFile(IntPtr fileHandle, long offset, long size);
		void WriteFile(string filename, long offset, long size);
		void WriteSubstitution(HttpResponseSubstitutionCallback callback);
		// Properties
		bool Buffer { get; set; }
		bool BufferOutput { get; set; }
		IHttpCachePolicy Cache { get; }
		string CacheControl { get; set; }
		string Charset { get; set; }
		Encoding ContentEncoding { get; set; }
		string ContentType { get; set; }
		HttpCookieCollection Cookies { get; }
		int Expires { get; set; }
		DateTime ExpiresAbsolute { get; set; }
		Stream Filter { get; set; }
		Encoding HeaderEncoding { get; set; }
		NameValueCollection Headers { get; }
		bool IsClientConnected { get; }
		bool IsRequestBeingRedirected { get; }
		TextWriter Output { get; }
		Stream OutputStream { get; }
		string RedirectLocation { get; set; }
		string Status { get; set; }
		int StatusCode { get; set; }
		string StatusDescription { get; set; }
		int SubStatusCode { get; set; }
		bool SuppressContent { get; set; }
	}

    public class HttpResponseProxy : IHttpResponse
    {
        private readonly HttpResponse _httpResponse;

        public HttpResponseProxy(HttpResponse httpResponse)
        {
            _httpResponse = httpResponse;
        }

        public bool Buffer
        {
            get { return _httpResponse.Buffer; }
            set { _httpResponse.Buffer = value; }
        }

        public bool BufferOutput
        {
            get { return _httpResponse.BufferOutput; }
            set { _httpResponse.BufferOutput = value; }
        }

        public IHttpCachePolicy Cache
        {
            get { return new HttpCachePolicyProxy(_httpResponse.Cache); }
        }

        public string CacheControl
        {
            get { return _httpResponse.CacheControl; }
            set { _httpResponse.CacheControl = value; }
        }

        public string Charset
        {
            get { return _httpResponse.Charset; }
            set { _httpResponse.Charset = value; }
        }

        public Encoding ContentEncoding
        {
            get { return _httpResponse.ContentEncoding; }
            set { _httpResponse.ContentEncoding = value; }
        }

        public string ContentType
        {
            get { return _httpResponse.ContentType; }
            set { _httpResponse.ContentType = value; }
        }

        public HttpCookieCollection Cookies
        {
            get { return _httpResponse.Cookies; }
        }

        public int Expires
        {
            get { return _httpResponse.Expires; }
            set { _httpResponse.Expires = value; }
        }

        public DateTime ExpiresAbsolute
        {
            get { return _httpResponse.ExpiresAbsolute; }
            set { _httpResponse.ExpiresAbsolute = value; }
        }

        public Stream Filter
        {
            get { return _httpResponse.Filter; }
            set { _httpResponse.Filter = value; }
        }

        public Encoding HeaderEncoding
        {
            get { return _httpResponse.HeaderEncoding; }
            set { _httpResponse.HeaderEncoding = value; }
        }

        public NameValueCollection Headers
        {
            get { return _httpResponse.Headers; }
        }

        public bool IsClientConnected
        {
            get { return _httpResponse.IsClientConnected; }
        }

        public bool IsRequestBeingRedirected
        {
            get { return _httpResponse.IsRequestBeingRedirected; }
        }

        public TextWriter Output
        {
            get { return _httpResponse.Output; }
        }

        public Stream OutputStream
        {
            get { return _httpResponse.OutputStream; }
        }

        public string RedirectLocation
        {
            get { return _httpResponse.RedirectLocation; }
            set { _httpResponse.RedirectLocation = value; }
        }

        public string Status
        {
            get { return _httpResponse.Status; }
            set { _httpResponse.Status = value; }
        }

        public int StatusCode
        {
            get { return _httpResponse.StatusCode; }
            set { _httpResponse.StatusCode = value; }
        }

        public string StatusDescription
        {
            get { return _httpResponse.StatusDescription; }
            set { _httpResponse.StatusDescription = value; }
        }

        public int SubStatusCode
        {
            get { return _httpResponse.SubStatusCode; }
            set { _httpResponse.SubStatusCode = value; }
        }

        public bool SuppressContent
        {
            get { return _httpResponse.SuppressContent; }
            set { _httpResponse.SuppressContent = value; }
        }

        public void AddCacheDependency(CacheDependency[] dependencies)
        {
            _httpResponse.AddCacheDependency(dependencies);
        }

        public void AddCacheItemDependencies(string[] cacheKeys)
        {
            _httpResponse.AddCacheItemDependencies(cacheKeys);
        }

        public void AddCacheItemDependencies(ArrayList cacheKeys)
        {
            _httpResponse.AddCacheItemDependencies(cacheKeys);
        }

        public void AddCacheItemDependency(string cacheKey)
        {
            _httpResponse.AddCacheItemDependency(cacheKey);
        }

        public void AddFileDependencies(ArrayList filenames)
        {
            _httpResponse.AddFileDependencies(filenames);
        }

        public void AddFileDependencies(string[] filenames)
        {
            _httpResponse.AddFileDependencies(filenames);
        }

        public void AddFileDependency(string filename)
        {
            _httpResponse.AddFileDependency(filename);
        }

        public void AddHeader(string name, string value)
        {
            _httpResponse.AddHeader(name, value);
        }

        public void AppendCookie(HttpCookie cookie)
        {
            _httpResponse.AppendCookie(cookie);
        }

        public void AppendHeader(string name, string value)
        {
            _httpResponse.AppendHeader(name, value);
        }

        public void AppendToLog(string param)
        {
            _httpResponse.AppendToLog(param);
        }

        public string ApplyAppPathModifier(string virtualPath)
        {
            return _httpResponse.ApplyAppPathModifier(virtualPath);
        }

        public void BinaryWrite(byte[] buffer)
        {
            _httpResponse.BinaryWrite(buffer);
        }

        public void Clear()
        {
            _httpResponse.Clear();
        }

        public void ClearContent()
        {
            _httpResponse.ClearContent();
        }

        public void ClearHeaders()
        {
            _httpResponse.ClearHeaders();
        }

        public void Close()
        {
            _httpResponse.Close();
        }

        public void DisableKernelCache()
        {
            _httpResponse.DisableKernelCache();
        }

        public void End()
        {
            _httpResponse.End();
        }

        public void Flush()
        {
            _httpResponse.Flush();
        }

        public void Pics(string value)
        {
            _httpResponse.Pics(value);
        }

        public void Redirect(string url)
        {
            _httpResponse.Redirect(url);
        }

        public void Redirect(string url, bool endResponse)
        {
            _httpResponse.Redirect(url, endResponse);
        }

        public void SetCookie(HttpCookie cookie)
        {
            _httpResponse.SetCookie(cookie);
        }

        public void TransmitFile(string filename)
        {
            _httpResponse.TransmitFile(filename);
        }

        public void TransmitFile(string filename, long offset, long length)
        {
            _httpResponse.TransmitFile(filename, offset, length);
        }

        public void Write(char ch)
        {
            _httpResponse.Write(ch);
        }

        public void Write(object obj)
        {
            _httpResponse.Write(obj);
        }

        public void Write(string s)
        {
            _httpResponse.Write(s);
        }

        public void Write(char[] buffer, int index, int count)
        {
            _httpResponse.Write(buffer, index, count);
        }

        public void WriteFile(string filename)
        {
            _httpResponse.WriteFile(filename);
        }

        public void WriteFile(string filename, bool readIntoMemory)
        {
            _httpResponse.WriteFile(filename, readIntoMemory);
        }

        public void WriteFile(IntPtr fileHandle, long offset, long size)
        {
            _httpResponse.WriteFile(fileHandle, offset, size);
        }

        public void WriteFile(string filename, long offset, long size)
        {
            _httpResponse.WriteFile(filename, offset, size);
        }

        public void WriteSubstitution(HttpResponseSubstitutionCallback callback)
        {
            _httpResponse.WriteSubstitution(callback);
        }
    }
}
