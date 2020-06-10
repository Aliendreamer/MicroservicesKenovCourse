using MediatR;
using server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace server.CQRS.Commands
{
    public class EditBookCommand:IRequest<UnifiedResponse>
    {
        public string Title { get; set; }
        public string Author { get; set; }
    }
    public class AddBookCommand:IRequestHandler<EditBookCommand,UnifiedResponse>
    {
                public async Task<UnifiedResponse> Handle(EditBookCommand request, CancellationToken cancellationToken)
                {
                    Book book = null;
                    if (book == null)
                    {
                        throw new Exception("Could not find book");
                    }
                    book.Title = request.Title ?? book.Title;
                    book.Author = null;
                    var success = true;
                    if (success)
                    {
                        return  new UnifiedResponse{Success=true};
                    }
                    return  new UnifiedResponse{Success=false};
                }
            
    }
}

