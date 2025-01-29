namespace Lab5.Presentation.WebAPI.Configuration;

public class DatabaseSettings
{
    public string Host { get; set; } = string.Empty;

    public int Port { get; set; }

    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Database { get; set; } = string.Empty;

    public string SslMode { get; set; } = string.Empty;
}