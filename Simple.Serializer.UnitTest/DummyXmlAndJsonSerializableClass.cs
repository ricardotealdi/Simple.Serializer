using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Simple.Serializer.UnitTest
{
    [XmlRoot(ElementName = "dummy-class")]
    [DataContract]
    public class DummyXmlAndJsonSerializableClass
    {
        [XmlElement("my-property")]
        [DataMember(Name = "myProperty")]
        public string MyProperty { get; set; }
    }
}
