using MediatR;
using server.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace server.CQRS.Queries
{        
    public class BookListQuery : IRequest<IEnumerable<Book>> { }
    public class BookList:IRequestHandler<BookListQuery, IEnumerable<Book>>
    { 
            private IBaseQuery<Book> Query { get; }

            public BookList(IBaseQuery<Book> baseQuery)
            {
                Query = baseQuery;
            }

            public async Task<IEnumerable<Book>> Handle(BookListQuery request, CancellationToken cancellationToken)
            {
                var books = await Query.GetList("");
                return books;
            }
    }

}