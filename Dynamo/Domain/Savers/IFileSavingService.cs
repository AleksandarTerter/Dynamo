using FluentResults;

namespace Dynamo.Domain.Savers
{
    public interface IFileSavingService
    {
        Result Save(string fileName, string extension, string content);
    }
}