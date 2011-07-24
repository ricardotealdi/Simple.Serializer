using System.Text;

namespace Simple.Serializer.Wrappers
{
    internal interface IJsonSerializerWrapper
    {
        string ToJson(object objectToBeSerialized, Encoding encoding);
        T FromJson<T>(string json, Encoding encoding);
    }
}