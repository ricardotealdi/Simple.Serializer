using System.Text;
using System.Xml.Serialization;

namespace Simple.Serializer
{
    public interface IXmlSerializer
    {
        string ToXml(object objectToBeSerialized);
        string ToXml(object objectToBeSerialized, Encoding encoding);
        string ToXml(object objectToBeSerialized, Encoding encoding, XmlSerializerNamespaces namespaces);
        T FromXml<T>(string xml);
        T FromXml<T>(string xml, Encoding encoding);
    }
}