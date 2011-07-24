using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Simple.Serializer.Wrappers
{
    internal class JsonSerializerWrapper : IJsonSerializerWrapper
    {
        public string ToJson(object objectToBeSerialized, Encoding encoding)
        {
            var serializer = new DataContractJsonSerializer(objectToBeSerialized.GetType());

            using (var memoryStream = new MemoryStream())
            {
                serializer.WriteObject(memoryStream, objectToBeSerialized);
                memoryStream.Position = 0;
                using (var streamReader = new StreamReader(memoryStream, encoding))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        public T FromJson<T>(string json, Encoding encoding)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));

            using (var memoryStream = new MemoryStream(encoding.GetBytes(json)))
            {
                memoryStream.Position = 0;
                
                return (T) serializer.ReadObject(memoryStream);
            }
        }
    }
}
