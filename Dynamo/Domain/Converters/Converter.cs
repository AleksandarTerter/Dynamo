using FluentResults;

namespace Dynamo.Domain.Converters
{
    public abstract class Converter<SourceType, TargetType>
    {
        public abstract Result<TargetType> Convert(SourceType source);
    }
}