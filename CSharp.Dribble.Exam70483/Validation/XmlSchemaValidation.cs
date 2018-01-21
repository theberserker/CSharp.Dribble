using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace CSharp.Dribble.Exam70483.Validation
{
    public class XmlSchemaValidation
    {
        // won't work in .NET Core app
        //public void ValidateXML()
        //{
        //    string xsdPath ="person.xsd";
        //    string xmlPath ="person.xml";

        //    XmlReader reader = XmlReader.Create(xmlPath);
        //    XDocument document = new XmlDocument();
        //    document.Schemas.Add("", xsdPath);
        //    document.Load(reader);
        //    ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventHandler);
        //    document.Validate(eventHandler);
        //}

        //static void ValidationEventHandler(object sender, ValidationEventArgs e)
        //{
        //    switch (e.Severity)
        //    {
        //        case XmlSeverityType.Error:
        //            Console.WriteLine("Error:{0}", e.Message);
        //            break;
        //        case XmlSeverityType.Warning:
        //            Console.WriteLine("Warning{0}", e.Message);
        //            break;
        //    }
        //}
    }
}
