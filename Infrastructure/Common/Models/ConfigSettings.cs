namespace Infrastructure.Common.Models
{
  public class ConfigSettings
  {
    public const string SectionName = "ConfigSettings";
    public string Secret { get; init; } = null!;
    public int ExpirationTimeInMinutes { get; init; } = 30;
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;
  }
}