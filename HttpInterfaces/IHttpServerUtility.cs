using System;
using System.Collections.Specialized;
using System.IO;
using System.Web;

namespace HttpInterfaces
{
	public interface IHttpServerUtility
	{
		string MachineName {get;}

		int ScriptTimeout {get; set;}

		object CreateObject(string progID);

		object CreateObject(Type type);

		object CreateObjectFromClsid(string clsid);

		string MapPath(string path);

		Exception GetLastError();

		void ClearError();

		void Execute(string path);

		void Execute(string path, System.IO.TextWriter writer);

		void Execute(string path, bool preserveForm);

		void Execute(string path, System.IO.TextWriter writer, bool preserveForm);

		void Execute(System.Web.IHttpHandler handler, System.IO.TextWriter writer, bool preserveForm);

		void Transfer(string path, bool preserveForm);

		void Transfer(string path);

		void Transfer(System.Web.IHttpHandler handler, bool preserveForm);

		void TransferRequest(string path);

		void TransferRequest(string path, bool preserveForm);

		void TransferRequest(string path, bool preserveForm, string method, System.Collections.Specialized.NameValueCollection headers);

		string HtmlDecode(string s);

		void HtmlDecode(string s, System.IO.TextWriter output);

		string HtmlEncode(string s);

		void HtmlEncode(string s, System.IO.TextWriter output);

		string UrlEncode(string s);

		string UrlPathEncode(string s);

		void UrlEncode(string s, System.IO.TextWriter output);

		string UrlDecode(string s);

		void UrlDecode(string s, System.IO.TextWriter output);
	}

    public class HttpServerUtilityProxy : IHttpServerUtility
    {
        private readonly HttpServerUtility _httpServerUtility;

        public HttpServerUtilityProxy(HttpServerUtility httpServerUtility)
        {
            _httpServerUtility = httpServerUtility;
        }

        public string MachineName
        {
            get { return _httpServerUtility.MachineName; }
        }

        public int ScriptTimeout
        {
            get { return _httpServerUtility.ScriptTimeout; }
            set { _httpServerUtility.ScriptTimeout = value; }
        }

        public object CreateObject(string progID)
        {
            return _httpServerUtility.CreateObject(progID);
        }

        public object CreateObject(Type type)
        {
            return _httpServerUtility.CreateObject(type);
        }

        public object CreateObjectFromClsid(string clsid)
        {
            return _httpServerUtility.CreateObjectFromClsid(clsid);
        }

        public string MapPath(string path)
        {
            return _httpServerUtility.MapPath(path);
        }

        public Exception GetLastError()
        {
            return _httpServerUtility.GetLastError();
        }

        public void ClearError()
        {
            _httpServerUtility.ClearError();
        }

        public void Execute(string path)
        {
            _httpServerUtility.Execute(path);
        }

        public void Execute(string path, TextWriter writer)
        {
            _httpServerUtility.Execute(path, writer);
        }

        public void Execute(string path, bool preserveForm)
        {
            _httpServerUtility.Execute(path, preserveForm);
        }

        public void Execute(string path, TextWriter writer, bool preserveForm)
        {
            _httpServerUtility.Execute(path, writer, preserveForm);
        }

        public void Execute(IHttpHandler handler, TextWriter writer, bool preserveForm)
        {
            _httpServerUtility.Execute(handler, writer, preserveForm);
        }

        public void Transfer(string path, bool preserveForm)
        {
            _httpServerUtility.Transfer(path, preserveForm);
        }

        public void Transfer(string path)
        {
            _httpServerUtility.Transfer(path);
        }

        public void Transfer(IHttpHandler handler, bool preserveForm)
        {
            _httpServerUtility.Transfer(handler, preserveForm);
        }

        public void TransferRequest(string path)
        {
            _httpServerUtility.TransferRequest(path);
        }

        public void TransferRequest(string path, bool preserveForm)
        {
            _httpServerUtility.TransferRequest(path, preserveForm);
        }

        public void TransferRequest(string path, bool preserveForm, string method, NameValueCollection headers)
        {
            _httpServerUtility.TransferRequest(path, preserveForm, method, headers);
        }

        public string HtmlDecode(string s)
        {
            return _httpServerUtility.HtmlDecode(s);
        }

        public void HtmlDecode(string s, TextWriter output)
        {
            _httpServerUtility.HtmlDecode(s, output);
        }

        public string HtmlEncode(string s)
        {
            return _httpServerUtility.HtmlEncode(s);
        }

        public void HtmlEncode(string s, TextWriter output)
        {
            _httpServerUtility.HtmlEncode(s, output);
        }

        public string UrlEncode(string s)
        {
            return _httpServerUtility.UrlEncode(s);
        }

        public string UrlPathEncode(string s)
        {
            return _httpServerUtility.UrlPathEncode(s);
        }

        public void UrlEncode(string s, TextWriter output)
        {
            _httpServerUtility.UrlEncode(s, output);
        }

        public string UrlDecode(string s)
        {
            return _httpServerUtility.UrlDecode(s);
        }

        public void UrlDecode(string s, TextWriter output)
        {
            _httpServerUtility.UrlDecode(s, output);
        }
    }
}
