using MediatR;
using server.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace server.CQRS.Queries
{        
    public class BookList : BaseQuery<Book>
    {
        public class Query : IRequest<IEnumerable<Book>> { }

        public class Handler : IRequestHandler<Query, IEnumerable<Book>>
        {
            private BookList ListQuery { get; }

            public Handler(BookList listQuery)
            {
                ListQuery = listQuery;
            }


            public async Task<IEnumerable<Book>> Handle(Query request, CancellationToken cancellationToken)
            {
                var books = await this.ListQuery.GetList("");
                return books;
            }
        }
    }

}