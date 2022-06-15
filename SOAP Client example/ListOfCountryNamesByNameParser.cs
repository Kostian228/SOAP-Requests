using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace SOAP_Client_example
{
    public class ListOfCountryNamesByNameParser
    {
        public IEnumerable<Country> ParseResponse(string xmlResponse)
        {
            XDocument doc = XDocument.Parse(xmlResponse);
            XNamespace ns = "http://www.oorsprong.org/websamples.countryinfo";
            IEnumerable<XElement> responses = doc.Descendants(ns + "ListOfCountryNamesByNameResult").Elements();
            IEnumerable<Country> countries = responses.Select(el => GetCountry(el, ns));

            return countries;
        }

        private Country GetCountry(XElement xElement, XNamespace ns)
        {
            var loginResponse = new Country
            {
                ISOCode = xElement.Element(ns + "sISOCode")?.Value,
                Name = xElement.Element(ns + "sName")?.Value
            };

            return loginResponse;
    }
        }

    public class Country
    {
        public string ISOCode { get; set; }
        public string Name { get; set; }
    }
}
