namespace SolutionTemplateGenerator.Core.Utils
{
    using System.IO;
    using System.Xml.Serialization;
    using System.Xml;

    public static class Serializer
    {
        public static string Serialize<T>(T type)
        {
            var serializer = new XmlSerializer(type.GetType());
            using (var stream = new MemoryStream())
            {
                serializer.Serialize(stream, type);
                stream.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static T Deserialize<T>(string xml)
        {
            using (var input = new StringReader(xml))
            {
                using (var xmlReader = new XmlTextReader(input))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    return (T)serializer.Deserialize(xmlReader);
                }
            }
        }
    }
}