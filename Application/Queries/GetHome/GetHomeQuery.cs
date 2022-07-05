using Application.Common.Caching;
using Application.Services;
using Application.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetHome;

public class GetHomeQuery : IRequest<HomeResponse>
{

}

// *****
// Lớp check validation của object model request
// *****

//public class GetHomeQueryValidator : CustomValidator<GetHomeQuery>
//{
//    public GetHomeQueryValidator(IReadRepository<Brand> repository, IStringLocalizer<GetHomeQueryValidator> localizer) =>
//        RuleFor(p => p.Name)
//            .NotEmpty()
//            .MaximumLength(75)
//            .MustAsync(async (name, ct) => await repository.GetBySpecAsync(new BrandByNameSpec(name), ct) is null)
//                .WithMessage((_, name) => string.Format(localizer["brand.alreadyexists"], name));
//}

public class GetHomeQueryHandler : IRequestHandler<GetHomeQuery, HomeResponse>
{
    private readonly ICacheService _cacheService;
    private readonly IHomeService _homeService;

    public GetHomeQueryHandler(
        IHomeService homeService,
        ICacheService cacheService)
    {
        _homeService = homeService;
        _cacheService = cacheService;
    }

    public async Task<HomeResponse> Handle(GetHomeQuery request, CancellationToken cancellationToken)
    {
        // Code implement to user service business here
        await _cacheService.SetAsync<string>("test", "demo");

        throw new NotImplementedException();
    }
}
