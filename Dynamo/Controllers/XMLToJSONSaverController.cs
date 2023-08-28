using Dynamo.Domain.Converters;
using Dynamo.Domain.Readers;
using Dynamo.Domain.Savers;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace Dynamo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class XMLToJSONSaverController : ControllerBase
    {
        private readonly IXmlReader _xmlReader;
        private readonly IXmlToJasonStringConverter _converter;
        private readonly IFileSavingService _fileSavingService;

        public XMLToJSONSaverController(IFileSavingService fileSavingService, IXmlReader xmlReader, IXmlToJasonStringConverter converter)
        {
            _xmlReader = xmlReader;
            _converter = converter;
            _fileSavingService = fileSavingService;
        }

        [HttpPost(Name = "Post")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(IFormFile file, [FromQuery] string? fileName)
        {
            Result<XmlDocument> readXmlResult = _xmlReader.Read(file);
            if (readXmlResult.IsFailed)
                return BadRequest(readXmlResult.Reasons);

            Result<string> convertResult = _converter.Convert(readXmlResult.Value);
            if (convertResult.IsFailed)
                return BadRequest(convertResult.Reasons);

            try
            {
                string saveFileName = fileName ?? Path.GetFileNameWithoutExtension(file.FileName);
                Result saveResult = _fileSavingService.Save(saveFileName, "json", convertResult.Value);
                if (saveResult.IsFailed)
                    return BadRequest(saveResult.Reasons);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            return Ok();
        }
    }
}