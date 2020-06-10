using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace UrlShortenerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortenUrlController : ControllerBase
    {
        IUriHelper _uriHelper;

        public ShortenUrlController(IUriHelper uriHelper)
        {
            _uriHelper = uriHelper;
        }
        [HttpPost]
        public string Post([FromBody] string url)
        {
            return string.Format("Shortened URI: '{0}'", _uriHelper.GetShortURI(url));
        }



        
    }
}