using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Localizei.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Localizei.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(
                IUserService userService
        )
        {
            _userService = userService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll()); ;
        }
    }
}