using Newtonsoft.Json;
using System.Text;
using System.Xml.Serialization;

namespace IBERDROLA.TechnicalTest.ExternalServices
{
    /// <summary>
    /// Enum Format
    /// </summary>
    public enum SerializeFormat
    {
        /// <summary>
        /// Json
        /// </summary>
        Json = 1,
        /// <summary>
        /// XML
        /// </summary>
        Xml = 2
    }

    internal static class Converter
    {
        private static readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
       
        };
        internal static TResult ToEntity<TResult>(this Stream stream,
            SerializeFormat contentType)
        {
            return contentType == SerializeFormat.Json
                ? DeserializeFromJsonString<TResult>(stream)
                : DeserializeFromXmlString<TResult>(stream);
        }

        internal static TResult DeserializeFromJsonString<TResult>(Stream stream)
        {
            var serializer = new JsonSerializer();

            using var sr = new StreamReader(stream);
            using var jsonTextReader = new JsonTextReader(sr);
            return serializer.Deserialize<TResult>(jsonTextReader);
        }
        internal static TResult DeserializeFromJsonString<TResult>(this string textObject) =>
            JsonConvert.DeserializeObject<TResult>(textObject, _jsonSerializerSettings);

        internal static string SerializeToJsonString<T>(this T ObjectToSerialize) =>
            JsonConvert.SerializeObject(ObjectToSerialize, _jsonSerializerSettings);

        internal static string SerializeToXmlString<T>(this T ObjectToSerialize)
        {
            var xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());

            using var textWriter = new StringWriter();
            xmlSerializer.Serialize(textWriter, ObjectToSerialize);
            return textWriter.ToString();
        }

        internal static TResult DeserializeFromXmlString<TResult>(Stream xmlStream)
            => (TResult)new XmlSerializer(typeof(TResult)).Deserialize(xmlStream);

        internal static TResult DeserializeFromXmlString<TResult>(this string xmlObject)
        {
            var serializer = new XmlSerializer(typeof(TResult));
            var memStream = new MemoryStream(Encoding.UTF8.GetBytes(xmlObject));
            return (TResult)serializer.Deserialize(memStream);
        }
    }
}
