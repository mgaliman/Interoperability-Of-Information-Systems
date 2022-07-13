using Commons.Xml.Relaxng;
using IIS_0102_XSD_RNG.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace IIS_0102_XSD_RNG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreeNewsRNGController : ControllerBase
    {
        [HttpPost]
        public string Post([FromBody] FreeNewsModel freeNewsModel)
        {
            string xml;

            XmlSerializer xmlSerializer = new XmlSerializer(freeNewsModel.GetType());

            using (StringWriter textWriter = new Utf8StringWriter())
            {
                xmlSerializer.Serialize(textWriter, freeNewsModel);
                xml = textWriter.ToString();
            }

            try
            {
                string path = Path.GetFullPath("Schemas");
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xml);
                xmlDocument.Save(path + "\\FreeNews.xml");

                XmlReader xmlReaderXML = XmlReader.Create(path + "\\FreeNews.xml");
                XmlReader xmlReaderRNG = new XmlTextReader(path + "\\FreeNews.rng");
                
                XmlReader rd = new RelaxngValidatingReader(xmlReaderXML, xmlReaderRNG);
                XDocument doc = XDocument.Load(rd);
            }
            catch (Exception e)
            {
                return $"XML is not valid\nERROR: {e.Message}";
            }

            return xml;
        }

        public class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }

        static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            XmlSeverityType type = XmlSeverityType.Warning;
            if (Enum.TryParse<XmlSeverityType>("Error", out type))
            {
                if (type == XmlSeverityType.Error) throw new Exception(e.Message);
            }
        }
    }
}
