using System.Collections.Generic;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sample.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly ISampleInfosRepository _repository;

        public SampleController(ISampleInfosRepository repository) => _repository = repository;

        [HttpPost]
        [Consumes("application/json")]        
        public IActionResult Post(SampleInfo sampleInfo)        
        {
            return sampleInfo != null 
                ? _repository
                    .Add(sampleInfo)
                    .Finally(result => result.IsSuccess // value added
                        ? StatusCode(200, "Ok") // return success code
                        : StatusCode(400, result.Error)) // value not added, return error code and message
                : StatusCode(400, "Provide json to process"); // no json input
        }

        [HttpGet]
        public IEnumerable<SampleInfo> Get(int? skip)
        {
            return _repository.GetRange(skip ?? 0);
        }
    }
}
