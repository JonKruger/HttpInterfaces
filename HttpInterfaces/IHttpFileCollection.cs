using System;
using System.Web;

namespace HttpInterfaces
{
	public interface IHttpFileCollection
	{
		HttpPostedFile Get(int index);
		HttpPostedFile Get(string name);
		string GetKey(int index);

		// Properties
		string[] AllKeys { get; }
		HttpPostedFile this[string name] { get; }
		HttpPostedFile this[int index] { get; }
	}

    public class HttpFileCollectionProxy : IHttpFileCollection
    {
        private readonly HttpFileCollection _httpFileCollection;

        public HttpFileCollectionProxy(HttpFileCollection httpFileCollection)
        {
            _httpFileCollection = httpFileCollection;
        }

        public string[] AllKeys
        {
            get { return _httpFileCollection.AllKeys; }
        }

        HttpPostedFile IHttpFileCollection.this[string name]
        {
            get { return _httpFileCollection[name]; }
        }

        HttpPostedFile IHttpFileCollection.this[int index]
        {
            get { return _httpFileCollection[index]; }
        }

        public HttpPostedFile Get(int index)
        {
            return _httpFileCollection.Get(index);
        }

        public HttpPostedFile Get(string name)
        {
            return _httpFileCollection.Get(name);
        }

        public string GetKey(int index)
        {
            return _httpFileCollection.GetKey(index);
        }
    }
}
