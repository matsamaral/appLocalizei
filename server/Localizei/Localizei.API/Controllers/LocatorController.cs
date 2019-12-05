using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Localizei.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Localizei.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LocatorController : ControllerBase
    {
        private ILocatorService _locatorService;

        public LocatorController(
                ILocatorService locatorService
            )
        {
            _locatorService = locatorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _locatorService.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> PostLocalizedPerson([FromBody]string imageBase64)
        {
            return Ok(await _locatorService.LocalizedPerson(imageBase64));
        }


    }
}