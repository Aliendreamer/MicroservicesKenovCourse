using MediatR;
using Server.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Server.CQRS.Commands
{
  public class AddBookModel: IRequest<UnifiedResponse>
  {
      public string Title { get; set; }

      public int Isbn { get; set; }

      public string Url { get; set; }

      public string Author { get; set; }

      public DateTime PublishedDate { get; set; }
  }

  public class AddBookCommandHandler : IRequestHandler<AddBookModel, UnifiedResponse>
  {
      public AddBookCommandHandler(IBaseCommand baseCommand)
      {
             this.BaseCommand = baseCommand;
      }

      private IBaseCommand BaseCommand { get; }

      public async Task<UnifiedResponse> Handle(AddBookModel request, CancellationToken cancellationToken)
      {
          string sql = "INSERT INTO books (title,isbn,url,published_Date) Values (@Title,@Isbn,@Url,@PublishedDate);";

          var result = await this.BaseCommand.Create(sql, request);
          var success = result == 1;
          if (success)
          {
              return new UnifiedResponse { Success = true };
          }

          return new UnifiedResponse { Success = false };
      }
  }
}
