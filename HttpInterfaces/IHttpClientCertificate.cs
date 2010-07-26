using System;
using System.Web;

namespace HttpInterfaces
{
	public interface IHttpClientCertificate
	{
		string Get(string field);

		// Properties
		byte[] BinaryIssuer { get; }
		int CertEncoding { get; }
		byte[] Certificate { get; }
		string Cookie { get; }
		int Flags { get; }
		bool IsPresent { get; }
		string Issuer { get; }
		bool IsValid { get; }
		int KeySize { get; }
		byte[] PublicKey { get; }
		int SecretKeySize { get; }
		string SerialNumber { get; }
		string ServerIssuer { get; }
		string ServerSubject { get; }
		string Subject { get; }
		DateTime ValidFrom { get; }
		DateTime ValidUntil { get; }
	}

    public class HttpClientCertificateProxy : IHttpClientCertificate
    {
        private readonly HttpClientCertificate _httpClientCertificate;

        public HttpClientCertificateProxy(HttpClientCertificate httpClientCertificate)
        {
            _httpClientCertificate = httpClientCertificate;
        }

        public byte[] BinaryIssuer
        {
            get { return _httpClientCertificate.BinaryIssuer; }
        }

        public int CertEncoding
        {
            get { return _httpClientCertificate.CertEncoding; }
        }

        public byte[] Certificate
        {
            get { return _httpClientCertificate.Certificate; }
        }

        public string Cookie
        {
            get { return _httpClientCertificate.Cookie; }
        }

        public int Flags
        {
            get { return _httpClientCertificate.Flags; }
        }

        public bool IsPresent
        {
            get { return _httpClientCertificate.IsPresent; }
        }

        public string Issuer
        {
            get { return _httpClientCertificate.Issuer; }
        }

        public bool IsValid
        {
            get { return _httpClientCertificate.IsValid; }
        }

        public int KeySize
        {
            get { return _httpClientCertificate.KeySize; }
        }

        public byte[] PublicKey
        {
            get { return _httpClientCertificate.PublicKey; }
        }

        public int SecretKeySize
        {
            get { return _httpClientCertificate.SecretKeySize; }
        }

        public string SerialNumber
        {
            get { return _httpClientCertificate.SerialNumber; }
        }

        public string ServerIssuer
        {
            get { return _httpClientCertificate.ServerIssuer; }
        }

        public string ServerSubject
        {
            get { return _httpClientCertificate.ServerSubject; }
        }

        public string Subject
        {
            get { return _httpClientCertificate.Subject; }
        }

        public DateTime ValidFrom
        {
            get { return _httpClientCertificate.ValidFrom; }
        }

        public DateTime ValidUntil
        {
            get { return _httpClientCertificate.ValidUntil; }
        }

        public string Get(string field)
        {
            return _httpClientCertificate.Get(field);
        }
    }
}
