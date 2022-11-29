namespace Application.Record;

// public record AuthenticationResult();

public record LoginResult(
  string Email,
  string Password,
  string Token
);

public record RegisterResult(
  string FirstName,
  string LastName,
  string Email,
  string Password
);