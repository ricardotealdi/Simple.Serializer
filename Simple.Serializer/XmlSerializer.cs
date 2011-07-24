using System;
using System.Text;
using System.Xml.Serialization;
using Simple.Serializer.Wrappers;

namespace Simple.Serializer
{
    public class XmlSerializer : IXmlSerializer
    {
        private readonly IXmlSerializerWrapper _xmlSerializerWrapper;

        public XmlSerializer()
            : this(new XmlSerializerWrapper())
        {
        }

        private XmlSerializer(IXmlSerializerWrapper xmlSerializerWrapper)
        {
            _xmlSerializerWrapper = xmlSerializerWrapper;
        }

        public string ToXml(object objectToBeSerialized)
        {
            return ToXml(objectToBeSerialized, Encoding.UTF8);
        }

        public string ToXml(object objectToBeSerialized, Encoding encoding)
        {
            var xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(String.Empty, String.Empty);

            return _xmlSerializerWrapper.Serialize(objectToBeSerialized, encoding, xmlSerializerNamespaces);
        }

        public string ToXml(object objectToBeSerialized, Encoding encoding, XmlSerializerNamespaces namespaces)
        {
            return _xmlSerializerWrapper.Serialize(objectToBeSerialized, encoding, namespaces);
        }

        public T FromXml<T>(string xml)
        {
            return _xmlSerializerWrapper.Deserialize<T>(xml, Encoding.UTF8);
        }

        public T FromXml<T>(string xml, Encoding encoding)
        {
            return _xmlSerializerWrapper.Deserialize<T>(xml, encoding);
        }
    }
}
