namespace Models.identity
{
   	using System.Collections.Generic;

		 public class User
	    {
	      public int Id { get; set; }

	      public string FirstName { get; set; }

	      public string LastName { get; set; }

	      public string Username { get; set; }

	      public int UserRole { get; set; }

	      public Role Role { get; set; }

	      public string Password { get; set; }

	      public List<RefreshToken> RefreshTokens { get; set; }
	    }
}