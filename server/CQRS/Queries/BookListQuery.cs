using MediatR;
using server.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace server.CQRS.Queries
{        
    public class BookList : IRequest<IEnumerable<Book>> { }
    public class BookListQuery:IRequestHandler<BookList, IEnumerable<Book>>
    { 
            private IBaseQuery<Book> Query { get; }

            public BookListQuery(IBaseQuery<Book> baseQuery)
            {
                Query = baseQuery;
            }

            public async Task<IEnumerable<Book>> Handle(BookList request, CancellationToken cancellationToken)
            {
                var books = await Query.GetList("");
                return books;
            }
    }

}