using Business.Abstracts;
using Core.Aspects.Autofac.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Xml;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }


        [HttpGet("EuroBuildCEE")]
        public IActionResult GetAll()
        {
            var result = _newsService.EuroBuildCEE();
            return Ok(result);
        }

    }
}
