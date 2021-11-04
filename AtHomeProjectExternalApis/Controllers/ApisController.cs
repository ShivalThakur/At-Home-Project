using ApiOne = AtHomeProject.Apis.ApiOne;
using ApiThree = AtHomeProject.Apis.ApiThree;
using ApiTwo = AtHomeProject.Apis.ApiTwo;
using AtHomeProject.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtHomeProjectExternalApis.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [AllowAnonymous]
    public class ApisController : ControllerBase
    {


        [HttpPost("apione")]
        public IActionResult GetOfferOne(ApiOne.RequestModel queryModel)
        {
            var response = new ApiOne.ResponseModel()  { Total=1549 };
            return Ok(response);
        }
        [HttpPost("apitwo")]
        public IActionResult GetOfferTwo(ApiTwo.RequestModel queryModel)
        {
            var response = new ApiTwo.ResponseModel() { Amount = 1499 };
            return Ok(response);
        }
        [HttpPost("apithree")]
        [Produces("application/xml")]
        public IActionResult GetOfferThree(ApiThree.RequestModel request)
        {
            ApiThree.ResponseModel response = new ApiThree.ResponseModel
                ()
            {
                Quote = 1574
            };

            return Ok(response);
        }
    }
}
