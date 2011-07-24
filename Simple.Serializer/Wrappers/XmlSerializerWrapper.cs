using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Simple.Serializer.Wrappers
{
    internal class XmlSerializerWrapper : IXmlSerializerWrapper
    {
        public string Serialize(object objectToBeSerialized, Encoding encoding, XmlSerializerNamespaces namespaces)
        {
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(objectToBeSerialized.GetType());

            using (var memoryStream = new MemoryStream())
            {
                xmlSerializer.Serialize(
                    memoryStream,
                    objectToBeSerialized,
                    namespaces);

                return encoding.GetString(memoryStream.ToArray());
            }
        }

        public T Deserialize<T>(string xml, Encoding encoding)
        {
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using (var memoryStream = new MemoryStream(encoding.GetBytes(xml)))
            {
                return (T)xmlSerializer.Deserialize(memoryStream);
            }
        }
    }
}