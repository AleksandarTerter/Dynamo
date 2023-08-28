using FluentResults;

namespace Dynamo.Domain.Readers
{
    public abstract class BaseFileReader<T>
    {
        public abstract Result<T> Read(IFormFile file);
        protected abstract IEnumerable<string> GetSuportedExtentions();
        protected internal bool FileExtensionIsInvalid(IFormFile file)
        {
            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            return string.IsNullOrEmpty(ext) || !GetSuportedExtentions().Contains(ext);
        }
    }
}