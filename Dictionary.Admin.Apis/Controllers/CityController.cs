using DictionaryMng.Business.Implementation;
using Microsoft.AspNetCore.Mvc;
using PostgreSQL_API.DB;
using SERP.Framework.ApiUtils.Controllers;
using SERP.Framework.ApiUtils.Responses;
using SERP.Framework.ApiUtils.Utils;

namespace Dictionary.Admin.Apis.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class CityController : ApiControllerBase
    {
        private readonly ICityRepository _cityRepository;
        public CityController(
            ICityRepository cityRepository,
            IHttpRequestHelper httpRequestHelper, 
            ILogger<ApiControllerBase> logger
            ) : base(httpRequestHelper, logger)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(ResponseObject<City>), StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> GetAllAsync()
        {
            return await ExecuteFunction(async () =>
            {
                var result = await _cityRepository.ListAllAsync();
                return result;
            });
        }
    }
}
