using FluentResults;
using Newtonsoft.Json;
using System.Xml;

namespace Dynamo.Domain.Converters
{
    public class XmlToJasonStringConverter : Converter<XmlDocument, string>, IXmlToJasonStringConverter
    {
        private readonly Newtonsoft.Json.Formatting _formatting = Newtonsoft.Json.Formatting.Indented;
        private readonly bool _omitRootObject = true;

        public override Result<string> Convert(XmlDocument source)
        {
            try
            {
                string convertedValue = JsonConvert.SerializeXmlNode(source, _formatting, _omitRootObject);
                return Result.Ok(convertedValue);
            }
            catch (Exception ex)
            {
                return Result.Fail(new[] { "Convertion to JSON failed.", ex.Message });
            }
        }
    }
}