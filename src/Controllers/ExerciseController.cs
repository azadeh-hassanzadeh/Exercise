using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Exercise.Models;
using Exercise.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Exercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IConfigDetails _configDetails;

        public ExerciseController(IConfigDetails configDetails)
        {
            _configDetails = configDetails;
        }

        [HttpGet("user")]
        [Produces(MediaTypeNames.Application.Json)]
        public ActionResult<User> Get()
        {
            return _configDetails.GetUserDetails();
        }


        [HttpGet("sort")]
        public async Task<IList<Product>> GetProducts([FromQuery] SortOption sortOption)
        {
            var wooliesx = new WooliesX(_configDetails);
            return await wooliesx.GetSortedProducts(sortOption);
        }

        [HttpPost("trolleyTotal")]
        public async Task<decimal> GetTrolleyTotal([FromBody] JObject trolley)
        {
            var wooliesx = new WooliesX(_configDetails);
            return await wooliesx.GetTrolleyTotal(trolley);
        }
    }
}