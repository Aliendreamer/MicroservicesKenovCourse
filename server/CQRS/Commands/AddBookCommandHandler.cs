namespace Server.CQRS.Commands
{
   using System.Threading;
   using System.Threading.Tasks;
   using HangfireActions;
   using MediatR;
   using Server.CQRS.RequestsModels;
   using Server.Models;

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
            RegisterController.RegisterJob<UserHandler>((UserHandler) => UserHandler.RegisterNewUser());
            return new UnifiedResponse { Success = true };
         }

         return new UnifiedResponse { Success = false };
      }
   }
}
