using FluentResults;
using System.Xml;

namespace Dynamo.Domain.Readers
{
    public interface IXmlReader
    {
        Result<XmlDocument> Read(IFormFile file);
    }
}