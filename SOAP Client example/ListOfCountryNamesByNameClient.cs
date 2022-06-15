using System;
using System.Net;

namespace SOAP_Client_example
{
    public class ListOfCountryNamesByNameClient
    {
        private readonly string _serviceUrl;
        private readonly string _soapActionUrl;

        public ListOfCountryNamesByNameClient(string serviceUrl, string soapActionUrl)
        {
            if (string.IsNullOrEmpty(serviceUrl)) throw new ArgumentException("service url cannot be null or empty");
            if (string.IsNullOrEmpty(soapActionUrl)) throw new ArgumentException("soap action url cannot be null or empty");
            
            _serviceUrl = serviceUrl;
            _soapActionUrl = soapActionUrl;
        }

        public string SendCountriesSoapRequest()
        { 
            string payLoad = GetCountriesRequestPayload();

            string result;

            using (var client = new WebClient())
            {
                try
                {
                    client.Headers.Add("Content-Type", "text/xml; charset=utf-8");
                    result = client.UploadString(_serviceUrl, payLoad);
                }
                catch (Exception e)
                {
                    result = e.Message;
                }
            }

            return result;
        }
        
        private string GetCountriesRequestPayload()
        {
            var payload = @"<?xml version=""1.0"" encoding=""utf-8""?>" + "\n" +
                          @"<soap12:Envelope xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope"">" + "\n" +
                          @"  <soap12:Body>" + "\n" +
                          @$"    <ListOfCountryNamesByName xmlns=""{_soapActionUrl}"">" + "\n" +
                          @"    </ListOfCountryNamesByName>" + "\n" +
                          @"  </soap12:Body>" + "\n" +
                          @"</soap12:Envelope>";

            return payload;
        }
    }
}
