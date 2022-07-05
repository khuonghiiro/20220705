using System.Net;

namespace Application.Common.Exceptions;

internal class NotFoundException:CustomException
{
    public NotFoundException(string message)
        : base(message, null, HttpStatusCode.NotFound)
    {
    }
}
