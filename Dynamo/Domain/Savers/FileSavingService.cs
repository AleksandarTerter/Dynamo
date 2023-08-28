using Dynamo.Controllers;
using FluentResults;

namespace Dynamo.Domain.Savers
{
    public class FileSavingService : IFileSavingService
    {
        private readonly string _basePath;
        private readonly ILogger<FileSavingService> _logger;

        public FileSavingService(IConfiguration configuration, ILogger<FileSavingService> logger)
        {
            string? storageDirectory = configuration.GetValue<string>("StorageDirectory");
            if (string.IsNullOrEmpty(storageDirectory) || !Directory.Exists(storageDirectory))
                throw new Exception("Invalid configuration: 'StorageDir'");

            _basePath = storageDirectory;
        }

        public Result Save(string fileName, string extension, string content)
        {
            if (IsInvalidFileName(fileName))
                return Result.Fail("Invalid file name for data store.");

            var path = Path.Combine(_basePath, $"{fileName}.{extension}");
            if (File.Exists(path))
                return Result.Fail("File is already present.");

            try
            {
                File.WriteAllText(path, content);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        private static bool IsInvalidFileName(string fileName) => fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0;
    }
}