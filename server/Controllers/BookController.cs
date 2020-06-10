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
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {

        private readonly ILogger<BookController> _logger;
        private readonly IMediator _mediator;


      
        public BookController(ILogger<BookController> logger,IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet,Route("BookList")]
        public async Task<IEnumerable<Book>> List()
        {
            return await _mediator.Send(new BookListQuery());
        }

        [HttpGet,Route("BookDetail/{id}")]
        public IEnumerable<Book> Get(int id)
        {
            return null;
        }
    }
}
