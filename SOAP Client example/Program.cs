using System;

namespace SOAP_Client_example
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceUrl = "http://webservices.oorsprong.org/websamples.countryinfo/CountryInfoService.wso";
            var soapActionUrl = "http://www.oorsprong.org/websamples.countryinfo";

            var client = new ListOfCountryNamesByNameClient(serviceUrl, soapActionUrl);
            string result = client.SendCountriesSoapRequest();

            var parser = new ListOfCountryNamesByNameParser();
            var countries = parser.ParseResponse(result);
            foreach (var country in countries)
            {
                Console.WriteLine($"{country.ISOCode} {country.Name}");
            }
        }
    }
}
