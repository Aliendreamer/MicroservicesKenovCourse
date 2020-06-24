namespace Server.CQRS.Queries
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Dapper;
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using Server.Models;

    public class BookList : IRequest<IEnumerable<Book>> { }

    public class BookListQuery : Base, IRequestHandler<BookList, IEnumerable<Book>>
    {
            public BookListQuery(IConfiguration configuration)
            : base(configuration) {}

            public async Task<IEnumerable<Book>> Handle(BookList request, CancellationToken cancellationToken)
            {
                string sql = @"select b.id as Id, title, published_date, url, isbn, a.id, a.Firstname, a.Lastname from  Books as b
                                inner join Authors  as a   on a.id  = b.AuthorId";
                var books = await this.Connection.QueryAsync<Book, Author, Book>(
                sql,
                (Book, Author) =>
                {
                    Book.Author = Author;
                    return Book;
                }, splitOn:"Id");
                return books;
            }
    }

}