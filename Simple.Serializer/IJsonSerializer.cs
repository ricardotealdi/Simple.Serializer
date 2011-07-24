using System.Text;

namespace Simple.Serializer
{
    public interface IJsonSerializer
    {
        string ToJson(object objectToBeSerialized);
        string ToJson(object objectToBeSerialized, Encoding encoding);
        T FromJson<T>(string json);
        T FromJson<T>(string json, Encoding encoding);
    }
}