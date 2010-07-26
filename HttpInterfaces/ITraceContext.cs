using System;
using System.Web;

namespace HttpInterfaces
{
    public interface ITraceContext
    {
        TraceMode TraceMode { get; set; }
        
        bool IsEnabled { get; set; }
        
        event TraceContextEventHandler TraceFinished;
        
        void Write(string message);
        
        void Write(string category, string message);
        
        void Write(string category, string message, Exception errorInfo);
        
        void Warn(string message);
        
        void Warn(string category, string message);
        
        void Warn(string category, string message, Exception errorInfo);
    }

    public class TraceContextProxy : ITraceContext
    {
        private readonly TraceContext _traceContext;

        public TraceContextProxy(TraceContext traceContext)
        {
            _traceContext = traceContext;
        }

        public TraceMode TraceMode
        {
            get { return _traceContext.TraceMode; }
            set { _traceContext.TraceMode = value; }
        }

        public bool IsEnabled
        {
            get { return _traceContext.IsEnabled; }
            set { _traceContext.IsEnabled = value; }
        }

        public event TraceContextEventHandler TraceFinished
        {
            add { _traceContext.TraceFinished += value; }
            remove { _traceContext.TraceFinished -= value; }
        }

        public void Write(string message)
        {
            _traceContext.Write(message);
        }

        public void Write(string category, string message)
        {
            _traceContext.Write(category, message);
        }

        public void Write(string category, string message, Exception errorInfo)
        {
            _traceContext.Write(category, message, errorInfo);
        }

        public void Warn(string message)
        {
            _traceContext.Warn(message);
        }

        public void Warn(string category, string message)
        {
            _traceContext.Warn(category, message);
        }

        public void Warn(string category, string message, Exception errorInfo)
        {
            _traceContext.Warn(category, message, errorInfo);
        }
    }
}
