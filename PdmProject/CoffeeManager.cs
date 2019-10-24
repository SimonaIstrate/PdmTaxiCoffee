using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace PdmProject
{
    public class CoffeeManager
    {
        private HttpClient httpClient;

        private Stream stream;


        public CoffeeManager()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<CoffeShops>> getCoffeShops()
        {
            List<CoffeShops> listCoffeShops = new List<CoffeShops>();
            try
            {
                stream = await httpClient.GetStreamAsync("https://raw.githubusercontent.com/SimonaIstrate/PdmTaxiCoffee/master/PdmProject/coffeeShops.xml");
                listCoffeShops = parseXml(stream);
            }
            catch (OperationCanceledException)
            { }
            return listCoffeShops;

        }

        private List<CoffeShops> parseXml(Stream stream)
        {
            List<CoffeShops> listCoffeShops = new List<CoffeShops>();
            XmlDocument xml = new XmlDocument();

            xml.Load(stream);

            foreach (XmlNode node in xml.DocumentElement.ChildNodes)
            {
                CoffeShops coffeShops = new CoffeShops();
                coffeShops.Cod = node.ChildNodes[0].InnerText;
                coffeShops.Nume = node.ChildNodes[1].InnerText;
                coffeShops.Oras = node.ChildNodes[2].InnerText;
                coffeShops.Adresa = node.ChildNodes[3].InnerText;
                coffeShops.Program = node.ChildNodes[4].InnerText;
                listCoffeShops.Add(coffeShops);
            }
            return listCoffeShops;
        }

    }
}
