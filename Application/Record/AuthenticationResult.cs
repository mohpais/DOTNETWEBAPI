namespace Application.Record;

// public record AuthenticationResult();

public record LoginResult(
  string FullName,
  string UserName,
  string Email,
  string PhoneNo,
  string Token
);

public record RegisterResult(
  string FirstName,
  string LastName,
  string Email,
  string Password
);