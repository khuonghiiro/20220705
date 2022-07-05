using System.Net;

namespace Application.Common.Exceptions;

internal class ConflictException: CustomException
{
    public ConflictException(string message)
        : base(message, null, HttpStatusCode.Conflict)
    {
    }
}
