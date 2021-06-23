using Hotel.Rates.Core.DTO;
using Hotel.Rates.Core.Interfaces;
using Hotel.Rates.Core.Services;
using Hotel.Rates.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Hotel.Rates.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatePlansController : BaseApiController
    {
        private readonly IRatePlanService _ratePlanService;
        public RatePlansController(IRatePlanService ratePlanService)
        {
            _ratePlanService = ratePlanService;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var result = _ratePlanService.GetAll();
            return GetResult(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var ratePlan = _ratePlanService.GetRatePlansById(id);

            return GetResult(ratePlan);
        }
    }
}
