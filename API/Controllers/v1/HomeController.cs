using Application.Queries.GetHome;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers.v1
{
    public class HomeController : VersionedApiController
    {
        public async Task<IActionResult> Index()
        {
            var result = await Mediator.Send(new GetHomeQuery());
            return Ok(result);
        }
    }
}
