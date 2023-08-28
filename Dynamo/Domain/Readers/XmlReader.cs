using FluentResults;
using System.Xml;

namespace Dynamo.Domain.Readers
{
    public class XmlReader : BaseFileReader<XmlDocument>, IXmlReader
    {
        public override Result<XmlDocument> Read(IFormFile file)
        {
            if (FileExtensionIsInvalid(file))
                return Result.Fail("File has invalid extension");

            XmlDocument xmlDcoument = new();
            try
            {
                using var filestream = file.OpenReadStream();
                xmlDcoument.Load(filestream);
            }
            catch (Exception)
            {
                return Result.Fail("Can not open file as a valid xml.");
            }

            return Result.Ok(xmlDcoument);
        }

        protected override IEnumerable<string> GetSuportedExtentions()
        {
            return new[] { ".xml" };
        }
    }
}