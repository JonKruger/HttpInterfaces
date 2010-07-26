using System;
using System.Web;

namespace HttpInterfaces
{
	public interface IHttpApplicationState
	{
		void Add(string name, object value);
		void Clear();
		object Get(int index);
		object Get(string name);
		string GetKey(int index);
		void Lock();
		void Remove(string name);
		void RemoveAll();
		void RemoveAt(int index);
		void Set(string name, object value);
		void UnLock();

		// Properties
		int Count { get; }
		string[] AllKeys { get; }
		IHttpApplicationState Contents { get; }
		object this[int index] { get; }
		object this[string name] { get; set; }
		HttpStaticObjectsCollection StaticObjects { get; }
	}

    public class HttpApplicationStateProxy : IHttpApplicationState
    {
        private readonly HttpApplicationState _httpApplicationState;
        private readonly IHttpApplicationState _contents;

        public HttpApplicationStateProxy(HttpApplicationState httpApplicationState)
        {
            _httpApplicationState = httpApplicationState;
        }

        public int Count
        {
            get { return _httpApplicationState.Count; }
        }

        public string[] AllKeys
        {
            get { return _httpApplicationState.AllKeys; }
        }

        public IHttpApplicationState Contents
        {
            get { return new HttpApplicationStateProxy(_httpApplicationState.Contents); }
        }

        object IHttpApplicationState.this[int index]
        {
            get { return _httpApplicationState[index]; }
        }

        object IHttpApplicationState.this[string name]
        {
            get { return _httpApplicationState[name]; }
            set { _httpApplicationState[name] = value; }
        }

        public HttpStaticObjectsCollection StaticObjects
        {
            get { return _httpApplicationState.StaticObjects; }
        }

        public void Add(string name, object value)
        {
            _httpApplicationState.Add(name, value);
        }

        public void Clear()
        {
            _httpApplicationState.Clear();
        }

        public object Get(int index)
        {
            return _httpApplicationState.Get(index);
        }

        public object Get(string name)
        {
            return _httpApplicationState.Get(name);
        }

        public string GetKey(int index)
        {
            return _httpApplicationState.GetKey(index);
        }

        public void Lock()
        {
            _httpApplicationState.Lock();
        }

        public void Remove(string name)
        {
            _httpApplicationState.Remove(name);
        }

        public void RemoveAll()
        {
            _httpApplicationState.RemoveAll();
        }

        public void RemoveAt(int index)
        {
            _httpApplicationState.RemoveAt(index);
        }

        public void Set(string name, object value)
        {
            _httpApplicationState.Set(name, value);
        }

        public void UnLock()
        {
            _httpApplicationState.UnLock();
        }
    }
}
