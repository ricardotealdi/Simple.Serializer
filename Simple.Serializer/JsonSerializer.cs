using System.Text;
using Simple.Serializer.Wrappers;

namespace Simple.Serializer
{
    public class JsonSerializer : IJsonSerializer
    {
        private readonly IJsonSerializerWrapper _serializer;

        public JsonSerializer()
            : this(new JsonSerializerWrapper())
        {
        }

        private JsonSerializer(IJsonSerializerWrapper serializer)
        {
            _serializer = serializer;
        }

        public string ToJson(object objectToBeSerialized)
        {
            return _serializer.ToJson(objectToBeSerialized, Encoding.UTF8);
        }

        public string ToJson(object objectToBeSerialized, Encoding encoding)
        {
            return _serializer.ToJson(objectToBeSerialized, encoding);
        }

        public T FromJson<T>(string json)
        {
            return _serializer.FromJson<T>(json, Encoding.UTF8);
        }

        public T FromJson<T>(string json, Encoding encoding)
        {
            return _serializer.FromJson<T>(json, encoding);
        }
    }
}
