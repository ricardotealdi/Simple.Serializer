using System.Text;
using System.Xml.Serialization;

namespace Simple.Serializer.Wrappers
{
    internal interface IXmlSerializerWrapper
    {
        string Serialize(object objectToBeSerialized, Encoding encoding, XmlSerializerNamespaces namespaces);
        T Deserialize<T>(string xml, Encoding encoding);
    }
}