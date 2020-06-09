using MediatR;
using server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace server.CQRS.Commands
{
    public class AddBookCommand
    {
        public class Edit
        {
            public class Command : IRequest
            {
                public int Id { get; set; }

                public string Title { get; set; }

                public Author Author { get; set; }
            }

            public class Handler : IRequestHandler<Command>
            {

                public Handler()
                {
                }

                public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
                {
                    Book book = null;
                    if (book == null)
                    {
                        throw new Exception("Could not find book");
                    }
                    book.Title = request.Title ?? book.Title;
                    book.Author = request.Author ?? book.Author;
                    var success = true;
                    if (success)
                    {
                        return Unit.Value;
                    }
                    throw new Exception("some problem");
                }
            }
        }
    }
}
