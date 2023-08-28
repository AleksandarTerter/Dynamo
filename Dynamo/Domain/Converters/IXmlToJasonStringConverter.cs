using FluentResults;
using System.Xml;

namespace Dynamo.Domain.Converters
{
    public interface IXmlToJasonStringConverter
    {
        Result<string> Convert(XmlDocument source);
    }
}