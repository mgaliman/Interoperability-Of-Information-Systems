using IIS_03_SOAP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace IIS_03_SOAP
{
    /// <summary>
    /// Summary description for SOAP
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SOAP : System.Web.Services.WebService
    {

        private List<FreeNewsModel> freeNewslist = new List<FreeNewsModel>
        {
            new FreeNewsModel
            {
                Title = "Elon Musk says that SpaceX is going to 'put a literal Dogecoin on the literal moon'",
                Author = "Grace Dean",
                PublishedDate = "2021-04-01 11:40:02",
                PublishedDatePrecision = "full",
                Link = "https://www.businessinsider.com/elon-musk-spacex-dogecoin-moon-crypto-cryptocurrencies-2021-4",
                CleanUrl = "businessinsider.com",
                Summary = "SpaceX CEO Elon Musk tweeted on Thursday that the aerospace company plans to put a literal Dogecoin on the literal moon.—Elon Musk (@elonmusk) April 1, 2021Musk is a vocal fan of the cryptocurrency, and has even bought some for his nine-month old son.He frequently tweets memes starring Shibu Inus, the doge dog breed that gives the cryptocurrency its icon and name. He has also said that he plans to buy a Shibu Inu.Read more: Elon Musk is pumping stocks, cryptocurrencies, and the energy of 49 ",
                Rights = "businessinsider.com",
                Rank = 110,
                Topic = "news",
                Country = "US",
                Language = "en",
                Authors = new List<string>
                {
                    "Grace Dean"
                },
                Media = "https://i.insider.com/6065ab84daf0f10018f9967b?width=1200&format=jpeg",
                IsOpinion = false,
                TwitterAccount = "null",
                Score = 24.82406,
                Id = "12f5504c4998440063afe3aef55b8209"
            },
            new FreeNewsModel
            {
                Title = "Elon Musk takes Texas city by surprise by tweeting he's going to donate $30 million to boost the area",
                Author = "Kate Duffy",
                PublishedDate = "2021-04-01 10:17:43",
                PublishedDatePrecision = "full",
                Link = "https://www.businessinsider.com/elon-musk-surprise-texas-brownsville-donation-revitalize-area-spacex-2021-4",
                CleanUrl = "businessinsider.com",
                Summary = "A Texas city was taken by surprised when Elon Musk tweeted on Tuesday that he would donate $30 million to revitalize it and its schools, after appealing for people to move there to work for SpaceX.He tweeted that he was donating $20 million to schools in Cameron County and $10 million to revitalize downtown Brownsville, home to one of the company's rocket production facilities and close to the launch site in Boca Chica, which Musk has said he wants to grow into a city called Starbase Musk added",
                Rights = "businessinsider.com",
                Rank = 110,
                Topic = "news",
                Country = "US",
                Language = "en",
                Authors = new List<string>
                {
                    "Kate Duffy"
                },
                Media = "https://i.insider.com/5fe4d819edf8920018093b41?width=1200&format=jpeg",
                IsOpinion = false,
                TwitterAccount = "@sai",
                Score = 22.544588,
                Id = "899741d008b00ad8d2ca0d04581fa334"
            }
        };

        [WebMethod]
        public string Search(string term)
        {
            XElement xmlDocument = new XElement("FreeNewsItems");
            foreach(FreeNewsModel item in freeNewslist)
            {
                xmlDocument.Add(
                    new XElement("FreeNews",
                    new XElement("Title", item.Title),
                    new XElement("Author", item.Author),
                    new XElement("PublishedDate", item.PublishedDate),
                    new XElement("PublishedDatePrecision", item.PublishedDatePrecision),
                    new XElement("Link", item.Link),
                    new XElement("CleanUrl", item.CleanUrl),
                    new XElement("Summary", item.Summary),
                    new XElement("Rights", item.Rights),
                    new XElement("Rank", item.Rank),
                    new XElement("Topic", item.Topic),
                    new XElement("Country", item.Country),
                    new XElement("Language", item.Language),
                    new XElement("Authors", item.Authors),
                    new XElement("Media", item.Media),
                    new XElement("IsOpinion", item.IsOpinion),
                    new XElement("TwitterAccount", item.TwitterAccount),
                    new XElement("Score", item.Score),
                    new XElement("Id", item.Id)));
            }
            string value = (string)xmlDocument.XPathSelectElement("FreeNews/Id[text()='" + term + "']/parent::FreeNews");

            string path = HttpContext.Current.Server.MapPath(@"~/Models");
            DirectoryInfo solutionPath = Directory.GetParent(path).Parent;
            string javaLocation = "/Java/IIS_04_JAXB/JAXB.xml";

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlDocument.ToString());
            xml.Save(solutionPath.FullName + javaLocation);

            return value;
        }
    }
}
