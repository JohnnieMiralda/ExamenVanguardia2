using Hotel.Rates.Core.Interfaces;
using Hotel.Rates.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Rates.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : BaseApiController
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            this._roomService = roomService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = this._roomService.GetRooms();
            return GetResult(result);
        }

    }
}
