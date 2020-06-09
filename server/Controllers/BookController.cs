using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using server.CQRS.Queries;
using server.Models;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {

        private readonly ILogger<BookController> _logger;
        private readonly IMediator _mediator;


      
        public BookController(ILogger<BookController> logger,IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> BookList()
        {
            return await _mediator.Send(new BookList.Query());
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return null;
        }
    }
}
