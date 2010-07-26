using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Web;

namespace HttpInterfaces
{
	public interface IHttpRequest
	{
		byte[] BinaryRead(int count);
		int[] MapImageCoordinates(string imageFieldName);
		string MapPath(string virtualPath);
		string MapPath(string virtualPath, string baseVirtualDir, bool allowCrossAppMapping);
		void SaveAs(string filename, bool includeHeaders);
		void ValidateInput();
		
		// Properties
		string[] AcceptTypes { get; }
		string AnonymousID { get; }
		string ApplicationPath { get; }
		string AppRelativeCurrentExecutionFilePath { get; }
		HttpBrowserCapabilities Browser { get; set; }
		IHttpClientCertificate ClientCertificate { get; }
		Encoding ContentEncoding { get; set; }
		int ContentLength { get; }
		string ContentType { get; set; }
		HttpCookieCollection Cookies { get; }
		string CurrentExecutionFilePath { get; }
		string FilePath { get; }
		IHttpFileCollection Files { get; }
		Stream Filter { get; set; }
		NameValueCollection Form { get; }
		NameValueCollection Headers { get; }
		string HttpMethod { get; }
		Stream InputStream { get; }
		bool IsAuthenticated { get; }
		bool IsLocal { get; }
		bool IsSecureConnection { get; }
		string this[string key] { get; }
		NameValueCollection Params { get; }
		string Path { get; }
		string PathInfo { get; }
		string PhysicalApplicationPath { get; }
		string PhysicalPath { get; }
		NameValueCollection QueryString { get; }
		string RawUrl { get; }
		string RequestType { get; set; }
		NameValueCollection ServerVariables { get; }
		int TotalBytes { get; }
		Uri Url { get; }
		Uri UrlReferrer { get; }
		string UserAgent { get; }
		string UserHostAddress { get; }
		string UserHostName { get; }
		string[] UserLanguages { get; }
	}

    public class HttpRequestProxy : IHttpRequest
    {
        private readonly HttpRequest _httpRequest;

        public HttpRequestProxy(HttpRequest httpRequest)
        {
            _httpRequest = httpRequest;
        }

        public string[] AcceptTypes
        {
            get { return _httpRequest.AcceptTypes; }
        }

        public string AnonymousID
        {
            get { return _httpRequest.AnonymousID; }
        }

        public string ApplicationPath
        {
            get { return _httpRequest.ApplicationPath; }
        }

        public string AppRelativeCurrentExecutionFilePath
        {
            get { return _httpRequest.AppRelativeCurrentExecutionFilePath; }
        }

        public HttpBrowserCapabilities Browser
        {
            get { return _httpRequest.Browser; }
            set { _httpRequest.Browser = value; }
        }

        public IHttpClientCertificate ClientCertificate
        {
            get { return new HttpClientCertificateProxy(_httpRequest.ClientCertificate); }
        }

        public Encoding ContentEncoding
        {
            get { return _httpRequest.ContentEncoding; }
            set { _httpRequest.ContentEncoding = value; }
        }

        public int ContentLength
        {
            get { return _httpRequest.ContentLength; }
        }

        public string ContentType
        {
            get { return _httpRequest.ContentType; }
            set { _httpRequest.ContentType = value; }
        }

        public HttpCookieCollection Cookies
        {
            get { return _httpRequest.Cookies; }
        }

        public string CurrentExecutionFilePath
        {
            get { return _httpRequest.CurrentExecutionFilePath; }
        }

        public string FilePath
        {
            get { return _httpRequest.FilePath; }
        }

        public IHttpFileCollection Files
        {
            get { return new HttpFileCollectionProxy(_httpRequest.Files); }
        }

        public Stream Filter
        {
            get { return _httpRequest.Filter; }
            set { _httpRequest.Filter = value; }
        }

        public NameValueCollection Form
        {
            get { return _httpRequest.Form; }
        }

        public NameValueCollection Headers
        {
            get { return _httpRequest.Headers; }
        }

        public string HttpMethod
        {
            get { return _httpRequest.HttpMethod; }
        }

        public Stream InputStream
        {
            get { return _httpRequest.InputStream; }
        }

        public bool IsAuthenticated
        {
            get { return _httpRequest.IsAuthenticated; }
        }

        public bool IsLocal
        {
            get { return _httpRequest.IsLocal; }
        }

        public bool IsSecureConnection
        {
            get { return _httpRequest.IsSecureConnection; }
        }

        public string this[string key]
        {
            get { return _httpRequest[key]; }
        }

        public NameValueCollection Params
        {
            get { return _httpRequest.Params; }
        }

        public string Path
        {
            get { return _httpRequest.Path; }
        }

        public string PathInfo
        {
            get { return _httpRequest.PathInfo; }
        }

        public string PhysicalApplicationPath
        {
            get { return _httpRequest.PhysicalApplicationPath; }
        }

        public string PhysicalPath
        {
            get { return _httpRequest.PhysicalPath; }
        }

        public NameValueCollection QueryString
        {
            get { return _httpRequest.QueryString; }
        }

        public string RawUrl
        {
            get { return _httpRequest.RawUrl; }
        }

        public string RequestType
        {
            get { return _httpRequest.RequestType; }
            set { _httpRequest.RequestType = value; }
        }

        public NameValueCollection ServerVariables
        {
            get { return _httpRequest.ServerVariables; }
        }

        public int TotalBytes
        {
            get { return _httpRequest.TotalBytes; }
        }

        public Uri Url
        {
            get { return _httpRequest.Url; }
        }

        public Uri UrlReferrer
        {
            get { return _httpRequest.UrlReferrer; }
        }

        public string UserAgent
        {
            get { return _httpRequest.UserAgent; }
        }

        public string UserHostAddress
        {
            get { return _httpRequest.UserHostAddress; }
        }

        public string UserHostName
        {
            get { return _httpRequest.UserHostName; }
        }

        public string[] UserLanguages
        {
            get { return _httpRequest.UserLanguages; }
        }

        public byte[] BinaryRead(int count)
        {
            return _httpRequest.BinaryRead(count);
        }

        public int[] MapImageCoordinates(string imageFieldName)
        {
            return _httpRequest.MapImageCoordinates(imageFieldName);
        }

        public string MapPath(string virtualPath)
        {
            return _httpRequest.MapPath(virtualPath);
        }

        public string MapPath(string virtualPath, string baseVirtualDir, bool allowCrossAppMapping)
        {
            return _httpRequest.MapPath(virtualPath, baseVirtualDir, allowCrossAppMapping);
        }

        public void SaveAs(string filename, bool includeHeaders)
        {
            _httpRequest.SaveAs(filename, includeHeaders);
        }

        public void ValidateInput()
        {
            _httpRequest.ValidateInput();
        }
    }
}
