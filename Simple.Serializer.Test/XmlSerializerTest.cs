using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simple.Serializer.UnitTest
{
    [TestClass]
    public class XmlSerializerTest
    {
        private IXmlSerializer _serializer;

        [TestInitialize]
        public void SetUp()
        {
            _serializer = new XmlSerializer();
        }

        [TestMethod]
        public void ShouldDeserializeAnXml()
        {
            const string xml = @"<dummy-class><my-property>any</my-property></dummy-class>";

            var deserializedObject = _serializer.FromXml<DummyXmlAndJsonSerializableClass>(xml);

            Assert.AreEqual("any", deserializedObject.MyProperty);
        }

        [TestMethod]
        public void ShouldSerializeAnXml()
        {
            var objectToBeSerialized = new DummyXmlAndJsonSerializableClass { MyProperty = "my-value" };

            var xml = _serializer.ToXml(objectToBeSerialized);

            Assert.AreEqual("<?xml version=\"1.0\"?>\r\n<dummy-class>\r\n  <my-property>my-value</my-property>\r\n</dummy-class>", xml);
        }
    }
}
