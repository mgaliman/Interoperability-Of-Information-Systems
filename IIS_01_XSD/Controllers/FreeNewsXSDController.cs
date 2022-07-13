using IIS_0102_XSD_RNG.Models;
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
    public class FreeNewsXSDController : ControllerBase
    {
        [HttpPost]
        public string Post([FromBody] FreeNewsModel freeNewsModel)
        {            
            string xml;

            //Gets from view model, Serialize it in XML format
            XmlSerializer xmlSerializer = new XmlSerializer(freeNewsModel.GetType());

            using (StringWriter textWriter = new Utf8StringWriter())
            {
                xmlSerializer.Serialize(textWriter, freeNewsModel);
                xml = textWriter.ToString();
            }
            //Creates schema file for xml/xsd
            string path = Path.GetFullPath("Schemas");
            XmlSchemaSet schema = new XmlSchemaSet();
            schema.Add("", path + "\\FreeNews.xsd");
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);
            xmlDocument.Save(path + "\\FreeNews.xml");
            XmlReader rd = XmlReader.Create(path + "\\FreeNews.xml");
            XDocument doc = XDocument.Load(rd);
            //File gets validated
            try
            {
                doc.Validate(schema, ValidationEventHandler);
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
