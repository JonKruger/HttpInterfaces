using System;
using System.Web;

namespace HttpInterfaces
{
	public interface IHttpModuleCollection
	{
		IHttpModule Get(int index);
		IHttpModule Get(string name);
		string GetKey(int index);

		// Properties
		string[] AllKeys { get; }
		IHttpModule this[string name] { get; }
		IHttpModule this[int index] { get; }
	}

    public class HttpModuleCollectionProxy : IHttpModuleCollection
    {
        private readonly HttpModuleCollection _httpModuleCollection;

        public HttpModuleCollectionProxy(HttpModuleCollection httpModuleCollection)
        {
            _httpModuleCollection = httpModuleCollection;
        }

        public string[] AllKeys
        {
            get { return _httpModuleCollection.AllKeys; }
        }

        IHttpModule IHttpModuleCollection.this[string name]
        {
            get { return _httpModuleCollection[name]; }
        }

        IHttpModule IHttpModuleCollection.this[int index]
        {
            get { return _httpModuleCollection[index]; }
        }

        public IHttpModule Get(int index)
        {
            return _httpModuleCollection.Get(index);
        }

        public IHttpModule Get(string name)
        {
            return _httpModuleCollection.Get(name);
        }

        public string GetKey(int index)
        {
            return _httpModuleCollection.GetKey(index);
        }
    }
}
