using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    public class VersionedApiController : BaseApiController
    {
    }
}
