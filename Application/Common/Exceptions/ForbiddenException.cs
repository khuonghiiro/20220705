using System.Net;

namespace Application.Common.Exceptions;

internal class ForbiddenException:CustomException
{
    public ForbiddenException(string message)
        : base(message, null, HttpStatusCode.Forbidden)
    {
    }
}
