using Microsoft.AspNetCore.Mvc;
using System.Net;
using UL.TestTest.Services;
using UL.TestTest.Services.Factorial;
using UL.TestTest.Services.FizzBuzz;

namespace UL.TechTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechTestController : ControllerBase
    {
        IServiceFactory _serviceFactory;

        public TechTestController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        [HttpGet]
        [Route("Factorial/{value:int:min(1):max(10000)}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFactorial(int value)
        {
            try
            {
                var service = _serviceFactory.GetFactorialService();

                var result = await service.CalculateAsync(new CalculateFactorialRequest(value));

                if (result.IsFailed)
                {
                    return BadRequest(result.Errors.FirstOrDefault()?.Message);
                }

                return Ok(result.Value.ToString());
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("FizzBuzz")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFizzBuzz()
        {
            try
            {
                var service = _serviceFactory.GetFizzBuzzService();

                var result = await service.CalculateAsync(new FizzBuzzRequest(1, 100));

                if (result.IsFailed)
                {
                    return BadRequest(result.Errors.FirstOrDefault()?.Message);
                }

                return Ok(string.Join(Environment.NewLine, result.Value));
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
