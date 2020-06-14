namespace Server.CQRS.RequestsModels
{
   using System;
   using MediatR;
   using Server.Models;

   public class AddBookModel : IRequest<UnifiedResponse>
   {
      public string Title { get; set; }

      public int Isbn { get; set; }

      public string Url { get; set; }

      public string Author { get; set; }

      public DateTime PublishedDate { get; set; }
  }
}
