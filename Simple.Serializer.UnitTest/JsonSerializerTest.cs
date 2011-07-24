using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simple.Serializer.UnitTest
{
    [TestClass]
    public class JsonSerializerTest
    {
        private IJsonSerializer _serializer;

        [TestInitialize]
        public void SetUp()
        {
            _serializer = new JsonSerializer();
        }

        [TestMethod]
        public void ShouldDeserializeAJson()
        {
            const string json = "{\"myProperty\":\"a-value\"}";

            var deserializedObject = _serializer.FromJson<DummyXmlAndJsonSerializableClass>(json);

            Assert.AreEqual("a-value", deserializedObject.MyProperty);
        }

        [TestMethod]
        public void ShouldSerializeAJson()
        {
            var objectToBeSerialized = new DummyXmlAndJsonSerializableClass { MyProperty = "my-value" };

            var json = _serializer.ToJson(objectToBeSerialized);

            Assert.AreEqual("{\"myProperty\":\"my-value\"}", json);
        }
    }
}
