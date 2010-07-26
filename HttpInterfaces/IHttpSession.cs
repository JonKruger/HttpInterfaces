using System;
using System.Collections;
using System.Collections.Specialized;
using System.Web;
using System.Web.SessionState;

namespace HttpInterfaces
{
	public interface IHttpSession : ICollection
	{
		object this[string key] { get; set; }

		string SessionID { get; }

		int Timeout { get; set; }

		bool IsNewSession { get; }

		SessionStateMode Mode { get; }

		bool IsCookieless { get; }

		HttpCookieMode CookieMode { get; }

		int LCID { get; set; }

		int CodePage { get; set;}

		IHttpSession Contents { get; }

		HttpStaticObjectsCollection StaticObjects { get; }

		NameObjectCollectionBase.KeysCollection Keys { get; }

		bool IsReadOnly { get; }

		void Abandon();

		void Add(string name, object value);

		void Remove(string name);

		void RemoveAt(int index);

		void Clear();

		void RemoveAll();
	}

    public class HttpSessionProxy : IHttpSession
    {
        private readonly HttpSessionState _httpSession;

        public HttpSessionProxy(HttpSessionState httpSession)
        {
            _httpSession = httpSession;
        }

        public int Count
        {
            get { return _httpSession.Count; }
        }

        public object SyncRoot
        {
            get { return _httpSession.SyncRoot; }
        }

        public bool IsSynchronized
        {
            get { return _httpSession.IsSynchronized; }
        }

        public object this[string key]
        {
            get { return _httpSession[key]; }
            set { _httpSession[key] = value; }
        }

        public string SessionID
        {
            get { return _httpSession.SessionID; }
        }

        public int Timeout
        {
            get { return _httpSession.Timeout; }
            set { _httpSession.Timeout = value; }
        }

        public bool IsNewSession
        {
            get { return _httpSession.IsNewSession; }
        }

        public SessionStateMode Mode
        {
            get { return _httpSession.Mode; }
        }

        public bool IsCookieless
        {
            get { return _httpSession.IsCookieless; }
        }

        public HttpCookieMode CookieMode
        {
            get { return _httpSession.CookieMode; }
        }

        public int LCID
        {
            get { return _httpSession.LCID; }
            set { _httpSession.LCID = value; }
        }

        public int CodePage
        {
            get { return _httpSession.CodePage; }
            set { _httpSession.CodePage = value; }
        }

        public IHttpSession Contents
        {
            get { return new HttpSessionProxy( _httpSession.Contents);} 
        }

        public HttpStaticObjectsCollection StaticObjects
        {
            get { return _httpSession.StaticObjects; }
        }

        public NameObjectCollectionBase.KeysCollection Keys
        {
            get { return _httpSession.Keys; }
        }

        public bool IsReadOnly
        {
            get { return _httpSession.IsReadOnly; }
        }

        public IEnumerator GetEnumerator()
        {
            return _httpSession.GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            _httpSession.CopyTo(array, index);
        }

        public void Abandon()
        {
            _httpSession.Abandon();
        }

        public void Add(string name, object value)
        {
            _httpSession.Add(name, value);
        }

        public void Remove(string name)
        {
            _httpSession.Remove(name);
        }

        public void RemoveAt(int index)
        {
            _httpSession.RemoveAt(index);
        }

        public void Clear()
        {
            _httpSession.Clear();
        }

        public void RemoveAll()
        {
            _httpSession.RemoveAll();
        }
    }
}
