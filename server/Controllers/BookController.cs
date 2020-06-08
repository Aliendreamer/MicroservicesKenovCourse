using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using server.Models;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {

        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return null;
        }
    }
}
