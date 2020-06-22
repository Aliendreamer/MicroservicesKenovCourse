namespace Server.CQRS.Queries
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Server.Models;

    public class BookList : IRequest<IEnumerable<Book>> { }

    public class BookListQuery : IRequestHandler<BookList, IEnumerable<Book>>
    {

            public BookListQuery(IBaseQuery<Book> baseQuery)
            {
                this.Query = baseQuery;
            }

            private IBaseQuery<Book> Query { get; }

            public async Task<IEnumerable<Book>> Handle(BookList request, CancellationToken cancellationToken)
            {
                var books = await this.Query.GetList("all");
                return books;
            }
    }

}