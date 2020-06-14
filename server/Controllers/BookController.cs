namespace Server.Controllers
{
   using System.Collections.Generic;
   using System.Threading.Tasks;
   using MediatR;
   using Microsoft.AspNetCore.Mvc;
   using Microsoft.Extensions.Logging;
   using Server.CQRS.Queries;
   using Server.Models;

   [ApiController]
   [Route("api/[controller]")]
   public class BookController : ControllerBase
   {
      private readonly ILogger<BookController> logger;

      private readonly IMediator mediator;

      public BookController(ILogger<BookController> logger, IMediator mediator)
      {
         this.mediator = mediator;
         this.logger = logger;
      }

      [HttpGet]
      [Route("BookList")]
      public async Task<IEnumerable<Book>> List()
      {
         return await this.mediator.Send(new BookList());
      }

      [HttpGet]
      [Route("BookDetail/{id}")]
      public Task<Book> Get(int id)
      {
         return null;
      }

      [HttpPost]
      [Route("/addBook")]
      public async Task<UnifiedResponse> AddBook([FromBody] AddBookModel model)
      {
         return await this.mediator.Send(model);
      }
   }
}
